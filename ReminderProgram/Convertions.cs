using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ReminderProgram
{
    public class Convertions
    {
        /// <summary>
        /// Changes string to integer
        /// </summary>
        /// <param name="value"></param>
        /// <returns>int</returns>
        public static int ToInt(string value)
        {
            try
            {
                return Int32.Parse(value);
            } catch (Exception e)
            {
                Debugger.Error("Convert.ToInt", e.Message);
                return -1;
            }
        }

        internal static XmlNode ToXmlNode(XElement xElement)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xElement.ToString());

            XmlNode node = doc.FirstChild;
            return node;
        }
    }
}
