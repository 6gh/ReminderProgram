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
            throw new NotImplementedException();
        }

        internal static void Stop()
        {
            throw new NotImplementedException();
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
