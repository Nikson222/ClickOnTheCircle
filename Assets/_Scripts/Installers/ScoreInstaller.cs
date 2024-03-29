﻿using System.Collections.Generic;
using UnityEngine;

namespace _Scripts
{
    public class ScoreInstaller : MonoBehaviour, IGameListenerProvider, IGameServiceProvider, IGameConstructor
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

        public void ConstructGame(IGameLocator serviceLocator)
        {
            _score.LoadRecordScore();
        }
    }
}