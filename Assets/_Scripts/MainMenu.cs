using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Text _recordScore;

    public void Construct(int gameplaySceneIndex, int recordScore)
    {
        _playButton.onClick.AddListener(() => SceneManager.LoadScene(gameplaySceneIndex));      
        _recordScore.text = recordScore.ToString();
    }
}
