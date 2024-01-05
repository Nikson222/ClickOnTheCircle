using System;
using System.Collections.Generic;
using UnityEngine;

public class GameLocator :  IGameLocator
{
    private readonly List<object> _services = new();

    public void AddService(object service)
    {
        _services.Add(service);
    }
    
    public void AddServices(IEnumerable<object> services)
    {
        _services.AddRange(services);
    }
    
    public void RemoveService(object service)
    {
        _services.Remove(service);
    }

    public T GetService<T>()
    {
        foreach (var service in _services)
        {
            if (service is T result)
            {
                return result;
            }
        }

        throw new Exception($"Service of type {typeof(T)} is not found!");
    }
}
