using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ReminderProgram
{
    public class OtherFunctions
    {
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

        public static bool ValidTime(DateTime value)
        {
            try
            {
                string time = value.ToString("HH:mm.ss");
                if (ValidString(time)) return true;
                else return false;
            }
            catch (Exception e)
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

        public static bool ValidDate(DateTime value)
        {
            try
            {
                string date = value.ToString("MM/dd/yyyy");
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

        internal static void ToggleStartup(bool value)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (Properties.Settings.Default.RunOnStartup != value)
            {
                Properties.Settings.Default.RunOnStartup = value;
                Properties.Settings.Default.Save();
            }

            if(Properties.Settings.Default.RunOnStartup)
            {
                key.SetValue("ReminderProgram", Application.ExecutablePath);
            } 
            else
            {
                string[] names = key.GetValueNames();

                if (Array.IndexOf(names, "ReminderProgram") > -1)
                {
                    key.DeleteValue("ReminderProgram", false);
                }
            }
        }
    }
}
