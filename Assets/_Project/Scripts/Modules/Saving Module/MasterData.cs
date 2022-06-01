using UnityEngine;
using UnityEngine.SceneManagement;
using SoummySDK.Saving;
// Master Data is the global persistant data file for the game/project. 

public static class MasterData
{
    public static PlayerProgress PlayerProgress;
    private static void LoadSavedGameData()
    {
        var SavedPlayerProgress = SaveUtilities<PlayerProgress>.LoadDataClass();
        PlayerProgress = SavedPlayerProgress == null ? new PlayerProgress() : SavedPlayerProgress;

    }

    public static void SaveGameData()
    {
        SaveUtilities<PlayerProgress>.SaveDataClass(PlayerProgress);
    }
    
}


[System.Serializable]
public class PlayerProgress
{
    //Default PlayerProgress
    public PlayerProgress() { }

    //Actual Data
    [SerializeField] private int currentMapToLoad = 1;
    [SerializeField] private int currentLevel = 1;

    public int CurrentMapToLoad => currentMapToLoad; //For Scene Loading
    public int CurrentLevel
    {
        get => currentLevel;
        set
        {
            int totalMaps = SceneManager.sceneCountInBuildSettings - 1;
            if (totalMaps <= 0)
            {
                Debug.LogWarning("Incorrect Build Settings For Build, No Maps Detected \n IGONORE IF TESTING INDEPENDENT LEVEL");
                return;
            }
            currentLevel = value;
            currentMapToLoad = (currentLevel % totalMaps) == 0 ? totalMaps : (currentLevel % totalMaps);
        }
    } //For the UI
}
