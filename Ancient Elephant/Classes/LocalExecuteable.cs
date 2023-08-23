using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using CsvHelper;
using System.Globalization;
using Ancient_Elephant.Classes.Misc;

namespace Ancient_Elephant.Classes
{
    public class LocalExecutable
    {
        [Name("Process")]
        public string ProcessName { get; set; }

        [Name("Filepath")]
        public string FilePath { get; set; }

        [Name("WindowSize")]
        private string WindowSize { get; set; }

        [Name("Execute")]
        public bool MarkedToExecute { get; set; }


        public LocalExecutable() { }

        public static void PrintProcessInfo(Process proc)
        {
            Console.WriteLine($"--------------PROCESS INFO----------------" +
                $"\n Name: {proc.ProcessName}" +
                $"\n ID: {proc.Id}");
           
        }

        //OLD VERSION (above)----------

        public static List<LocalExecutable> GetProcessesFromJsonFile(string fileName)
        {
            List<LocalExecutable> items = new List<LocalExecutable>();
            try
            {
                using (StreamReader r = new StreamReader(fileName))
                {
                    string json = r.ReadToEnd();
                    items = JsonConvert.DeserializeObject<List<LocalExecutable>>(json);
                }
            }
            catch (IOException e)
            {
                items = new List<LocalExecutable>();
                Console.WriteLine($"Error: {e.Message}");
            }

            return items;
        }

        public static List<LocalExecutable> GetProcessesFromCSVFile(string fileName) 
        {
            List<LocalExecutable> items = new List<LocalExecutable>();
            try
            {
                using (var streamReader = new StreamReader(fileName))
                {
                    using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                    {
                        items = csvReader.GetRecords<LocalExecutable>().ToList();
                    }
                }
            }
            catch (System.IO.IOException e)
            {
                PrettyConsole.ExeceptionError("Error reading process(es) from CSV:", e.Message);
                items = new List<LocalExecutable>();
            }
            catch(CsvHelperException e) 
            {
                PrettyConsole.ExeceptionError("Error reading process(es) from CSV:", e.Message);
                items = new List<LocalExecutable>();
            }
            return items;
        }

        /// <summary>
        /// Launch exes.
        /// </summary>
        /// <param name="executables">A list of executables (their local files versions).</param>
        public static void LaunchLocalExecutables(List<LocalExecutable> executables)
        {
            
            ProcessStartInfo st = null;

            List<LocalExecutable> ProcsToExecute = executables.Where(e => e.MarkedToExecute == true).ToList();

            Console.WriteLine("Launching processes...\n");
            try
            {
                foreach (var exe in ProcsToExecute)
                {
                    st = new ProcessStartInfo();
                    st.UseShellExecute = true;
                    st.WorkingDirectory = exe.FilePath;

                    string windowSizeInput = exe.WindowSize.ToLower();
                    switch (windowSizeInput) 
                    {
                        case "max":
                            st.WindowStyle = ProcessWindowStyle.Maximized;
                            break;
                        case "min":
                            st.WindowStyle = ProcessWindowStyle.Minimized;
                            break;
                        case "hidden":
                            st.WindowStyle = ProcessWindowStyle.Hidden;
                            break;
                        default:
                            st.WindowStyle = ProcessWindowStyle.Normal;
                            break;
                    }
                    

                    //MAYBE USE in a more advanced version (below)------------------------
                    //if (exe.FilePath == null) 
                    //{

                    //}
                    //else 
                    //{
                    //    st.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";
                    //}
                    //MAYBE USE in a more advanced version (above)------------------------
                    st.FileName = exe.ProcessName;
                    Process? ProcStartInfo = Process.Start(st);
                    try 
                    {
                        if (ProcStartInfo == null)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine($"The process {exe.ProcessName} failed to start\n");
                            Console.ResetColor();
                        }
                        PrintProcessInfo(ProcStartInfo);
                        
                    }
                    catch(NullReferenceException e) 
                    {
                        PrettyConsole.ExeceptionError("An error starting process(es) from CSV:", e.Message);
                    }


                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Finished launching processes.\n");
                Console.ResetColor();
            }
            catch(System.IO.IOException e) 
            {
                PrettyConsole.ExeceptionError("Error starting process(es) from CSV:", e.Message);
            }
            catch (System.ComponentModel.Win32Exception e) 
            {
                PrettyConsole.ExeceptionError("Error starting process(es) from CSV:", e.Message);
            }



            List<LocalExecutable> ProcsToExeclude = executables.Where(e => e.MarkedToExecute == false).ToList();
            if(ProcsToExeclude.Count >= 0) 
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Process not executed (purposefully marked to be skipped in CSV):");
                Console.ResetColor();
                int skippedProcIndex = 0;
                foreach(var skippedProc in ProcsToExeclude) 
                {
                    Console.WriteLine("{0,0}{1,30}", skippedProcIndex+1.ToString(), skippedProc.ProcessName);
                    skippedProcIndex++;
                }

                Console.WriteLine();
            }
           

        }
    }
}
