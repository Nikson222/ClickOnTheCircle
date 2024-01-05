using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Task «Start Game»", menuName = "GameTasks/Task «Start Game»")]
public sealed class GameTask_StartGame : GameTask
{
    public override Task Do()
    {
        var gameContext = GameObject
                .FindGameObjectWithTag("GAME_CONTEXT")
                .GetComponent<GameContext>();

        if(gameContext.GameState == GameState.OFF)
            gameContext.StartGame();
        else if(gameContext.GameState == GameState.FINISH)
            gameContext.RestartGame();
        
        return Task.CompletedTask;
    }
}