using DependencyStore.Services.Contracts;
using DependencyStore.Services;
using DependencyStore.Repositories.Contracts;
using DependencyStore.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection.Extensions;

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

    /// <summary>
    /// Exemplo de ciclo de vida de serviços
    /// </summary>
    /// <param name="services"></param>
    public static void AddDemoDependencyInjectionLifetimeSample(this IServiceCollection services)
    {
        services.AddSingleton<PrimaryService>();
        services.AddScoped<SecondaryService>();
        services.AddTransient<TertiaryService>();
    }

    /// <summary>
    /// Exemplo de TryAdd, previne mais de uma implementação da mesma interface
    /// </summary>
    /// <param name="services"></param>
    public static void AddDemoTryAddSample(this IServiceCollection services)
    {
        // services.TryAddTransient<IService, ServiceOne>();
        // services.TryAddTransient<IService, ServiceOne>();
        // services.TryAddTransient<IService, ServiceTwo>();

        var descriptor = new ServiceDescriptor(typeof(IService), typeof(ServiceTwo), ServiceLifetime.Transient);
        services.TryAddEnumerable(descriptor);

        // services.TryAddEnumerable(ServiceDescriptor.Transient<IService, ServiceOne>());
        // services.TryAddEnumerable(ServiceDescriptor.Transient<IService, ServiceOne>()); // Permite
        // services.TryAddEnumerable(ServiceDescriptor.Transient<IService, ServiceTwo>()); // Não Permite
    }
}
