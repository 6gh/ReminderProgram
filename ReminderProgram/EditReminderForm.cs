using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ReminderProgram
{
    public partial class EditReminderForm : Form
    {
        internal static string id;
        private static Timer timer = new Timer();
        private static bool RanPreview = false;

        public EditReminderForm()
        {
            InitializeComponent();
        }

        private void EditReminderForm_Load(object sender, EventArgs e)
        {
            //setup timer
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);

            //setup form
            Icon = Properties.Resources.Icon;

            XmlStuff xmlStuff = Reminders.GetReminders(id);
            XmlNode node = xmlStuff.NodeList.Item(0);

            string[] date = node["Date"].InnerText.Split('/');
            string[] time = node["Time"].InnerText.Split(':');

            monthnumericUpDown1.Value = Convert.ToDecimal(date[0]);
            daynumericUpDown1.Value = Convert.ToDecimal(date[1]);
            yearnumericUpDown1.Value = Convert.ToDecimal(date[2]);

            hournumericUpDown1.Value = Convert.ToDecimal(time[0]);
            minutenumericUpDown1.Value = Convert.ToDecimal(time[1]);

            nametextBox1.Text = node["Title"].InnerText;
            textBox1.Text = node["Context"].InnerText;

            repeatcomboBox1.SelectedItem = node["Repeat"].InnerText;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (RanPreview) return;

            timer.Stop();

            if (!OtherFunctions.ValidString(nametextBox1.Text)) MessageBox.Show("Please provide a name for the reminder.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!OtherFunctions.ValidString(textBox1.Text)) MessageBox.Show("Please provide text for the reminder.", "Invalid Text", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //run reminder preview
                Reminders.RunPreview(nametextBox1.Text, textBox1.Text, true);
                RanPreview = true;
            }
        }

        private void monthnumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (monthnumericUpDown1.Value == 2)
            {
                if (DateTime.IsLeapYear(Int32.Parse(yearnumericUpDown1.Value.ToString())))
                {
                    daynumericUpDown1.Maximum = 29;
                }
                else daynumericUpDown1.Maximum = 28;
            }
            else if (monthnumericUpDown1.Value == 4 || monthnumericUpDown1.Value == 6 || monthnumericUpDown1.Value == 9 || monthnumericUpDown1.Value == 11)
            {
                daynumericUpDown1.Maximum = 30;
            }
            else
            {
                daynumericUpDown1.Maximum = 31;
            }
        }

        private void yearnumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.IsLeapYear(Int32.Parse(yearnumericUpDown1.Value.ToString())))
            {
                if (monthnumericUpDown1.Value == 2)
                {
                    daynumericUpDown1.Maximum = 29;
                }
            }
            else
            {
                if (monthnumericUpDown1.Value == 2)
                {
                    daynumericUpDown1.Maximum = 28;
                }
            }
        }

        private void previewbutton1_Click(object sender, EventArgs e)
        {
            if (RanPreview) return;

            //check if texts are valid
            if (!OtherFunctions.ValidString(nametextBox1.Text)) MessageBox.Show("Please provide a name for the reminder.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!OtherFunctions.ValidString(textBox1.Text)) MessageBox.Show("Please provide text for the reminder.", "Invalid Text", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //run reminder preview
                RanPreview = true;
                Reminders.RunPreview(nametextBox1.Text, textBox1.Text);
                RanPreview = false;
            }
        }

        private void EditReminderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1.DataReload();
        }

        private void EditReminderForm_MouseUp(object sender, MouseEventArgs e)
        {
            timer.Stop();
            RanPreview = false;
        }

        private void EditReminderForm_MouseDown(object sender, MouseEventArgs e)
        {
            timer.Start();
        }

        private void addbutton1_Click(object sender, EventArgs e)
        {
            XmlStuff xmlStuff = Reminders.GetReminders(id);
            XmlNode node = xmlStuff.NodeList.Item(0);

            //make datetime variables
            DateTime dateTime = new DateTime(Int32.Parse(yearnumericUpDown1.Value.ToString()), Int32.Parse(monthnumericUpDown1.Value.ToString()), Int32.Parse(daynumericUpDown1.Value.ToString()), Int32.Parse(hournumericUpDown1.Value.ToString()), Int32.Parse(minutenumericUpDown1.Value.ToString()), 0);

            //check if valid options
            if (!OtherFunctions.ValidString(nametextBox1.Text)) MessageBox.Show("Please provide a name for the reminder.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!OtherFunctions.ValidString(textBox1.Text)) MessageBox.Show("Please provide text for the reminder.", "Invalid Text", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!OtherFunctions.ValidDate(dateTime.Date)) MessageBox.Show("Please provide a valid date", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!OtherFunctions.ValidTime(dateTime.ToString("HH:mm"))) MessageBox.Show("Please provide a valid time", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!Reminders.ValidRepetition(repeatcomboBox1.SelectedItem.ToString())) MessageBox.Show("Please provide a valid repeat option", "Invalid Repeat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                Reminders.Edit(id, nametextBox1.Text, textBox1.Text, dateTime, repeatcomboBox1.SelectedItem.ToString());
            }

            Close();
        }
    }
}
