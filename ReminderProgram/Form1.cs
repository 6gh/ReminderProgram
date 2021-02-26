using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            notifyIcon1.Visible = false;
            notifyIcon1.ContextMenuStrip = taskiconMenuStrip1;

            //setup toolstrips and data and such (or something)
            doNotDisturbToolStripMenuItem.Checked = Properties.Settings.Default.DoNotDisturb; //setup dnd stuff
            dndStripMenuItem1.Checked = Properties.Settings.Default.DoNotDisturb;

            startOnStartupToolStripMenuItem.Checked = Properties.Settings.Default.RunOnStartup; //setup start on startup stuff

            updaterStripMenuItem1.Checked = Properties.Settings.Default.CheckForUpdates; //setup updater stuff

            versionStripMenuItem1.Text = versionStripMenuItem1.Text.Replace("{VERSION}", $"{Properties.Settings.Default.Version}"); //setup versions toolstrip
            versions2toolstrip = version2StripMenuItem2;

            //setup datagridview
            dataGridView = dataGridView1;
            DataReload();

            //check for updates
            Updates.Check(true);
        }

        private static void DataReload()
        {
            dataGridView.DataSource = null;
            DataSet ds = new DataSet();
            ds.ReadXml(Properties.Settings.Default.RemindersPath);
            dataGridView.DataSource = ds.Tables[0];
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // If application is minimized
            if(WindowState == FormWindowState.Minimized)
            {
                //hide form and show tray icon
                Hide();
                notifyIcon1.Visible = true;

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
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
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
                Show();
                WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
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
    }
}
