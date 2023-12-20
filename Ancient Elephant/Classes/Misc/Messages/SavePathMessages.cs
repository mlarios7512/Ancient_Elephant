using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancient_Elephant.Classes.Misc.Messages
{
    public class SavePathMessages
    {
        const ConsoleColor SuccessIndication = ConsoleColor.Green;
        public static void EnterPreferredDir() 
        {
            Console.ResetColor();
            Console.Write("Enter new preferred directory: ");
        }
        public static void SaveSucessful() 
        {
            Console.ForegroundColor = SuccessIndication;
            Console.WriteLine("Preference saved.\n");
            Console.ResetColor();
        }

        public static void LoadSuccessful() 
        {
            Console.ForegroundColor = SuccessIndication;
            Console.WriteLine("Preferred directory file loaded.\n");
            Console.ResetColor();
        }

        public static void NoPreferredDirFound()
        {
            Console.ResetColor();
            Console.Write($"No preferred directory found. Enter preferred directory: ");
        }
        public static void ErrorSaving(System.UnauthorizedAccessException ex)
        {
            ExceptionMessages.PrintError($"Error saving preferred directory: ", ex.Message);
            Console.WriteLine("You will need to to specify a preferred directory before using this tool. " +
                "(See the 'help' command for how to do this.)");
        }
    }
}
