using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts
{
    public class GameTimerInstaller : MonoBehaviour, IGameListenerProvider, IGameServiceProvider, IGameConstructor
    {
        [SerializeField] private int _availableGameTime;
        [SerializeField] private Text _timerText;
        [SerializeField] private Text _timerLeftText;
        
        private readonly GameTimer _gameTimer = new();

        private bool _isFirstInstall = false;
        
        public IEnumerable<object> GetListeners()
        {
            yield return _gameTimer;
            _isFirstInstall = true;
        }

        public IEnumerable<object> GetServices()
        {
            yield return _gameTimer;
        }

        public void ConstructGame(IGameLocator serviceLocator)
        {
            GameTimer gameTimer = serviceLocator.GetService<GameTimer>();
            GameContext gameContext = serviceLocator.GetService<GameContext>();
            
            if(_isFirstInstall)
                gameTimer.OnTimeExist += () => gameContext.FinishGame();
            
            gameTimer.Construct(_availableGameTime, _timerText, _timerLeftText);
        }
    }
}