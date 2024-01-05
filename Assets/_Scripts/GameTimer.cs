using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour, IGameStartListener, IGameFinishListener
{
    [SerializeField] private int _availableGameTime;
    private GameStateMachine _gameStateMachine;
    private float _timer;

    private bool _isActive = false;

    public void Construct(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    private void Start()
    {
        _timer = _availableGameTime;
    }

    private void Update()
    {
        if (_isActive)
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
            }
            else
            {
                _gameStateMachine.FinishGame();
            }
        }
    }

    public void OnGameStart()
    {
        _isActive = true;
    }

    public void OnGameFinish()
    {
        _isActive = false;
    }
}