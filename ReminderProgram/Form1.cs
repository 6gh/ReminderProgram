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

namespace ReminderProgram
{
    public partial class Form1 : Form
    {
        internal static DataGridView dataGridView;
        internal static ToolStripMenuItem versions2toolstrip;
        internal static OpenFileDialog openFileDialog;

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

            //setup open dialog
            openFileDialog = openFileDialog1;

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
            try
            {
                Updates.Check(true);
            } catch (Exception ex)
            {
                Debugger.Error("Updates", ex.Message);
                version2StripMenuItem2.Text = "Couldn't Check for Updates";
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
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon1.BalloonTipText = "Program is running in the background";
                notifyIcon1.BalloonTipTitle = "SRP v3";
                notifyIcon1.ShowBalloonTip(2000);
            }
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
            try
            {
                Updates.Check();
            }
            catch (Exception ex)
            {
                Debugger.Error("Updates", ex.Message);
                version2StripMenuItem2.Text = "Couldn't Check for Updates";
                MessageBox.Show($"Failed to check for updates\n\n{ex.Message}", "Updates", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private static void LoadFile()
        {
            try
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(Properties.Settings.Default.RemindersPath);
            } catch (Exception e)
            {
                Debugger.Error("LoadFile", e.Message);
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            try
            {
                openFileDialog.FileName = Path.GetFileName(Properties.Settings.Default.RemindersPath);
            } catch (Exception e)
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
    }
}
