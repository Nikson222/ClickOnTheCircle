using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;

public class CircleSpawnerInstaller : MonoBehaviour, IGameListenerProvider, IGameConstructor
{
    [SerializeField] private float _maxSpawnDelay;
    [SerializeField] private Circle _circlePrefab;

    [SerializeField] private float _maxSize;
    [SerializeField] private List<Color> _availableColors;

    private CircleSpawner _circleSpawner = new(); 
    
    public IEnumerable<object> GetListeners()
    {
        yield return _circleSpawner;
    }

    public void ConstructGame(IGameLocator serviceLocator)
    {
        Score score = serviceLocator.GetService<Score>();
        _circleSpawner.Construct(_maxSpawnDelay, _circlePrefab, _maxSize, _availableColors,score);
    }
}
