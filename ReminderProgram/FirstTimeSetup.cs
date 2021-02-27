using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ReminderProgram
{
    public partial class FirstTimeSetup : Form
    {
        public FirstTimeSetup()
        {
            InitializeComponent();
        }

        private async void FirstTimeSetup_Load(object sender, EventArgs e)
        {
            string a = await StartSetup();
            if(a == "done")
            {
                Properties.Settings.Default.FirstTime = false;
                Properties.Settings.Default.Save();
                Application.Restart();
                Debugger.Stop();
                //Application.Exit();
            } else
            {
                Debugger.Error("Setup", $"Failed setup, returned something else than done message\n(Received: {a})");
            }
        }

        public async static Task<string> StartSetup()
        {
            return await Task.Run(() =>
            {
                //dir variables
                string mainDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ReminderProgram");
                string mainFileDir = Path.Combine(mainDir, "reminders.xml");

                //setup directory if not already set up
                if (!Directory.Exists(mainDir))
                {
                    Directory.CreateDirectory(mainDir);
                    Debugger.Log("Setup", "Created Directory");
                }
                else Debugger.Log("Setup", "Directory already exists");

                if (!File.Exists(mainFileDir)) //if xml file doesnt exist
                {
                    //generate new xml and save
                    XDocument doc = Reminders.Generate();
                    doc.Save(mainFileDir);
                    Properties.Settings.Default.RemindersPath = mainFileDir;
                }
                else //if xml file does exist
                {
                    Debugger.Log("Setup", "File exists, parsing");
                    if (!Reminders.Valid(mainFileDir)) //if it isnt a valid xml for this app
                    {
                        if (OtherFunctions.ValidXML(mainFileDir)) //if it even is a valid xml at all
                        {
                            //save old xml to _old.xml
                            XDocument oldDoc = XDocument.Load(mainFileDir);
                            oldDoc.Save(Path.Combine(mainDir, "reminders_old.xml"));
                        }

                        //generate new xml and save
                        XDocument doc = Reminders.Generate();
                        doc.Save(mainFileDir);
                        Properties.Settings.Default.RemindersPath = mainFileDir;
                    }
                    else //if it is a valid xml for this app
                    {
                        Debugger.Log("Setup", "Valid XML, asking to use it");

                        DialogResult dialogResult = MessageBox.Show($"Found a valid XML, '{mainFileDir}'\nWould you like to use this file(Y), or create a new one (N)?", "Setup", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (dialogResult == DialogResult.Yes) //if user said yes
                        {
                            //set the valid xml to the app's xml
                            Debugger.Log("Setup", "using Valid XML");
                            Properties.Settings.Default.RemindersPath = mainFileDir;
                        } else
                        {
                            Debugger.Log("Setup", "renaming and generating");

                            //save old xml to _old.xml
                            XDocument oldDoc = XDocument.Load(mainFileDir);
                            oldDoc.Save(Path.Combine(mainDir, "reminders_old.xml"));

                            //generate new xml, save and set the xml to the app's xml
                            XDocument doc = Reminders.Generate();
                            doc.Save(mainFileDir);
                            Properties.Settings.Default.RemindersPath = mainFileDir;
                        }

                    }
                }

                //end task thing
                return "done";
            });
        }
    }
}

//hi