using System.Collections.Generic;

public interface IGameLocator
{
    void AddService(object service);

    void AddServices(IEnumerable<object> services);

    void RemoveService(object service);

    T GetService<T>();
}