using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancient_Elephant.Classes.IOSubOperations
{
    public class LaunchProcOps
    {
        public static ProcessStartInfo CreateProcessStartInfoUsingCSVFields(LocalExecutable exe) 
        {
            ProcessStartInfo stInfo = new ProcessStartInfo();
            stInfo.UseShellExecute = true;
            stInfo.WorkingDirectory = exe.FilePath;

            string windowSizeInput = exe.WindowSize.ToLower();
            switch (windowSizeInput)
            {
                case "max":
                    stInfo.WindowStyle = ProcessWindowStyle.Maximized;
                    break;
                case "min":
                    stInfo.WindowStyle = ProcessWindowStyle.Minimized;
                    break;
                case "hidden":
                    stInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    break;
                default:
                    stInfo.WindowStyle = ProcessWindowStyle.Normal;
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
            stInfo.FileName = exe.ProcessName;
            return stInfo;
        }
    }
}
