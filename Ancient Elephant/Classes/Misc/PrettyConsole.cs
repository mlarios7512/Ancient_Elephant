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
        public static void InputPromptText()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Ancient Elephant: ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //public static void ExeceptionError(string message, string execptionMessage) 
        //{
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    Console.WriteLine($"\n{message}");
        //    Console.ResetColor();
        //    Console.WriteLine($"{execptionMessage}\n");
        //}

        public static void HighlightText(bool post, string message, string uniqueText, ConsoleColor color) 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{message}");
            Console.ForegroundColor = color;
        }

        public static void WriteHelpKeyColor(string colorName, ConsoleColor keyColor, string commandDescription)
        {
            Console.ForegroundColor = keyColor;
            Console.Write($"{colorName}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" --> {commandDescription}\n");
        }

        public static void DisplayOptionsForCommand(List<(string, string)> options) 
        {
            Console.WriteLine("options:");
            foreach(var op in options) 
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(op.Item1);
                Console.ResetColor();
                Console.WriteLine($": {op.Item2}");
            }
        }
      
    }
}
