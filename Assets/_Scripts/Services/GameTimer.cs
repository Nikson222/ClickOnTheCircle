using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : IGameStartListener, IGameFinishListener, IUpdateGameListener
{
    private int _availableGameTime;
    private float _timer;

    private bool _isActive = false;

    private Text _timerText;
    private Text _timerLeftText;
    public event Action OnTimeExist;

    public void Construct(int availableGameTime, Text timerText, Text timerLeftText)
    {
        _availableGameTime = availableGameTime;
        _timerText = timerText;
        _timerLeftText = timerLeftText;
    }

    public void OnGameStart()
    {
        _timer = _availableGameTime;

        _timerText.text = _timer.ToString();

        _isActive = true;
    }

    public void OnGameFinish()
    {
        _isActive = false;
    }

    public void OnUpdate(float deltaTime)
    {
        if (_isActive)
        {
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
                int timerLeft = Mathf.CeilToInt(_timer);
                
                _timerText.text = timerLeft.ToString();
            }
            else
            {
                _timerText.enabled = false;
                _timerLeftText.enabled = false;
                OnTimeExist?.Invoke();
            }
        }
    }
}