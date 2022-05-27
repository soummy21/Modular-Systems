using System.Collections.Generic;
using UnityEngine;

namespace _Project.Modules.Saving
{
    public static class SaveUtilities<SaveObject>
    {
        private static string classDataIdentifier = typeof(SaveObject).Name;

        public static void SaveDataClass(SaveObject classToSave)
        {
            //Debug.Log(classData);
            string classData = JsonUtility.ToJson(classToSave);
            PlayerPrefs.SetString(classDataIdentifier, classData);
            
        }

        public static SaveObject LoadDataClass()
        {

            if (!PlayerPrefs.HasKey(classDataIdentifier))
                return default;

            string savedClass = PlayerPrefs.GetString(classDataIdentifier);
            return JsonUtility.FromJson<SaveObject>(savedClass);
        }
    }
}


