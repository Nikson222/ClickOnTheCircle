using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class ScoreInstaller : MonoBehaviour, IGameListenerProvider, IGameServiceProvider
    {
        private Score _score = new();
        public IEnumerable<object> GetListeners()
        {
            yield return _score;
        }

        public IEnumerable<object> GetServices()
        {
            yield return _score;
        }
    }
}