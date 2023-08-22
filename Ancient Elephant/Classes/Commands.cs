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

        public static void HelpCommand()
        {

            //----------------------------------------------------
            Console.WriteLine("\nText color key:");
            PrettyConsole.WriteHelpKeyColor("White", ConsoleColor.White, "Normal text");
            PrettyConsole.WriteHelpKeyColor("Yellow", ConsoleColor.DarkYellow, "Command");
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


            //END OF COMMANDS LISTING---------------------
            Console.WriteLine("\n");
        }

    }
}
