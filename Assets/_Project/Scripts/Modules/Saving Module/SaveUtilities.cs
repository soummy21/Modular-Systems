using UnityEngine;
using System.IO;

namespace SoummySDK.Saving
{
    // SaveUtilies is responsible to convert Any Serializable Class Type into a JSON and store it as well as retrive it for persistant data applications

    public static class SaveUtilities<SaveObject> where SaveObject : class
    {
        private static string classDataIdentifier = typeof(SaveObject).Name;
        //Change this to true to print to console -> For Debugging
        private static bool printLoadedDataToConsole = false;
        private static bool writeSavedDataToTextFile = false;

        //Write Saved File To Text -> For Debugging
        private static string saveFileDirectory = Application.dataPath + "/SavedDataFiles/";
        private static string saveFilePath = saveFileDirectory + classDataIdentifier + ".txt";
        private static void SaveToFile(string sessionSavedData)
        {
            if (!Directory.Exists(saveFileDirectory)) Directory.CreateDirectory(saveFileDirectory);
            if (!File.Exists(saveFilePath))
            {
                File.Create(saveFilePath);
                File.WriteAllText(saveFilePath, sessionSavedData);
            }
            else File.AppendAllText(saveFilePath, sessionSavedData);

        }

        public static void SaveDataClass(SaveObject classToSave)
        {
            string classData = JsonUtility.ToJson(classToSave);
            PlayerPrefs.SetString(classDataIdentifier, classData);
            if(writeSavedDataToTextFile) SaveToFile(classData);

        }
        public static SaveObject LoadDataClass()
        {
            if(!PlayerPrefs.HasKey(classDataIdentifier))
            {
                if(printLoadedDataToConsole) Debug.Log(classDataIdentifier + " { savedDataFileFound : false, firstTimeLoad : true }");
                if (writeSavedDataToTextFile && File.Exists(saveFilePath)) File.Delete(saveFilePath);
                return default;
            }

            string savedClass = PlayerPrefs.GetString(classDataIdentifier);
            if (printLoadedDataToConsole) Debug.Log(savedClass);
            return JsonUtility.FromJson<SaveObject>(savedClass);
        }

        
    }
}


