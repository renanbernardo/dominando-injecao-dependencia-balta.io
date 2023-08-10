
using Microsoft.AspNetCore.Mvc;
using DependencyStore.Models;
using DependencyStore.Services.Contracts;

namespace DependencyStore.Controllers;

public class CustomerController : ControllerBase
{ 
    [HttpGet]
    public Customer Get([FromServices] ICustomer customerService, string id)
        => customerService.Get(id);   
}
