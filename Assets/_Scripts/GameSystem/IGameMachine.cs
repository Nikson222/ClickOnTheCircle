using System.Collections.Generic;

public interface IGameMachine
{
    GameState GameState { get; }

    void StartGame();

    void FinishGame();

    void AddListener(object listener);

    void AddListeners(IEnumerable<object> listeners);

    void RemoveListener(object listener);
}