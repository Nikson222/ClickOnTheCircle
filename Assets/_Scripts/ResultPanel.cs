
using System;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour, IGameFinishListener, IGameConstructor, IGameListenerProvider
{
    [SerializeField] private GameObject panel;
    
    [SerializeField] private Text _scoreCountText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;

    private const int _mainMenuSceneIndex = 1;
    private const int _gameplaySceneIndex = 2;
    
    private Score _score;
    
    public void OnGameFinish()
    {
        panel.SetActive(true);

        _scoreCountText.text = _score.CurrentGameScore.ToString();
    }

    private void Start()
    {
        panel.gameObject.SetActive(false);
    }

    public void ConstructGame(IGameLocator serviceLocator)
    {
        _score = serviceLocator.GetService<Score>();
        GameContext gameContext = serviceLocator.GetService<GameContext>();
        
        _mainMenuButton.onClick.AddListener(() => SceneManager.LoadScene(_gameplaySceneIndex));
        _restartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(_mainMenuSceneIndex);
            gameContext.RestartGame();
        });
    }

    public IEnumerable<object> GetListeners()
    {
        yield return this;
    }
}
