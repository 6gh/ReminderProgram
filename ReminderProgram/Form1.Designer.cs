
namespace ReminderProgram
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCtrlOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCtrlSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.setupStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.updateStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doNotDisturbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startOnStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updaterStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.retimeStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.retimerStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.timeIntervalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intervalStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.taskiconMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dndStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.versionStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.version2StripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.taskiconMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(913, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importCtrlOToolStripMenuItem,
            this.exportCtrlSToolStripMenuItem,
            this.toolStripSeparator1,
            this.setupStripMenuItem1,
            this.toolStripSeparator3,
            this.updateStripMenuItem1,
            this.toolStripSeparator4,
            this.versionStripMenuItem1,
            this.version2StripMenuItem2});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importCtrlOToolStripMenuItem
            // 
            this.importCtrlOToolStripMenuItem.Name = "importCtrlOToolStripMenuItem";
            this.importCtrlOToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.importCtrlOToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.importCtrlOToolStripMenuItem.Text = "Import...";
            // 
            // exportCtrlSToolStripMenuItem
            // 
            this.exportCtrlSToolStripMenuItem.Name = "exportCtrlSToolStripMenuItem";
            this.exportCtrlSToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.exportCtrlSToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exportCtrlSToolStripMenuItem.Text = "Export...";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // setupStripMenuItem1
            // 
            this.setupStripMenuItem1.Name = "setupStripMenuItem1";
            this.setupStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.setupStripMenuItem1.Text = "Run Setup...";
            this.setupStripMenuItem1.Click += new System.EventHandler(this.setupStripMenuItem1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(221, 6);
            // 
            // updateStripMenuItem1
            // 
            this.updateStripMenuItem1.Name = "updateStripMenuItem1";
            this.updateStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.updateStripMenuItem1.Text = "Check for Updates...";
            this.updateStripMenuItem1.Click += new System.EventHandler(this.updateStripMenuItem1_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doNotDisturbToolStripMenuItem,
            this.startOnStartupToolStripMenuItem,
            this.updaterStripMenuItem1,
            this.toolStripSeparator2,
            this.retimeStripMenuItem1,
            this.timeIntervalToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 26);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // doNotDisturbToolStripMenuItem
            // 
            this.doNotDisturbToolStripMenuItem.Checked = true;
            this.doNotDisturbToolStripMenuItem.CheckOnClick = true;
            this.doNotDisturbToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doNotDisturbToolStripMenuItem.Name = "doNotDisturbToolStripMenuItem";
            this.doNotDisturbToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.doNotDisturbToolStripMenuItem.Text = "Do Not Disturb";
            this.doNotDisturbToolStripMenuItem.Click += new System.EventHandler(this.doNotDisturbToolStripMenuItem_Click);
            // 
            // startOnStartupToolStripMenuItem
            // 
            this.startOnStartupToolStripMenuItem.Checked = true;
            this.startOnStartupToolStripMenuItem.CheckOnClick = true;
            this.startOnStartupToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.startOnStartupToolStripMenuItem.Name = "startOnStartupToolStripMenuItem";
            this.startOnStartupToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.startOnStartupToolStripMenuItem.Text = "Start on Startup";
            this.startOnStartupToolStripMenuItem.Click += new System.EventHandler(this.startOnStartupToolStripMenuItem_Click);
            // 
            // updaterStripMenuItem1
            // 
            this.updaterStripMenuItem1.Checked = true;
            this.updaterStripMenuItem1.CheckOnClick = true;
            this.updaterStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.updaterStripMenuItem1.Name = "updaterStripMenuItem1";
            this.updaterStripMenuItem1.Size = new System.Drawing.Size(250, 26);
            this.updaterStripMenuItem1.Text = "Updater";
            this.updaterStripMenuItem1.ToolTipText = "Check for updates when program is launched?";
            this.updaterStripMenuItem1.Click += new System.EventHandler(this.updaterStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(247, 6);
            // 
            // retimeStripMenuItem1
            // 
            this.retimeStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.retimerStripComboBox1});
            this.retimeStripMenuItem1.Name = "retimeStripMenuItem1";
            this.retimeStripMenuItem1.Size = new System.Drawing.Size(250, 26);
            this.retimeStripMenuItem1.Text = "Reremind in (Mins):";
            // 
            // retimerStripComboBox1
            // 
            this.retimerStripComboBox1.Name = "retimerStripComboBox1";
            this.retimerStripComboBox1.Size = new System.Drawing.Size(121, 28);
            this.retimerStripComboBox1.Text = "30";
            // 
            // timeIntervalToolStripMenuItem
            // 
            this.timeIntervalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.intervalStripComboBox1});
            this.timeIntervalToolStripMenuItem.Name = "timeIntervalToolStripMenuItem";
            this.timeIntervalToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.timeIntervalToolStripMenuItem.Text = "Time Interval (Seconds):";
            // 
            // intervalStripComboBox1
            // 
            this.intervalStripComboBox1.Name = "intervalStripComboBox1";
            this.intervalStripComboBox1.Size = new System.Drawing.Size(121, 28);
            this.intervalStripComboBox1.Text = "5";
            // 
            // taskiconMenuStrip1
            // 
            this.taskiconMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.taskiconMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showStripMenuItem1,
            this.exitStripMenuItem1,
            this.dndStripMenuItem1});
            this.taskiconMenuStrip1.Name = "taskiconMenuStrip1";
            this.taskiconMenuStrip1.Size = new System.Drawing.Size(180, 76);
            // 
            // showStripMenuItem1
            // 
            this.showStripMenuItem1.Name = "showStripMenuItem1";
            this.showStripMenuItem1.Size = new System.Drawing.Size(179, 24);
            this.showStripMenuItem1.Text = "Show";
            this.showStripMenuItem1.Click += new System.EventHandler(this.showStripMenuItem1_Click);
            // 
            // exitStripMenuItem1
            // 
            this.exitStripMenuItem1.Name = "exitStripMenuItem1";
            this.exitStripMenuItem1.Size = new System.Drawing.Size(179, 24);
            this.exitStripMenuItem1.Text = "Exit";
            this.exitStripMenuItem1.Click += new System.EventHandler(this.exitStripMenuItem1_Click);
            // 
            // dndStripMenuItem1
            // 
            this.dndStripMenuItem1.CheckOnClick = true;
            this.dndStripMenuItem1.Name = "dndStripMenuItem1";
            this.dndStripMenuItem1.Size = new System.Drawing.Size(179, 24);
            this.dndStripMenuItem1.Text = "Do Not Disturb";
            this.dndStripMenuItem1.Click += new System.EventHandler(this.dndStripMenuItem1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(13, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(890, 255);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reminders";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(876, 226);
            this.dataGridView1.TabIndex = 0;
            // 
            // versionStripMenuItem1
            // 
            this.versionStripMenuItem1.Enabled = false;
            this.versionStripMenuItem1.Name = "versionStripMenuItem1";
            this.versionStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.versionStripMenuItem1.Text = "Version: {VERSION}";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(221, 6);
            // 
            // version2StripMenuItem2
            // 
            this.version2StripMenuItem2.Enabled = false;
            this.version2StripMenuItem2.Name = "version2StripMenuItem2";
            this.version2StripMenuItem2.Size = new System.Drawing.Size(224, 26);
            this.version2StripMenuItem2.Text = "{UPTODATEMSG}";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 441);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Simple Reminder Program";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.taskiconMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importCtrlOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCtrlSToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem setupStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doNotDisturbToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startOnStartupToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem retimeStripMenuItem1;
        private System.Windows.Forms.ToolStripComboBox retimerStripComboBox1;
        private System.Windows.Forms.ToolStripMenuItem timeIntervalToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox intervalStripComboBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem updateStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip taskiconMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dndStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem updaterStripMenuItem1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem versionStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem version2StripMenuItem2;
    }
}

