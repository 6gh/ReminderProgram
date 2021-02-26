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
                string mainDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ReminderProgram");
                string mainFileDir = Path.Combine(mainDir, "reminders.xml");

                if (!Directory.Exists(mainDir))
                {
                    Directory.CreateDirectory(mainDir);
                    Debugger.Log("Setup", "Created Directory");
                }
                else Debugger.Log("Setup", "Directory already exists");

                if (!File.Exists(mainFileDir))
                {
                    XDocument doc = Reminders.Generate();
                    doc.Save(mainFileDir);
                    Properties.Settings.Default.RemindersPath = mainFileDir;
                }
                else
                {
                    Debugger.Log("Setup", "File exists, parsing");
                    if (!Reminders.Valid(mainFileDir))
                    {
                        if (OtherFunctions.ValidXML(mainFileDir))
                        {
                            XDocument oldDoc = XDocument.Load(mainFileDir);
                            oldDoc.Save(Path.Combine(mainFileDir, "_old.xml"));
                        }

                        XDocument doc = Reminders.Generate();
                        doc.Save(mainFileDir);
                        Properties.Settings.Default.RemindersPath = mainFileDir;
                    }
                    else
                    {
                        Debugger.Log("Setup", "Valid XML, using that");
                        Properties.Settings.Default.RemindersPath = mainFileDir;
                    }
                }

                return "done";
            });
        }
    }
}
