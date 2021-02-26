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
    public partial class AddReminderForm : Form
    {
        public AddReminderForm()
        {
            InitializeComponent();
        }

        private void AddReminderForm_Load(object sender, EventArgs e)
        {
            //setup form
            Icon = Properties.Resources.Icon;

            //assign variables for next step
            DateTime now = DateTime.Now;

            //setup values and such
            monthnumericUpDown1.Value = now.Month; //date
            yearnumericUpDown1.Value = now.Year;
            daynumericUpDown1.Value = now.Day;

            hournumericUpDown1.Value = now.Hour; //time
            minutenumericUpDown1.Value = now.Minute;

            repeatcomboBox1.SelectedIndex = 0; //repeat
        }

        private void monthnumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if(monthnumericUpDown1.Value == 2)
            {
                if (DateTime.IsLeapYear(Int32.Parse(yearnumericUpDown1.Value.ToString())))
                {
                    daynumericUpDown1.Maximum = 29;
                }
                else daynumericUpDown1.Maximum = 28;
            } else if (monthnumericUpDown1.Value == 4 || monthnumericUpDown1.Value == 6 || monthnumericUpDown1.Value == 9 || monthnumericUpDown1.Value == 11)
            {
                daynumericUpDown1.Maximum = 30;
            } else
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
            } else
            {
                if (monthnumericUpDown1.Value == 2)
                {
                    daynumericUpDown1.Maximum = 28;
                }
            }
        }

        private void previewbutton1_Click(object sender, EventArgs e)
        {
            //check if texts are valid
            if (!OtherFunctions.ValidString(nametextBox1.Text)) MessageBox.Show("Please provide a name for the reminder.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (!OtherFunctions.ValidString(textBox1.Text)) MessageBox.Show("Please provide text for the reminder.", "Invalid Text", MessageBoxButtons.OK, MessageBoxIcon.Error);

            //run reminder thing
            Reminders.RunPreview(nametextBox1.Text, textBox1.Text);
        }

        private void addbutton1_Click(object sender, EventArgs e)
        {

        }
    }
}
