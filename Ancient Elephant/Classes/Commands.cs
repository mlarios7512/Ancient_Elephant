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
            Console.WriteLine("\nText color key: \n" +
                "Yellow --> Command\n" +
                "White --> Normal text" +
                "\n\n\n");

            //----------------------------------------------------
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("launch [csv file]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Start processes from a CSV file. Files MUST be in CSV format.\n");

            //----------------------------------------------------
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("clear");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Clears the console.\n");

            //END OF COMMANDS LISTING---------------------
            Console.WriteLine("\n");
        }

    }
}
