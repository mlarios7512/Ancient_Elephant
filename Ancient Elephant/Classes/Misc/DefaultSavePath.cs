using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Ancient_Elephant.Classes.Misc.Messages;
using Ancient_Elephant.Classes.SavePaths;


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
            try
            {
                SavePathMessages.EnterPreferredDir();
                string preferredDirectory = SavePathOps.CreatePrefDirFile();
                SavePathMessages.SaveSucessful();
                return preferredDirectory;
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
                const string DefaultSaveFileName = "preferredDir.json";

                //"AppContext.BaseDirectory" is where the directory of exe will be during the release version.
                var fileToCheckFor = Path.Combine(AppContext.BaseDirectory, DefaultSaveFileName);
                if (!File.Exists(fileToCheckFor))
                {
                    //Create file
                    SavePathMessages.NoPreferredDirFound();
                    return SavePathOps.CreatePrefDirFile();
                }
                else
                {
                    //Load as preferred directory
                    string preExistingPreference = LoadPreferredDirectoryFile();
                    SavePathMessages.LoadSuccessful();
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
