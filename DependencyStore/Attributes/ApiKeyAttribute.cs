using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using DependencyStore.Services.Contracts;

namespace DependencyStore.Attributes;

[AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
public class ApiKeyAttribute : Attribute, IAsyncActionFilter
{    
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // utiliza o HttpContext para obter o serviço
        var service = context.HttpContext.RequestServices.GetService<ICustomer>();
        var customer = service?.Get("1");       
        
        // resto do código...
    }
}