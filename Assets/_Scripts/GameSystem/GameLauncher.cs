using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLauncher : MonoBehaviour
{
    [SerializeField] private List<GameTask> _taskList;

    [SerializeField] private int _sceneIndex;
    [SerializeField] private bool _isLaunchAnotherSceneAfterLoad;
    private async void Start()
    {
        await LaunchGame();
    }

    private async Task LaunchGame()
    {
        foreach (var task in _taskList)
        {
            await task.Do();
        }

        if (_isLaunchAnotherSceneAfterLoad)
        {
            SceneManager.LoadSceneAsync(_sceneIndex);
        }
    }
}