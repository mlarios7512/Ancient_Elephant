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
            catch(IOException e) 
            {
                Console.WriteLine($"Error message: {e}");
                items = new List<LocalExecutable>();
            }
            catch(CsvHelperException c) 
            {
                Console.WriteLine($"Error message: {c}");
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

            foreach (var exe in executables)
            {
                st = new ProcessStartInfo();
                st.UseShellExecute = true;
                st.WorkingDirectory = exe.FilePath;
                st.FileName = Path.Combine(exe.FilePath, exe.ProcessName);
                Process.Start(st);
            }
        }
    }
}
