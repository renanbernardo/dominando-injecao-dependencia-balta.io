using DependencyStore.Models;

namespace DependencyStore.Services.Contracts;

public interface ICustomer
{
    Customer Get(string id);
}