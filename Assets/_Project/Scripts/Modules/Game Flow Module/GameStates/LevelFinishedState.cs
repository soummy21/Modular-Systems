

public class LevelFinishedState : GameState<Result>
{
    public LevelFinishedState(Message<Result> GameMessage) : base(GameMessage)
    {
    }

    public override void HandleGameState(Result messageData)
    {
        base.HandleGameState(messageData);

        if(messageData == Result.DEFEAT) { }

        if(messageData == Result.VICTORY) { }

    }
}