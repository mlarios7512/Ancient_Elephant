using Ancient_Elephant.Classes.Misc;
using Ancient_Elephant.Classes.Misc.Messages;

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
        public static void LaunchFileProcesses(string fileName) 
        {
            List<LocalExecutable> exeList = LocalExecutable.GetProcessesFromCSVFile(fileName);
            LocalExecutable.LaunchLocalExecutables(exeList);
        }

        public static void ViewPreferredDir() 
        {
            try { 
                string path = DefaultSavePath.LoadPreferredDirectoryFile(); 
                Console.WriteLine($"Preferred path: {path}\n");
            }
            catch(Exception e) 
            {
                ExceptionMessages.PrintError("Error viewing preferred directory:", e.Message);
            }
        }

        public static string ChangePreferredDir() 
        {
            string newPreferredDir = "(NONE)";
            const string ErrorDir = "(NONE)";
            try 
            {
                return DefaultSavePath.SaveNewPreferredDir();
            }
            catch(UnauthorizedAccessException e) 
            {
                ExceptionMessages.PrintError("Error saving preferred directory: ", e.Message);
                Console.WriteLine("The preferred directory will only be active for this session.\n\n");
                return ErrorDir;
            }
            catch (Exception e) 
            {
                ExceptionMessages.PrintError("Error saving preferred directory", e.Message);
                Console.WriteLine("The preferred directory will only be active for this session.\n\n");
                return ErrorDir;
            }
        }

        public static void HelpCommand()
        {
            HelpMessages.ColorLegend();
            HelpMessages.LaunchCommand();
            HelpMessages.ClearConsoleCommand();
            HelpMessages.ChangePrefDir();
            Console.WriteLine("\n");
        }

    }
}
