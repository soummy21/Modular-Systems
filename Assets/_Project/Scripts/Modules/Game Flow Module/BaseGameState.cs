//Base GameState Class to implement a state system for multiple game states

public abstract class GameState<T1, T2>
{
    private Message<T1, T2> GameMessage;

    public GameState(Message<T1, T2> GameMessage) => this.GameMessage = GameMessage;

    public virtual void HandleGameState(T1 messageData1, T2 messageData2) 
        => GameMessage.InvokeMessage(messageData1, messageData2);
}

public abstract class GameState<T>
{
    private Message<T> GameMessage;

    public GameState(Message<T> GameMessage) => this.GameMessage = GameMessage;

    public virtual void HandleGameState(T messageData) => GameMessage.InvokeMessage(messageData);
}

public abstract class GameState
{
    protected Message GameMessage;

    public GameState(Message GameMessage) => this.GameMessage = GameMessage;

    public virtual void HandleGameState() => GameMessage.InvokeMessage();
}
