using DependencyStore.Services.Contracts;
using DependencyStore.Models;

namespace DependencyStore.Services;

public class CustomerService : ICustomer
{
    public Customer Get(string id)
    {
        return new Customer
        {
            Id = id,
            Email = "email@email",
            Name = "name"
        };
    }

}