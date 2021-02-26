using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ReminderProgram
{
    public class OtherFunctions
    {
        public static string NewReminderID()
        {
            Random rand = new Random();
            int value = rand.Next(1000);

            return value.ToString("000");
        }

        public static bool ValidXML(string path)
        {
            try
            {
                XDocument doc = XDocument.Load(path);
                if (doc.Root != null) return true;
                else return false;
            } catch (Exception e)
            {
                Debugger.Error("ValidXML", e.Message);
                return false;
            }
        }

        public static bool ValidTime(string value)
        {
            try
            {
                string time = DateTime.Parse(value).ToString("HH:mm.ss");
                if (ValidString(time)) return true;
                else return false;
            } catch (Exception e)
            {
                Debugger.Error("ValidTime", e.Message);
                return false;
            }
        }

        public static bool ValidDate(string value)
        {
            try
            {
                string date = DateTime.Parse(value).ToString("MM/dd/yyyy");
                if (ValidString(date)) return true;
                else return false;
            }
            catch (Exception e)
            {
                Debugger.Error("ValidDate", e.Message);
                return false;
            }
        }

        public static bool ValidString(string value)
        {
            if (value != null)
            {
                if (value.Length > 0) return true;
                else return false;
            }
            else return false;
        }

        public static string GetCurrentDateTime(bool yon = false)
        {
            if(yon)
            {
                return DateTime.Now.ToString("dd/MM/yyyy HH:mm.ss.ff");
            }
            else
            {
                return DateTime.Now.ToString("dd/MM/yyyy @ HH:mm.ss");
            }
        }
    }
}
