using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ancient_Elephant.Classes.Misc
{
    public class PrettyConsole
    {
        public static void ExeceptionError(string message, string execptionMessage) 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
            Console.WriteLine($"{execptionMessage}\n");
        }

        public static void HighlightText(bool post, string message, string uniqueText, ConsoleColor color) 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{message}");
            Console.ForegroundColor = color;
        }
    }
}
