//Holds GameStates and GameMessages for access during Updation of GameState and adding listeners to GameMessages
public static class GameStates
{
    #region GAME STATES
    public static GameInitializedState GameInitializedState = new GameInitializedState(GameMessages.GameInitializedMessage);
    public static GamePausedState GamePausedState = new GamePausedState(GameMessages.GamePausedMessage);
    public static MainMenuState MainMenuState = new MainMenuState(GameMessages.MainMenuMessage);
    public static LoadLevelState LoadLevelState = new LoadLevelState(GameMessages.LoadLevelMessage);
    public static LevelStartedState LevelStartedState = new LevelStartedState(GameMessages.LevelStartedMessage);
    public static LevelFinishedState LevelFinishedState = new LevelFinishedState(GameMessages.LevelFinishedMessage);
    #endregion

}
public enum Result { VICTORY, DEFEAT };


