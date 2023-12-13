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
using Ancient_Elephant.Classes.Misc.Messages;
using Ancient_Elephant.Classes.SavePaths;
using Ancient_Elephant.Classes.IOSubOperations;

namespace Ancient_Elephant.Classes
{
    public class LocalExecutable
    {
        [Name("Process")]
        public string ProcessName { get; set; }

        [Name("Filepath")]
        public string FilePath { get; set; }

        [Name("Window Size")]
        public string WindowSize { get; set; }

        [Name("Execute")]
        public bool MarkedToExecute { get; set; }


        public LocalExecutable() { }

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

        /// <summary>
        /// Get a list of processes from a CSV file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>A list of processes (using their local file versions)</returns>
        public static List<LocalExecutable> GetProcessesFromCSVFile(string fileName) 
        {
            List<LocalExecutable> items = new();
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
                ExceptionMessages.PrintError("Error reading process(es) from CSV:", e.Message);
                items = new List<LocalExecutable>();
            }
            catch(CsvHelperException e) 
            {
                ExceptionMessages.PrintError("Error reading process(es) from CSV:", e.Message);
                items = new List<LocalExecutable>();
            }
            return items;
        }

        /// <summary>
        /// Launch executables.
        /// </summary>
        /// <param name="executables">A list of executables (using their local files versions).</param>
        public static void LaunchLocalExecutables(List<LocalExecutable> executables)
        {

            List<LocalExecutable> ProcsToExecute = executables.Where(e => e.MarkedToExecute == true).ToList();

            RunExesInfoMessages.BeginExecutionAttempt();
            try
            {
                foreach (var exe in ProcsToExecute)
                {
                    ProcessStartInfo st = LaunchProcOps.CreateProcessStartInfoUsingCSVFields(exe);
                    Process? ProcStartInfo = Process.Start(st);
                    try 
                    {
                        if (ProcStartInfo == null)
                        {
                            ExceptionMessages.FailedProcessLaunch(exe);
                        }
                        RunExesInfoMessages.SuccessfullyRunningProcInfo(ProcStartInfo);
                    }
                    catch(NullReferenceException e) 
                    {
                        ExceptionMessages.PrintError("An error starting process(es) from CSV:", e.Message);
                    }
                }
                RunExesInfoMessages.ExecutionAttemptsFinished();
            }
            catch(System.IO.IOException e) 
            {
                ExceptionMessages.PrintError("Error starting process(es) from CSV:", e.Message);
            }
            catch (System.ComponentModel.Win32Exception e) 
            {
                ExceptionMessages.PrintError("Error starting process(es) from CSV:", e.Message);
            }


            List<LocalExecutable> ProcsToExeclude = executables.Where(e => e.MarkedToExecute == false).ToList();
            if(ProcsToExeclude.Count >= 0) 
            {
                RunExesInfoMessages.ExcludedRunProcInfo(ProcsToExeclude);
            }
           

        }
    }
}
