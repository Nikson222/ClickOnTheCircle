using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class MainMenuInstaller : MonoBehaviour, IGameConstructor
    {
        [SerializeField] private MainMenu _mainMenu;
        [SerializeField] private int _gamePlaySceneIndex;
        
        public void ConstructGame(IGameLocator serviceLocator)
        {
            Score score = serviceLocator.GetService<Score>();
            _mainMenu.Construct(_gamePlaySceneIndex, score.RecordScore);
        }
    }
}