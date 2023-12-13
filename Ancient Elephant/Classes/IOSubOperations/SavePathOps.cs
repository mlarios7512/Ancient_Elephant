using Ancient_Elephant.Classes.Misc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancient_Elephant.Classes.SavePaths
{
    public class SavePathOps
    {
        public static string CreatePrefDirFile() 
        {
            string newPreferredDir = Console.ReadLine();

            DefaultSavePath defaultDirAsJSON = new DefaultSavePath()
            {
                PreferredPath = newPreferredDir
            };
            string jsonResult = JsonConvert.SerializeObject(defaultDirAsJSON);

            const string DefaultSaveFileName = "preferredDir.json";
            File.WriteAllText(Path.Combine(AppContext.BaseDirectory, DefaultSaveFileName), jsonResult);

            return newPreferredDir;
        }
    }
}
