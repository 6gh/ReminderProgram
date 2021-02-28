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
    public partial class OtherSettings : Form
    {
        public OtherSettings()
        {
            InitializeComponent();
        }

        private void OtherSettings_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.Icon;

            rnumericUpDown1.Value = Properties.Settings.Default.ReRemind;
            tnumericUpDown1.Value = Properties.Settings.Default.TimerInterval;
            checkBox1.Checked = Properties.Settings.Default.StartOnStartup;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OtherSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.ReRemind = Int32.Parse(rnumericUpDown1.Value.ToString());
            Properties.Settings.Default.TimerInterval = Int32.Parse(tnumericUpDown1.Value.ToString());
            Properties.Settings.Default.Save();
        }

        private void OtherSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.DataReload();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.StartOnStartup = checkBox1.Checked;
            Properties.Settings.Default.Save();

            if (checkBox1.Checked)
            {
                checkBox1.Text = "Yes";
            } else
            {
                checkBox1.Text = "No";
            }
        }
    }
}
