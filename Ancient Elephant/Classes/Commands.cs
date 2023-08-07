using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancient_Elephant.Classes
{

    
    public class Commands
    {

        public static void PrintFileProcesses(string fileName) 
        {
            List<LocalExecutable> exeList = LocalExecutable.GetProcessesFromJsonFile(fileName);
            LocalExecutable.PrintLocalProcessesOnFile(exeList);
        }

        public static void LaunchFileProcesses(string fileName) 
        {
            List<LocalExecutable> exeList = LocalExecutable.GetProcessesFromJsonFile(fileName);
            LocalExecutable.LaunchLocalExecutables(exeList);
        }

        //public static void PrintAllCommands() 
        //{

        //}

    }
}
