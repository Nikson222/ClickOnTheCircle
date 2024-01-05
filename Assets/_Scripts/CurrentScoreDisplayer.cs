using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentScoreDisplayer : MonoBehaviour
{
    [SerializeField] private Text _currentScore;
    
    public void UpdateScoreText(int score)
    {
        _currentScore.text = score.ToString();
    }
}
