using UnityEngine;

public static class GameStateManager 
{
    private static GameState lastState;
    private static GameState currentState;

    public static void UpdateGameState(GameState gameState)
    {
        lastState = currentState;
        currentState = gameState;

        currentState.HandleGameState();
    }

}
