using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Ancient_Elephant.Classes.Misc.Messages;

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
                SavePathMessages.EnterPreferredDir();
                string newPreferredDir = Console.ReadLine();

                DefaultSavePath defaultDirAsJSON = new DefaultSavePath()
                {
                    PreferredPath = newPreferredDir
                };
                string jsonResult = JsonConvert.SerializeObject(defaultDirAsJSON);

                File.WriteAllText(Path.Combine(AppContext.BaseDirectory, defaultSaveFileName), jsonResult);
                SavePathMessages.SaveSucessful();
                return newPreferredDir;
            }
            catch(System.UnauthorizedAccessException ex) 
            {
                ExceptionMessages.PrintError($"Error saving preferred directory: ", ex.Message);
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
                    SavePathMessages.NoPreferredDirFound();
                    string preferredDir = Console.ReadLine();

                    DefaultSavePath defaultDirAsJSON = new DefaultSavePath()
                    {
                        PreferredPath = preferredDir
                    };
                    string jsonResult = JsonConvert.SerializeObject(defaultDirAsJSON);


                    File.WriteAllText(Path.Combine(AppContext.BaseDirectory, defaultSaveFileName), jsonResult);
                    SavePathMessages.SaveSucessful();
                    return preferredDir;
                }
                else
                {
                    //Load as preferred directory
                    string preExistingPreference = LoadPreferredDirectoryFile();
                    SavePathMessages.SaveSucessful();
                    return preExistingPreference;
                }
            }
            catch (System.UnauthorizedAccessException ex)
            {
                SavePathMessages.ErrorSaving(ex);
                return null;
            }
        }
    }
}
