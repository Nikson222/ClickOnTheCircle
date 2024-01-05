using System;
using UnityEngine;

namespace _Scripts
{
    public class Score : IGameFinishListener, IGameStartListener
    {
        private int _recordScore;
        private int _currentGameScore = 0;
        
        public int RecordScore => _recordScore;
        public int CurrentGameScore => _currentGameScore;
        
        private const string RecordScoreKey = "RecordScore";
        
        private CurrentScoreDisplayer _currentScoreDisplayer;

        public void Construct(CurrentScoreDisplayer currentScoreDisplayer)
        {
            _currentScoreDisplayer = currentScoreDisplayer;
            _currentScoreDisplayer.UpdateScoreText(_currentGameScore);
        }

        public void LoadRecordScore() => _recordScore = PlayerPrefs.GetInt(RecordScoreKey, 0);
        
         public void AddScore(int score)
        {
            _currentGameScore++;
            if(_currentScoreDisplayer != null)
                _currentScoreDisplayer.UpdateScoreText(_currentGameScore);
        }

        public void OnGameFinish()
        {
            if (_currentGameScore > _recordScore)
            {
                _recordScore = _currentGameScore;
                PlayerPrefs.SetInt(RecordScoreKey, _recordScore);
            }
        }

        public void OnGameStart()
        {
            _currentGameScore = 0;
            _currentScoreDisplayer.UpdateScoreText(_currentGameScore);
        }
    }
}