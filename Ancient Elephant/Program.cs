using System;
using System.Diagnostics;
using System.ComponentModel;
using Ancient_Elephant.Classes;
using Newtonsoft.Json;
using System.IO;
using System.Linq.Expressions;

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
        Console.WriteLine("For a list of commands, use '--help'");

        const string defaultFilePath = "C:\\Users\\User1\\Documents\\THE DUMP";




        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Ancient Elephant: ");
            Console.ForegroundColor = ConsoleColor.White;




            string cmdArg = Console.ReadLine();

            //            if (!String.IsNullOrEmpty(cmdArg))
            //            {
            //                string[] cmdInput = cmdArg.Split(' ');
            //                switch (cmdInput[0])
            //                {
            //                    case "ProcFile":
            //                        if(cmdInput.Length == 3)
            //                        {
            //                            string fileName = cmdInput[1];
            //                            string actionOnFile = cmdInput[2];

            //                            string fullPath = Path.Combine("C:\\Users\\User1\\Documents\\THE DUMP", fileName);

            //                            switch (actionOnFile)
            //                            {
            ////                                case "-read":
            ////                                    Commands.PrintFileProcesses(fullPath);
            ////                                    break;

            ////                                case "-launch":
            ////.                                   Commands.LaunchFileProcesses(fullPath);
            ////                                    break;


            //                                case "-read":
            //                                    Commands.PrintFileProcesses(fullPath);
            //                                    break;
            //                                case "-launch":
            //                                    Commands.LaunchFileProcesses(fullPath);
            //                                    break;
            //                            }



            //                        }
            //                        else if(cmdInput.Length == 2)
            //                        {
            //                            string fullPath = Path.Combine("C:\\Users\\User1\\Documents\\THE DUMP", cmdInput[1]);
            //                            Commands.PrintFileProcesses(fullPath);
            //                        }
            //                        else
            //                        {
            //                            Console.WriteLine("Command not recognized.");
            //                        }
            //                        break;
            //                    case "":
            //                        // code block
            //                        break;
            //                    default:
            //                        Console.WriteLine($"No command recognized. For a list of commands, type '--help'");
            //                        break;
            //                }
            //            }

            //Might want to stick with using "ProcessStartInfo" (it's much more potent).
            ProcessStartInfo st = new ProcessStartInfo();
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

            st.UseShellExecute = true; //If this is set to false, you must use the full path (aka "C:\Users\User1\Downloads\\winmine")
                                       //instead of "winmine" when inserting it in "Process.Start() as the parameter.

            st.FileName = "Powershell";
            //st.Arguments = "cd \"C:\\Users\\User1\\Documents\\Personal Projects\\Tutorials\"";
            st.ArgumentList.Add("dir");


            st.WindowStyle = ProcessWindowStyle.Normal;





            Process.Start(st);

        }





    }
}