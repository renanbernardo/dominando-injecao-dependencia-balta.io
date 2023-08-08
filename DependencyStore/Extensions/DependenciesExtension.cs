using DependencyStore.Services.Contracts;
using DependencyStore.Services;
using DependencyStore.Repositories.Contracts;
using DependencyStore.Repositories;
using Microsoft.Data.SqlClient;

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

    public static void AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<Configuration>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddScoped(x => new SqlConnection(connectionString));
    }
}
