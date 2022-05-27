using UnityEngine;
using UnityEngine.SceneManagement;
using _Project.Modules.Saving;

// Master Data is the global persistant data file for the game/project. 

public static class MasterData
{
    //---------------------------DataFiles -------------------------------

    //Economy 
    public static Economy GameEconomy;
    //Player_Progress
    public static PlayerProgress PlayerProgress;
    //Settings
    public static Settings GameSettings;
    //Purchasing
    public static Purchasing Purchasing;
    //--------------------------------------------------------------------

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void LoadSavedGameData()
    {
        var SavedGameEconomy = SaveUtilities<Economy>.LoadDataClass();
        GameEconomy = SavedGameEconomy == null ? new Economy() : SavedGameEconomy;

        var SavedPlayerProgress = SaveUtilities<PlayerProgress>.LoadDataClass();
        PlayerProgress = SavedPlayerProgress == null ? new PlayerProgress() : SavedPlayerProgress;

        var SavedGameSettings = SaveUtilities<Settings>.LoadDataClass();
        GameSettings = SavedGameSettings == null ? new Settings() : SavedGameSettings;

        var SavedPurchasing = SaveUtilities<Purchasing>.LoadDataClass();
        Purchasing = SavedPurchasing == null ? new Purchasing() : SavedPurchasing;

    }

    public static void SaveGameData()
    {
        SaveUtilities<Economy>.SaveDataClass(GameEconomy);
        SaveUtilities<PlayerProgress>.SaveDataClass(PlayerProgress);
        SaveUtilities<Settings>.SaveDataClass(GameSettings);
    }
    
}

[System.Serializable]
public class Economy
{
    //Default Economy
    public Economy() { }

    //Actual Data
    [SerializeField] private int inGameCurrency = 0;

    //Accessable Data
    public int InGameCurrency
    {
        get => inGameCurrency;
        set
        {
            inGameCurrency = value;
            //Invoke OnCurrencyChange Event
        }
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

[System.Serializable]
public class Settings
{
    public Settings() { }

    public bool Vibrations = false;
    public bool Audio = false;

}

[System.Serializable]
public class Purchasing
{
    public Purchasing() { }

    [SerializeField] private bool subscriptionActivated;

    public bool SubscriptionActivated
    {
        get => subscriptionActivated;
        set
        {
            subscriptionActivated = value;
            //Run Event To Notify Ad Handler of the change
        }
    }
}

