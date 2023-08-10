using DependencyStore.Services.Contracts;

namespace DependencyStore.Services;

public class ServiceOne : IService
{
    public ServiceOne()
    {
        Console.WriteLine("ServiceOne criado");
    }
}