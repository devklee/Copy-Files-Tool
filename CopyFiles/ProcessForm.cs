using CopyFiles.Data;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyFiles
{
    public partial class ProcessForm : Form
    {
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private List<string> _ext = new List<string> { ".jpg", ".jpeg", ".mp4", ".mov" };

        private ProcessParameter _parm = null;
        private BackgroundWorker _worker = new BackgroundWorker();
        private bool _cancel;

        public ProcessForm(ProcessParameter parm)
        {
            InitializeComponent();

            Text = Properties.strings.str009;
            buttonStop.Text = Properties.strings.str010;

            _parm = parm;
            _worker.DoWork += worker_DoWork;
            _worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            _worker.WorkerSupportsCancellation = true;
            buttonStop.Enabled = false;
        }

        private void ProcessForm_Load(object sender, EventArgs e)
        {
            if(_parm == null)
            {
                JournalAddError("Parameter is null.");
                return;
            }
            if(_parm.UseFromDate)
            {
                if (_parm.FromDate == null)
                {
                    JournalAddError("Date From is null.");
                    return;
                }
                else
                {
                    JournalAddText($"Date From: {_parm.FromDate.ToString("dd.MM.yyyy")}");
                }
            }
            if (_parm.UseToDate)
            {
                if (_parm.ToDate == null)
                {
                    JournalAddError("Date To is null.");
                    return;
                }
                else
                {
                    JournalAddText($"Date To: {_parm.ToDate.ToString("dd.MM.yyyy")}");
                }
            }
            if (_parm.UseFromDate && _parm.UseToDate && _parm.ToDate < _parm.FromDate)
            {
                JournalAddError("Date To is less as Date From.");
                return;
            }
            if (string.IsNullOrWhiteSpace(_parm.DistPath))
            {
                JournalAddError("Dist Path is not defined.");
                return;
            }
            JournalAddText($"Dist Path: {_parm.DistPath}");
            if (_parm.SrcPath.Count < 1)
            {
                JournalAddError("Src Path is not defined.");
                return;
            }
            foreach(var s in _parm.SrcPath)
            {
                JournalAddText($"Src Path: {s}");
            }
            _parm.Ext.AddRange(_ext);
            buttonStop.Enabled = true;
            _worker.RunWorkerAsync(_parm);
        }

        private void ProcessForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logger.Trace("Form closing.");
            if (_worker.IsBusy)
            {
                _worker.CancelAsync();
                _cancel = true;
                e.Cancel = true;
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (!_worker.CancellationPending)
            {
                _worker.CancelAsync();
            }
            buttonStop.Enabled = false;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Logger tlog = LogManager.GetCurrentClassLogger();
            tlog.Trace("Start thread.");
            long fileCount = 0;
            long fileCountCopy = 0;
            try
            {
                ProcessParameter tparm = e.Argument as ProcessParameter;
                if (tparm == null)
                {
                    throw new ArgumentNullException("Parameter ist null.");
                }
                BackgroundWorker tworker = sender as BackgroundWorker;

                List<string> createdFolder = new List<string>();

                foreach(var src in tparm.SrcPath)
                {
                    if(tworker.CancellationPending)
                    {
                        e.Cancel = true;
                        throw new Exception("Cancel request detected.");
                    }
                    Invoke((Action<string>)JournalAddInfo, $"Process folder {src}");

                    foreach (string file in Directory.EnumerateFiles(src, "*.*", SearchOption.AllDirectories))
                    {
                        tlog.Trace($"Process file {file}");
                        FileInfo fi = new FileInfo(file);
                        fileCount++;

                        if(tparm.UseFromDate)
                        {
                            if(tparm.FromDate > fi.LastWriteTime)
                            {
                                tlog.Trace($"File {file} to old.");
                                continue;
                            }
                        }
                        if (tparm.UseToDate)
                        {
                            if (tparm.ToDate < fi.LastWriteTime)
                            {
                                tlog.Trace($"File {file} to jung.");
                                continue;
                            }
                        }

                        string year = fi.LastWriteTime.ToString("yyyy");
                        string month = fi.LastWriteTime.ToString("MM");
                        string yearFolder = Path.Combine(tparm.DistPath, year);
                        string monthFolder = Path.Combine(yearFolder, month);

                        if (createdFolder.FirstOrDefault(x => x.Equals(yearFolder, StringComparison.OrdinalIgnoreCase)) == null)
                        {
                            if (!Directory.Exists(yearFolder))
                            {
                                tlog.Trace($"Create folder: {yearFolder}");
                                Directory.CreateDirectory(yearFolder);
                            }
                            createdFolder.Add(yearFolder);
                        }

                        if (createdFolder.FirstOrDefault(x => x.Equals(monthFolder, StringComparison.OrdinalIgnoreCase)) == null)
                        {
                            if (!Directory.Exists(monthFolder))
                            {
                                tlog.Trace($"Create folder: {monthFolder}");
                                Directory.CreateDirectory(monthFolder);
                            }
                            createdFolder.Add(monthFolder);
                        }

                        string copyFileName = Path.Combine(monthFolder, fi.Name);
                        
                        if (File.Exists(copyFileName))
                        {
                            if(tparm.FileIgnore)
                            {
                                tlog.Trace($"Ignore {file} until file exists.");
                            }
                            else
                            {
                                int count = 1;
                                string fileName = Path.GetFileNameWithoutExtension(copyFileName);
                                string copyFileName2 = Path.Combine(monthFolder, $"{fileName}-{count}{fi.Extension}");
                                while(File.Exists(copyFileName2))
                                {
                                    count++;
                                    if(count > 99)
                                    {
                                        throw new InvalidOperationException("Too many files count.");
                                    }
                                    copyFileName2 = Path.Combine(monthFolder, $"{fileName}-{count}{fi.Extension}");
                                }
                                File.Copy(file, copyFileName2);
                                string msg = $"{file} --> {copyFileName2}";
                                Invoke((Action<string>)JournalAddText, msg);
                                fileCountCopy++;
                            }
                        }
                        else
                        {
                            File.Copy(file, copyFileName);
                            string msg = $"{file} --> {copyFileName}";
                            Invoke((Action<string>)JournalAddText, msg);
                            fileCountCopy++;
                        }
                        
                    }
                }
                Invoke((Action<string>)JournalAddText, $"Processed {fileCount} file(s).");
                Invoke((Action<string>)JournalAddText, $"Copy {fileCountCopy} file(s).");
            }
            catch (Exception ex)
            {
                tlog.Error(ex);
            }
            finally
            {
                tlog.Trace("End thread.");
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Logger.Trace("Completed");
            buttonStop.Enabled = false;
            if (_cancel) Close();
            if (e.Cancelled)
            {
                JournalAddError("Process canceled.");
            }
            else
            {
                JournalAddText("Processed successful.");
            }
            if (e.Error != null)
            {
                Logger.Error(e.Error);
            }
        }

        private void JournalAddText(string text)
        {
            listBoxJournal.Items.Add(new JournalListboxItem(text));
            listBoxJournal.Refresh();
            Logger.Info(text);
        }

        private void JournalAddInfo(string text)
        {
            listBoxJournal.Items.Add(new JournalListboxItem(text, Color.DarkBlue));
            listBoxJournal.Refresh();
            Logger.Info(text);
        }

        private void JournalAddError(string text)
        {
            listBoxJournal.Items.Add(new JournalListboxItem(text, Color.Red));
            listBoxJournal.Refresh();
            Logger.Error(text);
        }

        private void listBoxJournal_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }
            JournalListboxItem item = listBoxJournal.Items[e.Index] as JournalListboxItem;
            if (item == null)
            {
                return;
            }
            e.DrawBackground();
            Graphics g = e.Graphics;

            //g.FillRectangle(new SolidBrush(Color.Olive), e.Bounds);

            g.DrawString(item.ToString(), e.Font,
                new SolidBrush(item.ItemColor == Color.Empty ? e.ForeColor : item.ItemColor),
                new PointF(e.Bounds.X, e.Bounds.Y));

            e.DrawFocusRectangle();
        }
    }
}
