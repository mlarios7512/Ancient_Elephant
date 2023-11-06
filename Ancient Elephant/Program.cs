using System;
using System.Diagnostics;
using System.ComponentModel;
using Ancient_Elephant.Classes;
using Newtonsoft.Json;
using System.IO;
using System.Linq.Expressions;
using System.Collections.Immutable;
using Ancient_Elephant.Classes.Misc;
using System.Security.Permissions;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Ancient Elephant";

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===============================================\n" +
                          "||                                           ||");
        Console.WriteLine("||              Ancient Elephant             ||");
        Console.WriteLine("||                                           ||");
        Console.WriteLine("===============================================\n\n");

        Console.BackgroundColor = ConsoleColor.Black;
        Console.WriteLine("For a list of commands, type 'help'");

        string preferredDir = null;

        preferredDir = DefaultSavePath.CheckForPreferredDirOnStartUp();
        if(preferredDir == null) 
        {
            preferredDir = "(NONE)";
        }

       
        while (true)
        {
            PrettyConsole.StartLoopText();

            string cmdArg = Console.ReadLine();

            //---------------------------CORE LOGIC OF LOOP (below)-------------------------------------------------

            if (!String.IsNullOrEmpty(cmdArg))
            {
                string[] cmdInput = cmdArg.Split(' ');
                switch (cmdInput[0])
                {
                    case "launch":
                        if (cmdInput.Length == 2)
                        {
                            string fileName = cmdInput[1];
                            //CHANGED FROM HARD CODED TO "preferredDir". NEED TESTING.--- Something goes wrong within the command.
                            string fullPath = Path.Combine(preferredDir, fileName);

                            Commands.LaunchFileProcesses(fullPath);
                        }
                        break;
                    case "help":
                        // code block
                        Commands.HelpCommand();
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    case "preferreddir":
                        if (cmdInput[1] == "view")
                        {
                            Commands.ViewPreferredDir();
                        }
                        else if (cmdInput[1] == "change") 
                        {
                            preferredDir = Commands.ChangePreferredDir();
                        }
                        break;
                    default:
                        Console.WriteLine($"No command recognized. For a list of commands, type 'help'");
                        break;
                }
            }

            //---------------------------CORE LOGIC OF LOOP (above)-------------------------------------------------

        }





    }
}