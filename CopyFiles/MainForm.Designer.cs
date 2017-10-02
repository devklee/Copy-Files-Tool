namespace CopyFiles
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dateFromTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dateToTimePicker = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkIgnore = new System.Windows.Forms.CheckBox();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.buttonDeleteSrc = new System.Windows.Forms.Button();
            this.buttonAddSrc = new System.Windows.Forms.Button();
            this.listBoxSource = new System.Windows.Forms.ListBox();
            this.buttonAddDist = new System.Windows.Forms.Button();
            this.textDistPath = new System.Windows.Forms.TextBox();
            this.checkDateTo = new System.Windows.Forms.CheckBox();
            this.checkDateFrom = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateFromTimePicker
            // 
            this.dateFromTimePicker.Location = new System.Drawing.Point(111, 13);
            this.dateFromTimePicker.Name = "dateFromTimePicker";
            this.dateFromTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateFromTimePicker.TabIndex = 0;
            // 
            // dateToTimePicker
            // 
            this.dateToTimePicker.Location = new System.Drawing.Point(111, 49);
            this.dateToTimePicker.Name = "dateToTimePicker";
            this.dateToTimePicker.Size = new System.Drawing.Size(200, 20);
            this.dateToTimePicker.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkIgnore);
            this.panel1.Controls.Add(this.buttonProcess);
            this.panel1.Controls.Add(this.buttonDeleteSrc);
            this.panel1.Controls.Add(this.buttonAddSrc);
            this.panel1.Controls.Add(this.listBoxSource);
            this.panel1.Controls.Add(this.buttonAddDist);
            this.panel1.Controls.Add(this.textDistPath);
            this.panel1.Controls.Add(this.checkDateTo);
            this.panel1.Controls.Add(this.checkDateFrom);
            this.panel1.Controls.Add(this.dateFromTimePicker);
            this.panel1.Controls.Add(this.dateToTimePicker);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(469, 205);
            this.panel1.TabIndex = 1;
            // 
            // checkIgnore
            // 
            this.checkIgnore.AutoSize = true;
            this.checkIgnore.Location = new System.Drawing.Point(366, 51);
            this.checkIgnore.Name = "checkIgnore";
            this.checkIgnore.Size = new System.Drawing.Size(56, 17);
            this.checkIgnore.TabIndex = 10;
            this.checkIgnore.Text = "Ignore";
            this.checkIgnore.UseVisualStyleBackColor = true;
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(366, 9);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(91, 23);
            this.buttonProcess.TabIndex = 9;
            this.buttonProcess.Text = "buttonProcess";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // buttonDeleteSrc
            // 
            this.buttonDeleteSrc.Location = new System.Drawing.Point(15, 112);
            this.buttonDeleteSrc.Name = "buttonDeleteSrc";
            this.buttonDeleteSrc.Size = new System.Drawing.Size(90, 23);
            this.buttonDeleteSrc.TabIndex = 8;
            this.buttonDeleteSrc.Text = "Delete Src";
            this.buttonDeleteSrc.UseVisualStyleBackColor = true;
            this.buttonDeleteSrc.Click += new System.EventHandler(this.buttonDeleteSrc_Click);
            // 
            // buttonAddSrc
            // 
            this.buttonAddSrc.Location = new System.Drawing.Point(15, 83);
            this.buttonAddSrc.Name = "buttonAddSrc";
            this.buttonAddSrc.Size = new System.Drawing.Size(90, 23);
            this.buttonAddSrc.TabIndex = 8;
            this.buttonAddSrc.Text = "Add Src";
            this.buttonAddSrc.UseVisualStyleBackColor = true;
            this.buttonAddSrc.Click += new System.EventHandler(this.buttonAddSrc_Click);
            // 
            // listBoxSource
            // 
            this.listBoxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxSource.FormattingEnabled = true;
            this.listBoxSource.Location = new System.Drawing.Point(111, 83);
            this.listBoxSource.Name = "listBoxSource";
            this.listBoxSource.Size = new System.Drawing.Size(346, 82);
            this.listBoxSource.TabIndex = 7;
            this.listBoxSource.SelectedIndexChanged += new System.EventHandler(this.listBoxSource_SelectedIndexChanged);
            // 
            // buttonAddDist
            // 
            this.buttonAddDist.Location = new System.Drawing.Point(15, 169);
            this.buttonAddDist.Name = "buttonAddDist";
            this.buttonAddDist.Size = new System.Drawing.Size(90, 23);
            this.buttonAddDist.TabIndex = 6;
            this.buttonAddDist.Text = "Add Dist";
            this.buttonAddDist.UseVisualStyleBackColor = true;
            this.buttonAddDist.Click += new System.EventHandler(this.buttonAddDist_Click);
            // 
            // textDistPath
            // 
            this.textDistPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textDistPath.Location = new System.Drawing.Point(111, 171);
            this.textDistPath.Name = "textDistPath";
            this.textDistPath.ReadOnly = true;
            this.textDistPath.Size = new System.Drawing.Size(346, 20);
            this.textDistPath.TabIndex = 5;
            // 
            // checkDateTo
            // 
            this.checkDateTo.AutoSize = true;
            this.checkDateTo.Location = new System.Drawing.Point(15, 52);
            this.checkDateTo.Name = "checkDateTo";
            this.checkDateTo.Size = new System.Drawing.Size(55, 17);
            this.checkDateTo.TabIndex = 3;
            this.checkDateTo.Text = "use to";
            this.checkDateTo.UseVisualStyleBackColor = true;
            this.checkDateTo.CheckedChanged += new System.EventHandler(this.checkDateTo_CheckedChanged);
            // 
            // checkDateFrom
            // 
            this.checkDateFrom.AutoSize = true;
            this.checkDateFrom.Location = new System.Drawing.Point(15, 16);
            this.checkDateFrom.Name = "checkDateFrom";
            this.checkDateFrom.Size = new System.Drawing.Size(66, 17);
            this.checkDateFrom.TabIndex = 3;
            this.checkDateFrom.Text = "use from";
            this.checkDateFrom.UseVisualStyleBackColor = true;
            this.checkDateFrom.CheckedChanged += new System.EventHandler(this.checkDateFrom_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 205);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateFromTimePicker;
        private System.Windows.Forms.DateTimePicker dateToTimePicker;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkDateTo;
        private System.Windows.Forms.CheckBox checkDateFrom;
        private System.Windows.Forms.TextBox textDistPath;
        private System.Windows.Forms.Button buttonAddDist;
        private System.Windows.Forms.ListBox listBoxSource;
        private System.Windows.Forms.Button buttonDeleteSrc;
        private System.Windows.Forms.Button buttonAddSrc;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.CheckBox checkIgnore;
    }
}