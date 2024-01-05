using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class CircleSpawner : IGameStartListener, IGameFinishListener, IUpdateGameListener
{
    private float _maxSpawnDelay;
    private Circle _circlePrefab;

    private float _maxSize;
    private List<Color> _availableColors;

    private ObjectPooler<Circle> _objectPooler;

    private Vector2 _screenBounds;
    private float _timer;

    private bool _isActive = false;

    private Score _score;

    private List<Circle> _activeCircles = new();

    public void Construct(float maxSpawnDelay, Circle circlePrefab, float maxSize, List<Color> availableColors,
        Score score)
    {
        _maxSpawnDelay = maxSpawnDelay;
        _circlePrefab = circlePrefab;
        _maxSize = maxSize;
        _availableColors = availableColors;

        _objectPooler = new ObjectPooler<Circle>();
        _objectPooler.Init(_circlePrefab);

        _screenBounds =
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        _score = score;

        _timer = 0;
    }

    public void OnGameStart()
    {
        _isActive = true;
    }

    public void OnGameFinish()
    {
        _isActive = false;
        _objectPooler = new ObjectPooler<Circle>();
        _objectPooler.Init(_circlePrefab);

        foreach (var circle in _activeCircles)
        {
            circle.gameObject.SetActive(false);
        }
        
        _activeCircles.Clear();
    }

    public void OnUpdate(float deltaTime)
    {
        if (_isActive)
        {
            if (_timer <= 0)
            {
                _timer = Random.Range(0, _maxSpawnDelay);

                Circle circle = _objectPooler.GetObject();

                Vector2 newSize = GetRandomSize();
                Color newColor = GetRandomColor();

                _activeCircles.Add(circle);

                if (!circle.IsAlreadyUsed)
                {
                    circle.OnExploded += _score.AddScore;
                    circle.OnExploded += i =>
                    {
                        _activeCircles.Remove(circle);
                    };
                }

                circle.SetStyle(newColor, newSize);


                Vector2 newPosition = GenerateRandomPosition(circle.Radius);


                circle.transform.position = newPosition;
            }

            _timer -= deltaTime;
        }
    }

    private Vector2 GenerateRandomPosition(float circleRadius)
    {
        float randomXPosition = Random.Range(-_screenBounds.x + circleRadius, _screenBounds.x - circleRadius);
        float randomYPosition = Random.Range(-_screenBounds.y + circleRadius, _screenBounds.y - circleRadius);

        return new Vector2(randomXPosition, randomYPosition);
    }

    private Vector2 GetRandomSize()
    {
        float newSize = Random.Range(Vector2.one.x, _maxSize);
        return new Vector2(newSize, newSize);
    }

    private Color GetRandomColor()
    {
        int randomColorIndex = Random.Range(0, _availableColors.Count);
        return _availableColors[randomColorIndex];
    }
}