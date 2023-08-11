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

namespace Ancient_Elephant.Classes
{
    public class LocalExecutable
    {
        private int launchIndex { get; set; }
        private string fullPath { get; set; }
        private string fileName { get; set; }
        private bool markedToExecute { get; set; }

        public int LaunchIndex
        {
            get { return launchIndex; }
            set { launchIndex = value; }
        }

        public string FullPath
        {
            get { return fullPath; }
            set { fullPath = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        public bool MarkedToExecute
        {
            get { return markedToExecute; }
            set { markedToExecute = value; }
        }


        public LocalExecutable() { }

        public static void PrintProcessInfo(Process proc)
        {
            Console.WriteLine($"--------------PROCESS INFO----------------" +
                $"\n Name: {proc.ProcessName}" +
                $"\n ID: {proc.Id}");
        }

        //OLD VERSION (above)----------


        public static void PrintLocalProcessesOnFile(List<LocalExecutable> executables)
        {
            int even = 0;
            foreach (var exe in executables)
            {
                if (even % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }

                Console.WriteLine($"\n\n--------------PROCESS INFO----------------" +
                $"\n Name: {exe.launchIndex}" +
                $"\n Filename: {exe.FileName}" +
                $"\n Full path: {exe.FullPath}" +
                $"\n Marked to execute: {exe.MarkedToExecute} \n");
                even++;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }



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
        /// Launch exes.
        /// </summary>
        /// <param name="executables">A list of executables (their local files versions).</param>
        public static void LaunchLocalExecutables(List<LocalExecutable> executables)
        {
            ProcessStartInfo st = null;

            foreach (var exe in executables)
            {
                st = new ProcessStartInfo();

                st.WorkingDirectory = exe.FullPath;
                st.FileName = exe.FileName;
                Process.Start(exe.fileName, exe.FullPath);

      

         

            }
        }
    }
}
