using System;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultPanel : IGameFinishListener
{
    private GameObject _panel;

    private Text _scoreCountText;
    private Button _restartButton;
    private Button _mainMenuButton;

    private const int _mainMenuSceneIndex = 1;
    private const int _gameplaySceneIndex = 2;

    private Score _score;

    public void OnGameFinish()
    {
        _panel.SetActive(true);

        _scoreCountText.text = _score.CurrentGameScore.ToString();
    }

    public void Construct(GameObject panel, Text scoreCountText, Button restartButton, Button mainMenuButton,
        Score score, GameContext gameContext)
    {
        _panel = panel;
        _scoreCountText = scoreCountText;
        _restartButton = restartButton;
        _mainMenuButton = mainMenuButton;
        
        panel.gameObject.SetActive(false);
        
        _score = score;

        _mainMenuButton.onClick.AddListener(() => SceneManager.LoadScene(_mainMenuSceneIndex));
        _restartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(_gameplaySceneIndex);
            gameContext.RestartGame();
        });
    }
}