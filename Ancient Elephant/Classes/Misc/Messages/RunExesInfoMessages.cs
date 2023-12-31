﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Ancient_Elephant.Classes.Misc.Messages
{
    public class RunExesInfoMessages
    {
        public static void SuccessfullyRunningProcInfo(Process proc)
        {
            Console.WriteLine("{0,-30}{1,-30}{2,-10}", proc.ProcessName, proc.StartTime, proc.Id);
        }
        public static void ExcludedRunProcInfo(List<LocalExecutable?> skippedProcs)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Process not executed (purposefully marked to be skipped in CSV):");
            Console.ResetColor();

            for (int procIndex = 0; procIndex < skippedProcs.Count; procIndex++)
            {
                Console.WriteLine("{0,0}{1,30}", procIndex+1.ToString(), skippedProcs.ElementAt(procIndex).ProcessName);
            }

            Console.WriteLine();
        }

        public static void ExecutionAttemptsFinished() 
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Finished launching processes.\n");
            Console.ResetColor();
        }

        public static void BeginExecutionAttempt()
        {
            Console.WriteLine("Launching processes...\n\n");
            Console.WriteLine("{0,-30}{1,-30}{2,-10}", "Process", "Start time", "Process ID");
        }
    }
}
