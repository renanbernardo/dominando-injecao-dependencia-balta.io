using DependencyStore.Services.Contracts;

namespace DependencyStore.Services;

public class ServiceTwo : IService
{
    public ServiceTwo()
    {
        Console.WriteLine("ServiceTwo criado");
    }
}