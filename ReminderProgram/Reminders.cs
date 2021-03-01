using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace ReminderProgram
{
    public class Reminders
    {
        public static string[] validRepeats = { "Once", "Daily", "Weekly", "Monthly", "Yearly" };
        public static System.Timers.Timer IntervalTimer = new System.Timers.Timer();
        public static bool Running = false;
        public static Reminder[] reminders;

        public static bool Valid(string path)
        {
            if (OtherFunctions.ValidXML(path))
            {
                XDocument doc = XDocument.Load(path);
                XElement root = doc.Element("Reminders");

                if (root != null)
                {
                    if (doc.Elements().Count() > 1) return false;
                    
                    IEnumerable<XElement> list1 = root.Elements();

                    foreach (XElement el in list1)
                    {
                        if (!OtherFunctions.ValidTime(el.Element("Time").Value)) return false;
                        if (!OtherFunctions.ValidDate(el.Element("Date").Value)) return false;
                        if (!OtherFunctions.ValidString(el.Element("Title").Value)) return false;
                        if (!OtherFunctions.ValidString(el.Element("Context").Value)) return false;
                        if (!ValidRepetition(el.Element("Repeat").Value)) return false;
                    }

                    return true;
                }
                else return false;
            }
            else return false;
        }

        public static bool ValidRepetition(string value)
        {
            if (Array.IndexOf(validRepeats, value) > -1) return true;
            else return false;
        }

        internal static string NewID()
        {
            Random rand = new Random();
            int value = rand.Next(1000);

            return value.ToString("000");
        }

        public static XDocument Generate()
        {
            XDocument doc = new XDocument();
            XElement root = new XElement("Reminders");
            doc.Add(root);

            XElement reminder = new XElement("Reminder", 
                new XAttribute("ID", NewID()),
                new XElement("Title", "Reminder"),
                new XElement("Context", "Your reminder is now!"),
                new XElement("Time", "3:00"),
                new XElement("Date", "12/31/2021"),
                new XElement("Repeat", "Once")
            );
            doc.Element("Reminders").Add(reminder);

            return doc;
        }

        internal static XElement Generate(string name, string text, DateTime dateTime, string repeat)
        {
            XElement reminder = new XElement("Reminder",
                new XAttribute("ID", NewID()),
                new XElement("Title", name),
                new XElement("Context", text),
                new XElement("Time", dateTime.ToString("HH:mm")),
                new XElement("Date", dateTime.ToString("MM/dd/yyyy")),
                new XElement("Repeat", repeat)
            );

            return reminder;
        }

        internal static void RunPreview(string name, string text, bool dnd=false)
        {
            if(!dnd)
            {
                text += $"\n\nClick Cancel to reremind in {Properties.Settings.Default.ReRemind} minutes";

                DialogResult result = MessageBox.Show(text, name, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (result == DialogResult.Cancel)
                {
                    MessageBox.Show($"Clicking this would usually remind you again in {Properties.Settings.Default.ReRemind} minutes (Change in Settings > Other Settings > Re-Remind) but since this is a preview, it will not.", "Preview", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else
            {
                Form1.SendNotif(text, name);
            }
        }

        internal static void Add(string name, string text, DateTime dateTime, string repeat)
        {
            if (Valid(Properties.Settings.Default.RemindersPath))
            {
                XDocument doc = XDocument.Load(Properties.Settings.Default.RemindersPath);
                doc.Element("Reminders").Add(Generate(name, text, dateTime, repeat));
                doc.Save(Properties.Settings.Default.RemindersPath);

                MessageBox.Show($"Reminder, {name}, added!", "Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                Form1.DataReload();
            }
        }

        internal static void Add(XElement element)
        {
            if (Valid(Properties.Settings.Default.RemindersPath))
            {
                XDocument doc = XDocument.Load(Properties.Settings.Default.RemindersPath);
                doc.Element("Reminders").Add(element);
                doc.Save(Properties.Settings.Default.RemindersPath);
            }
            else
            {
                Form1.DataReload();
            }
        }

        internal static void Remove(string id)
        {
            XmlStuff stuff = GetReminders(id);

            if (stuff.Made)
            {
                foreach (XmlNode node in stuff.NodeList)
                {
                    stuff.Document.SelectSingleNode("Reminders").RemoveChild(node);
                }

                stuff.Document.Save(Properties.Settings.Default.RemindersPath);
                Form1.DataReload();
            }
        }

        internal static void Edit(string id, string name, string text, DateTime dateTime, string repeat)
        {
            XmlStuff stuff = GetReminders(id);

            foreach (XmlNode node in stuff.NodeList)
            {
                node["Title"].InnerText = name;
                node["Context"].InnerText = text;
                node["Date"].InnerText = dateTime.ToString("MM/dd/yyyy");
                node["Time"].InnerText = dateTime.ToString("HH:mm");
                node["Repeat"].InnerText = repeat;
            }

            stuff.Document.Save(Properties.Settings.Default.RemindersPath);
            Form1.DataReload();
        }

        internal static XmlStuff GetReminders(string id)
        {
            XmlDocument xmlDocument = new XmlDocument();
            if (Valid(Properties.Settings.Default.RemindersPath))
            {
                //load xml file
                xmlDocument.Load(Properties.Settings.Default.RemindersPath);
            } else
            {
                Form1.DataReload();
                return new XmlStuff();
            }

            //create object
            XmlStuff xmlStuff = new XmlStuff(xmlDocument, xmlDocument.SelectNodes($"/Reminders/Reminder[@ID={id}]"));

            //get nodes and return them
            return xmlStuff;
        }

        internal static int Count()
        {
            if (Valid(Properties.Settings.Default.RemindersPath))
            {
                //load doc
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(Properties.Settings.Default.RemindersPath);

                //get reminders
                XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/Reminders/Reminder");

                //return the count
                return xmlNodeList.Count;
            } else
            {
                Form1.DataReload();
                return 0;
            }
        }

        internal static void Start()
        {
            if (Running) MessageBox.Show("The program is already running!", "Start", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (Valid(Properties.Settings.Default.RemindersPath))
                {
                    //load doc
                    XmlDocument doc = new XmlDocument();
                    doc.Load(Properties.Settings.Default.RemindersPath);

                    //get all reminders
                    XmlNodeList xmlNodeList = doc.SelectNodes("/Reminders/Reminder");

                    //add all the nodes to the reminders array

                    reminders = new Reminder[Count()];

                    for (int i = 0; i < Count(); i++)
                    {
                        XmlNode node = xmlNodeList[i];

                        string[] date = node.SelectSingleNode("Date").InnerText.Split('/');
                        string[] time = node.SelectSingleNode("Time").InnerText.Split(':');

                        DateTime reminderdatetime = new DateTime(Convertions.ToInt(date[2]), Convertions.ToInt(date[0]), Convertions.ToInt(date[1]), Convertions.ToInt(time[0]), Convertions.ToInt(time[1]), 0);
                        Reminder reminder = new Reminder(node.SelectSingleNode("Title").InnerText, node.SelectSingleNode("Context").InnerText, reminderdatetime, node.SelectSingleNode("Repeat").InnerText, node.Attributes.Item(0).InnerText);

                        reminders.SetValue(reminder, i);

                        Console.WriteLine(reminder.ToString());
                    }

                    Debugger.Log("Reminders", "Reminder Count: " + reminders.Length.ToString());

                    //setup timer
                    IntervalTimer.Interval = Properties.Settings.Default.TimerInterval * 1000;
                    IntervalTimer.Elapsed += IntervalTimer_Elapsed;

                    //start timer
                    IntervalTimer.Start();

                    //set the variable
                    Running = true;
                }
            }
        }

        private static void IntervalTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //get current time
            DateTime dateTime = DateTime.Now;

            //see if any reminders are due now
            for (int i = 0; i < reminders.Length; i++)
            {
                Reminder reminder = reminders.ElementAt(i);

                if (!Running) break; //stop if not running

                if (reminder.Ran) return; //if reminder already ran, skip

                if (dateTime.ToString("MM/dd/yyyy HH:mm") == reminder.DateTime.ToString("MM/dd/yyyy HH:mm")) //if this reminder is due now
                {
                    Debugger.Log("Reminders", "found Reminder due now");
                    //set ran bool
                    reminder.Ran = true;

                    if (!Properties.Settings.Default.DoNotDisturb) //if not in dnd mode
                    {
                        //setup text
                        string newText = $"{reminder.Text}\n\nClick Cancel to reremind in {Properties.Settings.Default.ReRemind} minutes";

                        //see if reremind or not
                        Debugger.Log("Reminders", "showing reminder");
                        DialogResult result = MessageBox.Show(newText, reminder.Name, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        if (result == DialogResult.Cancel) //if reremind
                        {
                            Debugger.Log("Reminders", "setting up rereminder");

                            //create new settings for reminder
                            reminder.DateTime = reminder.DateTime.AddMinutes(Convert.ToDouble(Properties.Settings.Default.ReRemind));
                            reminder.Ran = false;
                        }
                        else //if not reremind
                        {
                            Debugger.Log("Reminders", "no reremind");
                            //get next repeat
                            string nextRepeat = reminder.NextRepeat();

                            if (nextRepeat != null) //if there is a repeat
                            {
                                Debugger.Log("Reminders", $"found repeat: {reminder.Repeat}");

                                //setup datetime
                                string[] nextDateTime = nextRepeat.Split(' ');
                                string[] date = nextDateTime[0].Split('/');
                                string[] time = nextDateTime[1].Split(':');

                                DateTime reminderdatetime = new DateTime(Convertions.ToInt(date[2]), Convertions.ToInt(date[0]), Convertions.ToInt(date[1]), Convertions.ToInt(time[0]), Convertions.ToInt(time[1]), 0);

                                //edit current reminder
                                Edit(reminder.ID, reminder.Name, reminder.Text, reminderdatetime, reminder.Repeat);

                                //create new settings for reminder
                                reminder.DateTime = reminderdatetime;
                                reminder.Ran = false;
                            } else
                            {
                                Debugger.Log("Reminders", "no repeat | only once");

                                if (Count() > 1)
                                {
                                    //delete current reminder
                                    Remove(reminder.ID);
                                    Debugger.Log("Reminders", "removed old reminder");
                                } else if (Count() == 1)
                                {
                                    //show messagebox
                                    MessageBox.Show("Finished the only reminder\nYou may stop now, or else the program will continue checking for reminders.", "Finished!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Debugger.Log("Reminders", "ONLY ONE REMINDER | not deleting");
                                }
                            }
                        }
                    } else //if you are in dnd mode
                    {
                        Debugger.Log("Reminders", "dnd mode");

                        //send notification
                        Form1.SendNotif(reminder.Text, reminder.Name);

                        //get next repeat
                        string nextRepeat = reminder.NextRepeat();

                        if (nextRepeat != null) //if there is a repeat
                        {
                            Debugger.Log("Reminders", $"found repeat: {reminder.Repeat}");

                            //setup datetime
                            string[] nextDateTime = nextRepeat.Split(' ');
                            string[] date = nextDateTime[0].Split('/');
                            string[] time = nextDateTime[1].Split(':');

                            DateTime reminderdatetime = new DateTime(Convertions.ToInt(date[2]), Convertions.ToInt(date[0]), Convertions.ToInt(date[1]), Convertions.ToInt(time[0]), Convertions.ToInt(time[1]), 0);

                            //delete current reminder
                            Remove(reminder.ID);
                            Debugger.Log("Reminders", "removed old reminder");

                            //create new one with new date
                            XElement newReminder = Generate(reminder.Name, reminder.Text, reminderdatetime, reminder.Repeat);
                            Add(newReminder);
                            Debugger.Log("Reminders", "made new reminder");

                            //create new settings for reminder
                            reminder.DateTime = reminderdatetime;
                            reminder.Ran = false;
                        }
                        else
                        {
                            Debugger.Log("Reminders", "no repeat | only once");

                            if (Count() > 1)
                            {
                                //delete current reminder
                                Remove(reminder.ID);
                                Debugger.Log("Reminders", "removed old reminder");
                            }
                            else if (Count() == 1)
                            {
                                //show messagebox
                                Form1.SendNotif("Finished the only reminder\nYou may stop now, or else the program will continue going checking for reminders.", "Finished!");
                                Debugger.Log("Reminders", "ONLY ONE REMINDER | not deleting");
                            }
                        }
                    }
                }
            }
        }

        internal static void Stop(bool ShowMessage = true)
        {
            if (!Running && ShowMessage) MessageBox.Show("The program is already stopped!", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                //set variable
                Running = false;

                //stop timer
                IntervalTimer.Stop();

                //reset variable
                Reminder[] empty = { };
                reminders = empty;

                //alternative method
                //Array.Clear(reminders, 0, reminders.Length);
            }
        }
    }

    public class Reminder
    {
        public Reminder(string name, string text, DateTime dateTime, string repeat, string id)
        {
            Name = name;
            Text = text;
            DateTime = dateTime;
            Repeat = repeat;
            ID = id;
            Ran = false;
        }

        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public string Repeat { get; set; }
        public bool Ran { get; set; }
        public string ID { get; set; }

        public string NextRepeat()
        {
            if (Repeat == "Once")
            {
                return null;
            }
            else if (Repeat == "Daily")
            {
                return DateTime.AddDays(1).ToString("MM/dd/yyyy HH:mm");
            }
            else if (Repeat == "Weekly")
            {
                return DateTime.AddDays(7).ToString("MM/dd/yyyy HH:mm");
            }
            else if (Repeat == "Monthly")
            {
                return DateTime.AddMonths(1).ToString("MM/dd/yyyy HH:mm");
            }
            else if (Repeat == "Yearly")
            {
                return DateTime.AddYears(1).ToString("MM/dd/yyyy HH:mm");
            } else
            {
                return null;
            }
        }
        public override string ToString()
        {
            return $"{ID}:" +
                $"\n   Name: {Name}" +
                $"\n   Text: {Text}" +
                $"\n   DateTime: {DateTime.ToString("MM/dd/yyyy HH:mm")}" +
                $"\n   Repeat: {Repeat}" +
                $"\n   Ran: {Ran}";
        }
    }

    public class XmlStuff
    {
        public XmlStuff() {
            Made = false;
        }

        public XmlStuff(XmlDocument doc, XmlNodeList nodeList)
        {
            Document = doc;
            NodeList = nodeList;
            Made = true;
        }

        public XmlDocument Document { get; set; }
        public XmlNodeList NodeList { get; set; }
        public bool Made { get; set; }
        /*
        public XmlNode GetFirstNode()
        {
            return NodeList.Item(0);
        }*/
    }
}
