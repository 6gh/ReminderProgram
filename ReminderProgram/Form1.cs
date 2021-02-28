using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ReminderProgram
{
    public partial class Form1 : Form
    {
        internal static DataGridView dataGridView;
        internal static ToolStripMenuItem versions2toolstrip;
        internal static OpenFileDialog openFileDialog;
        internal static SaveFileDialog saveFileDialog;
        internal static NotifyIcon notifyIcon;
        internal static Timer timer = new Timer();
        public bool RanPreview = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //setup form
            Icon = Properties.Resources.Icon;

            //setup tray icon
            notifyIcon1.Icon = Properties.Resources.Icon;
            notifyIcon1.Visible = true;
            notifyIcon = notifyIcon1;
            SendNotif("Simple Reminder Program", $"SRP v{Properties.Settings.Default.Version}", ToolTipIcon.Info);

            //setup timer
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);

            //setup open and save dialog
            openFileDialog = openFileDialog1;
            saveFileDialog = saveFileDialog1;

            //setup toolstrips and data and such (or something)
            doNotDisturbToolStripMenuItem.Checked = Properties.Settings.Default.DoNotDisturb; //setup dnd stuff
            dndStripMenuItem1.Checked = Properties.Settings.Default.DoNotDisturb;

            startOnStartupToolStripMenuItem.Checked = Properties.Settings.Default.RunOnStartup; //setup start on startup stuff

            updaterStripMenuItem1.Checked = Properties.Settings.Default.CheckForUpdates; //setup updater stuff

            versionStripMenuItem1.Text = versionStripMenuItem1.Text.Replace("{VERSION}", $"{Properties.Settings.Default.Version}"); //setup versions toolstrip
            versions2toolstrip = version2StripMenuItem2;

            logModeToolStripMenuItem.Checked = Debugger.LogMode;

            if (Program.DebugMode)
            {
                debugToolStripMenuItem.Visible = true;
            }

            //setup datagridview
            dataGridView = dataGridView1;
            DataReload();

            //check for updates
            Updates.Check(true);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (RanPreview) return;
            timer.Stop();

            DataGridViewRow selected = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex];

            //check if texts are valid
            if (!OtherFunctions.ValidString(selected.Cells["Title"].Value.ToString())) MessageBox.Show("Please provide a name for the reminder.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!OtherFunctions.ValidString(selected.Cells["Context"].Value.ToString())) MessageBox.Show("Please provide text for the reminder.", "Invalid Text", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //run reminder preview
                RanPreview = true;
                Reminders.RunPreview(selected.Cells["Title"].Value.ToString(), selected.Cells["Context"].Value.ToString(), true);
            }
        }

        internal static void DataReload()
        {
            dataGridView.DataSource = null;
            dataGridView.Refresh();
            DataSet ds = new DataSet();
            if (Reminders.Valid(Properties.Settings.Default.RemindersPath))
            {
                ds.ReadXml(Properties.Settings.Default.RemindersPath);
                dataGridView.DataSource = ds.Tables[0];
                dataGridView.Refresh();
            } else
            {
                DialogResult result;

                if (OtherFunctions.ValidXML(Properties.Settings.Default.RemindersPath))
                {
                    Debugger.Log("Form1", "Invalid Reminder XML");

                    result = MessageBox.Show("The Reminder XML is invalid for this application.\nWould you like to Retry, run Setup (Abort), or load a file (Ignore)?", "Invalid Reminder XML", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                } else
                {
                    result = MessageBox.Show("The XML is invalid for this application.\nWould you like to Retry, run Setup (Abort), or load a file (Ignore)?", "Invalid XML", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                }


                if (result == DialogResult.Retry)
                {
                    DataReload();
                    return;
                }
                else if (result == DialogResult.Abort)
                {
                    Properties.Settings.Default.FirstTime = true;
                    Properties.Settings.Default.Save();
                    Application.Restart();
                }
                else if (result == DialogResult.Ignore)
                {
                    LoadFile();
                }
                else
                {
                    DataReload();
                    return;
                }
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // If application is minimized
            if(WindowState == FormWindowState.Minimized)
            {
                //hide form
                Hide();

                //send balloon
                SendNotif("Program is running in the background");
            }
        }

        internal static void SendNotif(string text, string name="SRP v3", ToolTipIcon tipIcon=ToolTipIcon.Info)
        {
            notifyIcon.BalloonTipIcon = tipIcon;
            notifyIcon.BalloonTipText = text;
            notifyIcon.BalloonTipTitle = name;
            notifyIcon.ShowBalloonTip(2000);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //disposing tray icon
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();

            //stop debugger
            Debugger.Stop();

            //save settings
            Properties.Settings.Default.Save();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!Visible)
            {
                //showing form
                Show();
                WindowState = FormWindowState.Normal;
            }
        }

        private void doNotDisturbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DoNotDisturb = doNotDisturbToolStripMenuItem.Checked;
            dndStripMenuItem1.Checked = doNotDisturbToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void startOnStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.RunOnStartup = startOnStartupToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
            OtherFunctions.ToggleStartup(startOnStartupToolStripMenuItem.Checked);
        }

        private void exitStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void showStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!Visible)
            {
                //showing form
                Show();
                WindowState = FormWindowState.Normal;
            }
        }

        private void dndStripMenuItem1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DoNotDisturb = dndStripMenuItem1.Checked;
            doNotDisturbToolStripMenuItem.Checked = dndStripMenuItem1.Checked;
            Properties.Settings.Default.Save();
        }

        private void updaterStripMenuItem1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckForUpdates = updaterStripMenuItem1.Checked;
            Properties.Settings.Default.Save();
        }

        private void setupStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to restart and enter setup mode?", "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(result == DialogResult.OK)
            {
                Properties.Settings.Default.FirstTime = true;
                Properties.Settings.Default.Save();
                Application.Restart();
            }
        }

        private void updateStripMenuItem1_Click(object sender, EventArgs e)
        {
            Updates.Check();
        }

        private void logModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debugger.ToggleLogMode();
        }

        private void otherSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtherSettings form = new OtherSettings();

            form.ShowDialog();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            DataReload();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddReminderForm addForm = new AddReminderForm();
            addForm.ShowDialog();
        }

        private void importCtrlOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (Reminders.Count() > 1) //more than 1 reminder?
            {
                //get id
                string reminderid = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["ID"].Value.ToString();
                Debugger.Log("RemoveButton", $"Selected {reminderid}");

                //try removing
                try
                {
                    Reminders.Remove(reminderid);
                }
                catch (Exception ex)
                {
                    Debugger.Error("RemoveButton", ex.Message);
                    MessageBox.Show($"Failed to remove that reminder\n\n{ex.Message}", "Remove Reminder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DataReload();
                }
            } else if (Reminders.Count() == 1)
            {
                MessageBox.Show("You cannot delete the only reminder!", "Remove Reminder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            if (RanPreview) return;

            DataGridViewRow selected = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex];

            //check if texts are valid
            if (!OtherFunctions.ValidString(selected.Cells["Title"].Value.ToString())) MessageBox.Show("Please provide a name for the reminder.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!OtherFunctions.ValidString(selected.Cells["Context"].Value.ToString())) MessageBox.Show("Please provide text for the reminder.", "Invalid Text", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //run reminder preview
                RanPreview = true;
                Reminders.RunPreview(selected.Cells["Title"].Value.ToString(), selected.Cells["Context"].Value.ToString());
                RanPreview = false;
            }
        }

        private void previewButton_MouseDown(object sender, MouseEventArgs e)
        {
            timer.Start();
        }

        private void previewButton_MouseUp(object sender, MouseEventArgs e)
        {
            timer.Stop();
            RanPreview = false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //disable controls
            importCtrlOToolStripMenuItem.Enabled = false;
            exportCtrlSToolStripMenuItem.Enabled = false;
            setupStripMenuItem1.Enabled = false;

            otherSettingsToolStripMenuItem.Enabled = false;

            addButton.Enabled = false;
            removeButton.Enabled = false;
            refreshButton.Enabled = false;
            previewButton.Enabled = false;
            startButton.Enabled = false;
            stopButton.Enabled = true;

            //start reminding
            Reminders.Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            //enable controls
            importCtrlOToolStripMenuItem.Enabled = true;
            exportCtrlSToolStripMenuItem.Enabled = true;
            setupStripMenuItem1.Enabled = true;

            otherSettingsToolStripMenuItem.Enabled = true;

            addButton.Enabled = true;
            removeButton.Enabled = true;
            refreshButton.Enabled = true;
            previewButton.Enabled = true;
            startButton.Enabled = true;
            stopButton.Enabled = false;

            //stop reminding
            Reminders.Stop();
        }

        private void exportCtrlSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportFile();
        }

        private static void LoadFile()
        {
            try
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(Properties.Settings.Default.RemindersPath);
            }
            catch (Exception e)
            {
                Debugger.Error("LoadFile", e.Message);
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            try
            {
                openFileDialog.FileName = Path.GetFileName(Properties.Settings.Default.RemindersPath);
            }
            catch (Exception e)
            {
                Debugger.Error("LoadFile", e.Message);
            }

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.RemindersPath = openFileDialog.FileName;
                Properties.Settings.Default.Save();
                DataReload();
            }
        }

        private void ExportFile()
        {
            try
            {
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(Properties.Settings.Default.RemindersPath);
            }
            catch (Exception e)
            {
                Debugger.Error("ExportFile", e.Message);
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            try
            {
                saveFileDialog.FileName = Path.GetFileName(Properties.Settings.Default.RemindersPath);
            }
            catch (Exception e)
            {
                Debugger.Error("LoadFile", e.Message);
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Reminders.Valid(Properties.Settings.Default.RemindersPath))
                {
                    XDocument doc = XDocument.Load(Properties.Settings.Default.RemindersPath);
                    doc.Save(saveFileDialog.FileName);

                    MessageBox.Show($"Exported to '{saveFileDialog.FileName}'", "Export File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DataReload();
            }
        }
    }
}
