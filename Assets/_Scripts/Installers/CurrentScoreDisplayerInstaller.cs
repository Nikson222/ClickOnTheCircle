using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class CurrentScoreDisplayerInstaller : MonoBehaviour, IGameConstructor, IGameListenerProvider
    {
        [SerializeField] private CurrentScoreDisplayer _currentScoreDisplayer;

        public void ConstructGame(IGameLocator serviceLocator)
        {
            Score score = serviceLocator.GetService<Score>();
            score.Construct(_currentScoreDisplayer);
        }

        public IEnumerable<object> GetListeners()
        {
            yield return _currentScoreDisplayer;
        }
    }
}