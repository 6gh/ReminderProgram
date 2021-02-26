using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public static XDocument Generate()
        {
            XDocument doc = new XDocument();
            XElement root = new XElement("Reminders");
            doc.Add(root);

            XElement reminder = new XElement("Reminder", 
                new XAttribute("ID", OtherFunctions.NewReminderID()),
                new XElement("Title", "Reminder"),
                new XElement("Context", "Your reminder is now!"),
                new XElement("Time", "3:00"),
                new XElement("Date", "12/31/2021"),
                new XElement("Repeat", "Once")
            );
            doc.Element("Reminders").Add(reminder);

            return doc;
        }
    }
}
