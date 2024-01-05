using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameContext : MonoBehaviour, IGameLocator, IGameMachine
{
    public GameState GameState => _gameStateMachine.GameState; 

    private readonly GameStateMachine _gameStateMachine = new();

    private readonly GameLocator _serviceLocator = new();
    
    private readonly List<IUpdateGameListener> _updateListeners = new();

    private void Awake()
    {
        enabled = false;
        DontDestroyOnLoad(this);

        _serviceLocator.AddService(this);
    }
    
    private void Update()
    {
        var deltaTime = Time.deltaTime;
        for (int i = 0, count = _updateListeners.Count; i < count; i++)
        {
            var listener = _updateListeners[i];
            listener.OnUpdate(deltaTime);
        }
    }

    public GameContext()
    {
        _serviceLocator.AddService(_gameStateMachine);
    }

    [ContextMenu("Start Game")]
    public void StartGame()
    {
        enabled = true;
        _gameStateMachine.StartGame();
    }
    
    public void RestartGame()
    {
        FinishGame();
        _gameStateMachine.RestartGame();
    }
    
    [ContextMenu("Finish Game")]
    public void FinishGame()
    {
        _gameStateMachine.FinishGame();
    }

    public void AddListener(object listener)
    {
        _gameStateMachine.AddListener(listener);
    }

    public void AddListeners(IEnumerable<object> listeners)
    {
        foreach (var listener in listeners)
        {
            AddListener(listener);
            if (listener is IUpdateGameListener updateListener)
            {
                _updateListeners.Add(updateListener);
            }
        }
    }

    public void RemoveListener(object listener)
    {
        _gameStateMachine.RemoveListener(listener);
    }
        
    public void AddService(object service)
    {
        _serviceLocator.AddService(service);
    }

    public void AddServices(IEnumerable<object> services)
    {
        _serviceLocator.AddServices(services);
    }

    public void RemoveService(object service)
    {
        _serviceLocator.RemoveService(service);
    }
    
    public T GetService<T>()
    {
        return _serviceLocator.GetService<T>();
    }
}