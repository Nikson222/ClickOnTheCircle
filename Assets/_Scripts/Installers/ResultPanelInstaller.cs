using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts
{
    public class ResultPanelInstaller : MonoBehaviour, IGameConstructor, IGameListenerProvider, IGameServiceProvider
    {
        [SerializeField] private GameObject panel;
    
        [SerializeField] private Text _scoreCountText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _mainMenuButton;

        private ResultPanel _resultPanel = new();
        
        public IEnumerable<object> GetListeners()
        {
            yield return _resultPanel;
        }

        public void ConstructGame(IGameLocator serviceLocator)
        {
            ResultPanel resultPanel = serviceLocator.GetService<ResultPanel>();
            
            Score score = serviceLocator.GetService<Score>();
            GameContext gameContext = serviceLocator.GetService<GameContext>();
            
            resultPanel.Construct(panel, _scoreCountText, _restartButton, _mainMenuButton, score, gameContext);
        }

        public IEnumerable<object> GetServices()
        {
            yield return _resultPanel;
        }
    }
}