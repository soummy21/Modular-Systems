//-------To hold game messages for the project------//
using SoummySDK.Messaging;

public class GameMessages
{
    //Default GameMessages
    public static readonly Message GameInitializedMessage = new Message();
    public static readonly Message MainMenuMessage = new Message();
    public static readonly Message GamePausedMessage = new Message();

    //Level-Based GameMessages
    public static readonly Message<int, int> LoadLevelMessage = new Message<int, int>(); //Takes levelToUnload, levelToLoad
    public static readonly Message LevelStartedMessage = new Message();
    public static readonly Message<Result> LevelFinishedMessage = new Message<Result>();  //Takes Level Result
}

public class ManagerMessages
{
    public static readonly Message<int> OnEconomyUpdate = new Message<int>();
}


