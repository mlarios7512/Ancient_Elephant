using Ancient_Elephant.Classes.Misc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancient_Elephant.Classes
{

    
    public class Commands
    {
        public static void LaunchFileProcesses(string fileName) 
        {
            //List<LocalExecutable> exeList = LocalExecutable.GetProcessesFromJsonFile(fileName);
            //LocalExecutable.LaunchLocalExecutables(exeList);

            //--------
            List<LocalExecutable> exeList = LocalExecutable.GetProcessesFromCSVFile(fileName);
            LocalExecutable.LaunchLocalExecutables(exeList);
        }

        public static void ViewPreferredDir() 
        {
            try { 
                string path = DefaultSavePath.LoadPreferredDirectoryFile(); 
                Console.WriteLine($"Preferred path: {path}\n");
            }
            catch(Exception e) 
            {
                PrettyConsole.ExeceptionError("Error viewing preferred directory:", e.Message);
            }
        }

        public static void HelpCommand()
        {

            //----------------------------------------------------
            Console.WriteLine("\nHelp commands color key:");
            PrettyConsole.WriteHelpKeyColor("White", ConsoleColor.White, "Normal text");
            PrettyConsole.WriteHelpKeyColor("Yellow", ConsoleColor.DarkYellow, "Command");
            PrettyConsole.WriteHelpKeyColor("Blue", ConsoleColor.Blue, "Option");
            Console.WriteLine("\n\n");


            //----------------------------------------------------
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("launch [csv file]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Start processes from a CSV file. Files MUST be in CSV format (xlsx & xls are NOT supported).\n");

            //----------------------------------------------------
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("clear");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Clears the console.\n");

            //-------------------------------------------------
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("launchdir [directory path]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Change the path of the directory that is read to launch the CSV files from.\n");

            //-----------------------------------------------
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("preferreddir [option]");
            Console.ResetColor();
            //List<(string, string)> options = new List<(string, string)>();
            //(string, string) j = ("-view", "Show the current preferred directory.");
            //(string, string) k = ("-view", "Show the current preferred directory.");

            List<(string, string)> ops = new List<(string, string)>() 
            {
                ("view", "Show the current preferred directory."),
                ("change", "Change the current preferred directory")
            };



            PrettyConsole.WriteOptionsForCommand(ops);



            //END OF COMMANDS LISTING---------------------
            Console.WriteLine("\n");
        }

    }
}
