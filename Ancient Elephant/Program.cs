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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Ancient Elephant: ");
            Console.ForegroundColor = ConsoleColor.White;




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
                            //CHANGED FROM HARD CODED TO "preferredDir". NEED TESTING.
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


            //const List<LocalExecutable> k = new List<LocalExecutable>();
            //const Process process = new Process();
            //Process[] pk = new Process[1];
            //pk.ToImmutableArray();


            //process.StartInfo.FileName = "C:\\Users\\User1\\Downloads\\winmine";
            //process.Start();
            //var info = process.HasExited;
            //var j = process.StartTime;

            //Console.WriteLine($"Has exited: {info}");
            //Console.WriteLine($"Start time: {j}");


            //Might want to stick with using "ProcessStartInfo" (it's much more potent).
            //ProcessStartInfo st = new ProcessStartInfo();
            //st.UseShellExecute = false; //If this is set to false, you must use the full path (aka "C:\Users\User1\Downloads\\winmine")
            ////instead of "winmine" when inserting it in "Process.Start() as the parameter.
            //st.WorkingDirectory = "C:\\Users\\User1\\Downloads\\";
            //st.CreateNoWindow = false;
            //st.FileName = "C:\\Users\\User1\\Downloads\\winmine";

            //----------


            //WARNING: You tried launching processes (specifically Powershell & Winmine). Powershell might be hidden in "Background Process"
            //instead of "Apps" (when looking from Task Manager). WOULD RECOMMNED AVOIDING FURTHER USE OF WINDOW HIDING!
            //st.UseShellExecute = true; //If this is set to false, you must use the full path (aka "C:\Users\User1\Downloads\\winmine")
            ////instead of "winmine" when inserting it in "Process.Start() as the parameter.
            //st.CreateNoWindow = false;
            //st.FileName = "C:\\Users\\User1\\Downloads\\winmine";
            //st.WindowStyle = ProcessWindowStyle.Maximized;

            //---

        }





    }
}