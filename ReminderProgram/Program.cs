using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReminderProgram
{
    static class Program
    {
        public static bool DebugMode = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Parse Arguments given to program

            foreach(string arg in args)
            {
                if(arg == "/debug")
                {
                    // Start Debugger
                    Debugger.Start();
                }
                if(arg == "/setup")
                {
                    Properties.Settings.Default.FirstTime = true;
                    Properties.Settings.Default.Save();
                }
            }

            if (Properties.Settings.Default.FirstTime)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FirstTimeSetup());
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
