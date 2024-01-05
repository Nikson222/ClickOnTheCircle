using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScoreDisplayer : MonoBehaviour, IGameFinishListener
{
    [SerializeField] private Text _currentScoreText;
    [SerializeField] private Text _currentScoreCountText;
    
    public void UpdateScoreText(int score)
    {
        _currentScoreCountText.text = score.ToString();
    }

    public void OnGameFinish()
    {
        _currentScoreText.enabled = false;
        _currentScoreCountText.enabled = false;
    }
}
