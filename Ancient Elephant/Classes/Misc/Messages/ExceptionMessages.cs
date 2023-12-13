using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancient_Elephant.Classes.Misc.Messages
{
    public class ExceptionMessages
    {
        public static void PrintError(string message, string execptionMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
            Console.WriteLine($"{execptionMessage}\n");
        }

        public static void FailedProcessLaunch(LocalExecutable exe) 
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"The process {exe.ProcessName} failed to start\n");
            Console.ResetColor();
        }
    }
}
