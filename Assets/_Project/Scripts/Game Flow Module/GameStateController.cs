using SoummySDK.GameStateMachine.Backend;

namespace SoummySDK.GameStateMachine
{
    public static class GameStateController
    {
        private static BaseGameState currentState;

        public static void UpdateGameState(BaseGameState gameState)
        {
            currentState = gameState;
            currentState.HandleGameState();
        }
    }

    public static class GameStateController<T>
    {
        private static BaseGameState<T> currentState;

        public static void UpdateGameState(BaseGameState<T> gameState, T data)
        {
            currentState = gameState;
            currentState.HandleGameState(data);
        }
    }

    public static class GameStateController<T1, T2>
    {
        private static BaseGameState<T1, T2> currentState;

        public static void UpdateGameState(BaseGameState<T1, T2> gameState, T1 data1, T2 data2)
        {
            currentState = gameState;
            currentState.HandleGameState(data1, data2);
        }


    }
}



