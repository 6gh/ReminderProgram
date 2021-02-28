
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
            this.taskiconMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dndStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.showStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCtrlOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCtrlSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.setupStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.updateStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.versionStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.version2StripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doNotDisturbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startOnStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updaterStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.otherSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.previewButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.taskiconMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipTitle = "SRP v3";
            this.notifyIcon1.ContextMenuStrip = this.taskiconMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SRP v3";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // taskiconMenuStrip1
            // 
            this.taskiconMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.taskiconMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dndStripMenuItem1,
            this.toolStripSeparator5,
            this.showStripMenuItem1,
            this.exitStripMenuItem1});
            this.taskiconMenuStrip1.Name = "taskiconMenuStrip1";
            this.taskiconMenuStrip1.Size = new System.Drawing.Size(180, 82);
            // 
            // dndStripMenuItem1
            // 
            this.dndStripMenuItem1.CheckOnClick = true;
            this.dndStripMenuItem1.Name = "dndStripMenuItem1";
            this.dndStripMenuItem1.Size = new System.Drawing.Size(179, 24);
            this.dndStripMenuItem1.Text = "Do Not Disturb";
            this.dndStripMenuItem1.Click += new System.EventHandler(this.dndStripMenuItem1_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(176, 6);
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
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(910, 28);
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
            this.importCtrlOToolStripMenuItem.Click += new System.EventHandler(this.importCtrlOToolStripMenuItem_Click);
            // 
            // exportCtrlSToolStripMenuItem
            // 
            this.exportCtrlSToolStripMenuItem.Name = "exportCtrlSToolStripMenuItem";
            this.exportCtrlSToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.exportCtrlSToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exportCtrlSToolStripMenuItem.Text = "Export...";
            this.exportCtrlSToolStripMenuItem.Click += new System.EventHandler(this.exportCtrlSToolStripMenuItem_Click);
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
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(221, 6);
            // 
            // versionStripMenuItem1
            // 
            this.versionStripMenuItem1.Enabled = false;
            this.versionStripMenuItem1.Name = "versionStripMenuItem1";
            this.versionStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.versionStripMenuItem1.Text = "Version: {VERSION}";
            // 
            // version2StripMenuItem2
            // 
            this.version2StripMenuItem2.Enabled = false;
            this.version2StripMenuItem2.Name = "version2StripMenuItem2";
            this.version2StripMenuItem2.Size = new System.Drawing.Size(224, 26);
            this.version2StripMenuItem2.Text = "{UPTODATEMSG}";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doNotDisturbToolStripMenuItem,
            this.startOnStartupToolStripMenuItem,
            this.updaterStripMenuItem1,
            this.toolStripSeparator2,
            this.otherSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // doNotDisturbToolStripMenuItem
            // 
            this.doNotDisturbToolStripMenuItem.CheckOnClick = true;
            this.doNotDisturbToolStripMenuItem.Name = "doNotDisturbToolStripMenuItem";
            this.doNotDisturbToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.doNotDisturbToolStripMenuItem.Text = "Do Not Disturb";
            this.doNotDisturbToolStripMenuItem.ToolTipText = "Show Balloons instead of Message Boxes? (WILL NOT BE ABLE TO REREMIND)";
            this.doNotDisturbToolStripMenuItem.Click += new System.EventHandler(this.doNotDisturbToolStripMenuItem_Click);
            // 
            // startOnStartupToolStripMenuItem
            // 
            this.startOnStartupToolStripMenuItem.CheckOnClick = true;
            this.startOnStartupToolStripMenuItem.Name = "startOnStartupToolStripMenuItem";
            this.startOnStartupToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.startOnStartupToolStripMenuItem.Text = "Start on Startup";
            this.startOnStartupToolStripMenuItem.ToolTipText = "Run Program on Windows Startup?";
            this.startOnStartupToolStripMenuItem.Click += new System.EventHandler(this.startOnStartupToolStripMenuItem_Click);
            // 
            // updaterStripMenuItem1
            // 
            this.updaterStripMenuItem1.CheckOnClick = true;
            this.updaterStripMenuItem1.Name = "updaterStripMenuItem1";
            this.updaterStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.updaterStripMenuItem1.Text = "Updater";
            this.updaterStripMenuItem1.ToolTipText = "Check for updates when program is launched?";
            this.updaterStripMenuItem1.Click += new System.EventHandler(this.updaterStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // otherSettingsToolStripMenuItem
            // 
            this.otherSettingsToolStripMenuItem.Name = "otherSettingsToolStripMenuItem";
            this.otherSettingsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.otherSettingsToolStripMenuItem.Text = "Other Settings";
            this.otherSettingsToolStripMenuItem.Click += new System.EventHandler(this.otherSettingsToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logModeToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.Visible = false;
            // 
            // logModeToolStripMenuItem
            // 
            this.logModeToolStripMenuItem.CheckOnClick = true;
            this.logModeToolStripMenuItem.Name = "logModeToolStripMenuItem";
            this.logModeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.logModeToolStripMenuItem.Text = "Log Mode";
            this.logModeToolStripMenuItem.Click += new System.EventHandler(this.logModeToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(13, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(886, 255);
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
            this.dataGridView1.Size = new System.Drawing.Size(872, 226);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.previewButton);
            this.groupBox2.Controls.Add(this.refreshButton);
            this.groupBox2.Controls.Add(this.removeButton);
            this.groupBox2.Controls.Add(this.addButton);
            this.groupBox2.Location = new System.Drawing.Point(13, 305);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(880, 85);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reminder Actions";
            // 
            // previewButton
            // 
            this.previewButton.Location = new System.Drawing.Point(725, 32);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(90, 30);
            this.previewButton.TabIndex = 3;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            this.previewButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.previewButton_MouseDown);
            this.previewButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.previewButton_MouseUp);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(516, 32);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(90, 30);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(272, 32);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(90, 30);
            this.removeButton.TabIndex = 1;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(62, 32);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(90, 30);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.stopButton);
            this.groupBox3.Controls.Add(this.startButton);
            this.groupBox3.Location = new System.Drawing.Point(13, 397);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(880, 85);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Application Actions";
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(516, 32);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(90, 30);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(272, 32);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(90, 30);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xml";
            this.openFileDialog1.FileName = "reminders";
            this.openFileDialog1.Filter = "XML Files (*.xml)|*.xml";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.Title = "Import Reminders XML";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.FileName = "reminders";
            this.saveFileDialog1.Filter = "XML Files (*.xml)|*.xml";
            this.saveFileDialog1.FilterIndex = 2;
            this.saveFileDialog1.Title = "Export Reminders XML";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 494);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Reminder Program";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.taskiconMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherSettingsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

