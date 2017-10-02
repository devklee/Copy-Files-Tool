using CopyFiles.Data;
using Microsoft.WindowsAPICodePack.Dialogs;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyFiles
{
    public partial class MainForm : Form
    {
        private readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public ConfigData Config { get; private set; }

        public MainForm(ConfigData config)
        {
            InitializeComponent();
            Config = config;

            Text = Properties.strings.str001;
            checkDateFrom.Text = Properties.strings.str002;
            checkDateTo.Text = Properties.strings.str003;
            checkIgnore.Text =  Properties.strings.str004;
            buttonProcess.Text = Properties.strings.str005;
            buttonAddSrc.Text = Properties.strings.str006;
            buttonDeleteSrc.Text = Properties.strings.str007;
            buttonAddDist.Text = Properties.strings.str008;
        }

        private void UpdateButtons()
        {
            dateFromTimePicker.Enabled = checkDateFrom.Checked;
            dateToTimePicker.Enabled = checkDateTo.Checked;
            buttonDeleteSrc.Enabled = listBoxSource.SelectedIndex != -1;
        }

        private void buttonAddDist_Click(object sender, EventArgs e)
        {
            var openFolder = new CommonOpenFileDialog();
            openFolder.AllowNonFileSystemItems = true;
            openFolder.Multiselect = true;
            openFolder.IsFolderPicker = true;
            openFolder.Title = "Select folders with jpg files";
            var result = openFolder.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                this.textDistPath.Text = openFolder.FileName;
            }
        }

        private void buttonAddSrc_Click(object sender, EventArgs e)
        {
            var openFolder = new CommonOpenFileDialog();
            openFolder.AllowNonFileSystemItems = true;
            openFolder.Multiselect = true;
            openFolder.IsFolderPicker = true;
            openFolder.Title = "Select folders with jpg files";
            var result = openFolder.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
            {
                string folderName = openFolder.FileName;
                if (!string.IsNullOrWhiteSpace(folderName))
                {
                    int curIndex = listBoxSource.Items.IndexOf(folderName);
                    if (curIndex < 0)
                    {
                        listBoxSource.Items.Add(openFolder.FileName);
                    }
                }
            }
            UpdateButtons();
        }

        private void checkDateFrom_CheckedChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void checkDateTo_CheckedChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateButtons();
            if(Config == null)
            {
                return;
            }
            try
            {
                checkDateFrom.Checked = Config.UseDateFrom;
                dateFromTimePicker.Value = ConvDate(Config.DateFrom);
                checkDateTo.Checked = Config.UseDateTo;
                dateToTimePicker.Value = ConvDate(Config.DateTo);
                textDistPath.Text = Config.DistPath;
                checkIgnore.Checked = Config.FileIgnore;
                foreach (var s in Config.SrcPath)
                {
                    listBoxSource.Items.Add(s);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        private DateTime ConvDate(string s)
        {
            if(string.IsNullOrWhiteSpace(s))
            {
                return DateTime.Now;
            }
            try
            {
                return DateTime.ParseExact(s, "yyyy-MM-dd_HH-mm-ss", CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }
            return DateTime.Now;
        }

        private void buttonDeleteSrc_Click(object sender, EventArgs e)
        {
            if (listBoxSource.SelectedItems.Count != 0)
            {
                while (listBoxSource.SelectedIndex != -1)
                {
                    listBoxSource.Items.RemoveAt(listBoxSource.SelectedIndex);
                }
            }
            UpdateButtons();
        }

        private void listBoxSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            ProcessParameter parm = new ProcessParameter();
            parm.DistPath = textDistPath.Text;
            parm.UseFromDate = checkDateFrom.Checked;
            parm.UseToDate = checkDateTo.Checked;
            parm.FromDate = dateFromTimePicker.Value;
            parm.ToDate = dateToTimePicker.Value;
            parm.FileIgnore = checkIgnore.Checked;
            foreach (var s in listBoxSource.Items)
            {
                parm.SrcPath.Add((string)s);
            }
            ProcessForm process = new ProcessForm(parm);
            process.ShowDialog(this);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(Config == null)
            {
                Config = new ConfigData();
            }
            Config.UseDateFrom = checkDateFrom.Checked;
            Config.DateFrom = string.Format("{0:yyyy-MM-dd_HH-mm-ss}", dateFromTimePicker.Value);
            Config.UseDateTo = checkDateTo.Checked;
            Config.DateTo = string.Format("{0:yyyy-MM-dd_HH-mm-ss}", dateToTimePicker.Value);
            Config.DistPath = textDistPath.Text;
            Config.SrcPath = new List<string>();
            Config.FileIgnore = checkIgnore.Checked;
            foreach(var s in listBoxSource.Items)
            {
                Config.SrcPath.Add(s.ToString());
            }
        }
    }
}
