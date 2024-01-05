using System.Collections.Generic;

internal interface IGameListenerProvider
{
    IEnumerable<object> GetListeners();
}