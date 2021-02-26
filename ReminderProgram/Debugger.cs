using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReminderProgram
{
    public class Debugger
    {
        private static FileStream fs = new FileStream(@"output.txt", FileMode.Create); //save to file in same dir
        private static StreamWriter sw = new StreamWriter(fs);
        private static TextWriter oldConsoleOut;
        private static int LogTimesRan = 0;

        public static bool running = false;
        public static bool LogMode = false;

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        // <summary>
        // Start Debugger
        // </summary>
        public static void Start()
        {
            Program.DebugMode = true;
            AllocConsole();
            Console.Title = "Simple Reminder Program | Debug Window";

            oldConsoleOut = Console.Out;

            //uncomment to enable log mode
            //ToggleLogMode();

            //Console.SetWindowSize(130, 20);
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine("\n\n   _____ _                 _        _____                _           _             _____                                     \n  / ____(_)               | |      |  __ \\              (_)         | |           |  __ \\                                    \n | (___  _ _ __ ___  _ __ | | ___  | |__) |___ _ __ ___  _ _ __   __| | ___ _ __  | |__) _ __ ___   __ _ _ __ __ _ _ __ ___  \n  \\___ \\| | '_ ` _ \\| '_ \\| |/ _ \\ |  _  // _ | '_ ` _ \\| | '_ \\ / _` |/ _ | '__| |  ___| '__/ _ \\ / _` | '__/ _` | '_ ` _ \\ \n  ____) | | | | | | | |_) | |  __/ | | \\ |  __| | | | | | | | | | (_| |  __| |    | |   | | | (_) | (_| | | | (_| | | | | | |\n |_____/|_|_| |_| |_| .__/|_|\\___| |_|  \\_\\___|_| |_| |_|_|_| |_|\\__,_|\\___|_|    |_|   |_|  \\___/ \\__, |_|  \\__,_|_| |_| |_|\n                    | |                                                                             __/ |                    \n                    |_|                                                                            |___/                     \n\n\n");
            Console.WriteLine("                                       ");
            Console.WriteLine("        Simple Reminder Program        ");
            Console.WriteLine("                                       ");
            Console.ResetColor();
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Debug mode is now active, this is only helpful");
            Console.WriteLine("When debugging, otherwise its pretty useless  ");
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\nStart Logging... ({OtherFunctions.GetCurrentDateTime()})");
            Console.ResetColor();
            Console.WriteLine();

            running = true;
        }

        internal static void ToggleLogMode()
        {
            if (!LogMode)
            {
                LogTimesRan++;
                Console.WriteLine("Activating Log Mode...");
                Console.SetOut(sw);
                LogMode = true;
                Console.WriteLine($"[{OtherFunctions.GetCurrentDateTime(true)}] Activated Log Mode");
            } else
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.WriteLine($"[{OtherFunctions.GetCurrentDateTime(true)}] Deactivating Log mode...");
                Console.WriteLine();
                Console.SetOut(oldConsoleOut);
                LogMode = false;
                Console.WriteLine($"[{OtherFunctions.GetCurrentDateTime(true)}] Dectivated Log Mode");
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        public static void Log(string name, string log)
        {
            if(Program.DebugMode)
            {
                Console.WriteLine($"[{OtherFunctions.GetCurrentDateTime()}] ({name}) {log}"); //log output
            }
        }

        public static void Error(string name, string log)
        {
            if (Program.DebugMode)
            {
                Console.BackgroundColor = ConsoleColor.Red;   //ooh
                Console.ForegroundColor = ConsoleColor.White; //cool colors
                Console.WriteLine();
                Console.WriteLine($"[{OtherFunctions.GetCurrentDateTime()}] ({name}) {log}"); //log
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        public static void Stop()
        {
            if (Program.DebugMode && running)
            {
                Console.BackgroundColor = ConsoleColor.DarkBlue;   //ooh more
                Console.ForegroundColor = ConsoleColor.White; //cool colors
                Console.WriteLine();
                Console.WriteLine($"[{OtherFunctions.GetCurrentDateTime()}] Stopping..."); 
                Console.WriteLine($"[{OtherFunctions.GetCurrentDateTime()}] Saving...");
                Console.SetOut(oldConsoleOut);
                sw.Close();
                Console.WriteLine($"[{OtherFunctions.GetCurrentDateTime()}] Saved."); 
                Console.WriteLine();
                Console.ResetColor();

                if (LogTimesRan == 0)
                {
                    File.Delete("output.txt");
                }
            }
        }
    }
}
