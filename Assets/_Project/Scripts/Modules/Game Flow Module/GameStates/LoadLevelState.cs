using SoummySDK.Messaging;

namespace SoummySDK.GameStateMachine.Backend
{
    public class LoadLevelState : BaseGameState<int, int>
    {
        public LoadLevelState(Message<int, int> GameMessage) : base(GameMessage)
        {
        }
    }
}



