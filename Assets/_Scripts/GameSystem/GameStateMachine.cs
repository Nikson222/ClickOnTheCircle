using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameStateMachine : IGameMachine
{
    private readonly List<object> _listeners = new();

    private GameState _gameState = GameState.OFF;
    public GameState GameState => _gameState;

    [ContextMenu("Start Game")]
    public void StartGame()
    {
        if (_gameState != GameState.OFF)
        {
            Debug.LogWarning($"You can start game only from {GameState.OFF} state!");
            return;
        }

        _gameState = GameState.START;

        foreach (var listener in _listeners)
        {
            if (listener is IGameStartListener startListener)
                startListener.OnGameStart();
        }
    }

    [ContextMenu("Finish Game")]
    public void FinishGame()
    {
        if (_gameState != GameState.START)
        {
            Debug.LogWarning($"You can finish game only from {GameState.START} state!");
            return;
        }

        _gameState = GameState.FINISH;

        foreach (var listener in _listeners)
        {
            if (listener is IGameFinishListener finishListener)
                finishListener.OnGameFinish();
        }
    }
    
    [ContextMenu("Restart Game")]
    public void RestartGame()
    {
        if (_gameState != GameState.FINISH)
        {
            Debug.LogWarning($"You can finish game only from {GameState.FINISH} state!");
            return;
        }

        _gameState = GameState.START;

        foreach (var listener in _listeners)
        {
            if (listener is IGameStartListener finishListener)
                finishListener.OnGameStart();
        }
    }
    
    public void AddListener(object listener) => _listeners.Add(listener);

    public void AddListeners(IEnumerable<object> listeners)
    {
        _listeners.AddRange(listeners);
    }


    public void RemoveListener(object listener) => _listeners.Remove(listener);
}