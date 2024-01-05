using System.Collections.Generic;

internal interface IGameServiceProvider
{
    IEnumerable<object> GetServices();
}