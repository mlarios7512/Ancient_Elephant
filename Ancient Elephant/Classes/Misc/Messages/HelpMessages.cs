using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancient_Elephant.Classes.Misc.Messages
{
    public class HelpMessages
    {
        public static void ColorLegend() 
        {
            Console.WriteLine("\nHelp commands color key:");
            PrettyConsole.WriteHelpKeyColor("White", ConsoleColor.White, "Normal text");
            PrettyConsole.WriteHelpKeyColor("Yellow", ConsoleColor.DarkYellow, "Command");
            PrettyConsole.WriteHelpKeyColor("Blue", ConsoleColor.Blue, "Option");
            Console.WriteLine("\n\n");
        }

        public static void LaunchCommand()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("launch [csv file]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Start processes from a CSV file. Files MUST be in CSV format (xlsx & xls are NOT supported).\n");
        }

        public static void ClearConsoleCommand()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("clear");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Clears the console.\n");
        }

        public static void ChangePrefDir()
        {
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

            PrettyConsole.DisplayOptionsForCommand(ops);
        }

    }
}
