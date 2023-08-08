using DependencyStore.Services.Contracts;
using DependencyStore.Services;
using DependencyStore.Repositories.Contracts;
using DependencyStore.Repositories;

namespace DependencyStore.Extensions;

public static class DependenciesExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
    }

    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
    }
}
