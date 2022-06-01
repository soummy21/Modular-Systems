//Base GameState Class to implement a state system for multiple game states
using SoummySDK.Messaging;

namespace SoummySDK.GameStateMachine.Backend
{
    public abstract class BaseGameState<T1, T2>
    {
        private Message<T1, T2> GameMessage;

        public BaseGameState(Message<T1, T2> GameMessage) => this.GameMessage = GameMessage;

        public virtual void HandleGameState(T1 messageData1, T2 messageData2)
            => GameMessage.InvokeMessage(messageData1, messageData2);
    }

    public abstract class BaseGameState<T>
    {
        private Message<T> GameMessage;

        public BaseGameState(Message<T> GameMessage) => this.GameMessage = GameMessage;

        public virtual void HandleGameState(T messageData) => GameMessage.InvokeMessage(messageData);
    }

    public abstract class BaseGameState
    {
        protected Message GameMessage;

        public BaseGameState(Message GameMessage) => this.GameMessage = GameMessage;

        public virtual void HandleGameState() => GameMessage.InvokeMessage();
    }
}



