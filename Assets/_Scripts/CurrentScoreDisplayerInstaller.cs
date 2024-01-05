using UnityEngine;

namespace _Scripts
{
    public class CurrentScoreDisplayerInstaller : MonoBehaviour, IGameConstructor
    {
        [SerializeField] private CurrentScoreDisplayer _currentScoreDisplayer;

        public void ConstructGame(IGameLocator serviceLocator)
        {
            Score score = serviceLocator.GetService<Score>();
            score.Construct(_currentScoreDisplayer);
        }
    }
}