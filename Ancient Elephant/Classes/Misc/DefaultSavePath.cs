using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Ancient_Elephant.Classes.Misc
{
    public class DefaultSavePath
    {
        public string PreferredPath { get; set; }

        public DefaultSavePath() { }

        public static string LoadPreferredDirectoryFile() 
        {
            var pathOfSaveFile = Path.Combine(AppContext.BaseDirectory, "preferredDir.json");
            JObject? j = JObject.Parse(File.ReadAllText(pathOfSaveFile));
            string sanity = (string)j?.SelectToken("PreferredPath");
            return sanity;
        }

        public static string SaveNewPreferredDir() 
        {
            const string defaultSaveFileName = "preferredDir.json";

            //"AppContext.BaseDirectory" is where the directory of exe will be during the release version.
            var fileToCheckFor = Path.Combine(AppContext.BaseDirectory, defaultSaveFileName);

            try
            {
                Console.ResetColor();
                Console.Write("Enter new preferred directory: ");
                string newPreferredDir = Console.ReadLine();

                DefaultSavePath defaultDirAsJSON = new DefaultSavePath()
                {
                    PreferredPath = newPreferredDir
                };
                string jsonResult = JsonConvert.SerializeObject(defaultDirAsJSON);

                File.WriteAllText(Path.Combine(AppContext.BaseDirectory, defaultSaveFileName), jsonResult);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Preference saved.\n");
                Console.ResetColor();
                return newPreferredDir;
            }
            catch(System.UnauthorizedAccessException ex) 
            {
                PrettyConsole.ExeceptionError($"Error saving preferred directory: ", ex.Message);
                return null;
            }
        }

        public static string CheckForPreferredDirOnStartUp() 
        {
            try
            {
                const string defaultSaveFileName = "preferredDir.json";

                //"AppContext.BaseDirectory" is where the directory of exe will be during the release version.
                var fileToCheckFor = Path.Combine(AppContext.BaseDirectory, defaultSaveFileName);
                //CHECK FOR DEFAULT FILE PATH
                if (!File.Exists(fileToCheckFor))
                {
                    //Create file
                    Console.ResetColor();
                    Console.Write($"No preferred directory found. Enter preferred directory: ");
                    string preferredDir = Console.ReadLine();

                    DefaultSavePath defaultDirAsJSON = new DefaultSavePath()
                    {
                        PreferredPath = preferredDir
                    };
                    string jsonResult = JsonConvert.SerializeObject(defaultDirAsJSON);


                    File.WriteAllText(Path.Combine(AppContext.BaseDirectory, defaultSaveFileName), jsonResult);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Preference saved.\n");
                    Console.ResetColor();
                    return preferredDir;
                }
                else
                {
                    //Load as preferred directory
                    string preExistingPreference = LoadPreferredDirectoryFile();


                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Preferred directory loaded.\n");
                    Console.ResetColor();
                    return preExistingPreference;
                }
            }
            catch (System.UnauthorizedAccessException ex)
            {
                PrettyConsole.ExeceptionError($"Error saving preferred directory: ", ex.Message);
                Console.WriteLine("You will need to to specify a preferred directory before using this tool. " +
                    "(See the 'help' command for how to do this.)");
                return null;
            }
        }
    }
}
