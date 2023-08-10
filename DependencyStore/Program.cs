using DependencyStore.Extensions;
using DependencyStore.Services;
using DependencyStore.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfiguration(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
// builder.Services.AddScoped<SqlConnection>();
// Para o Entity Framework, usar o AddDbContext
// builder.Services.AddDbContext<DependencyStoreContext>(options => options.UseSqlServer("CONN_STRING"));

builder.Services.AddDemoDependencyInjectionLifetimeSample();

builder.Services.AddDemoTryAddSample();

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("DependencyInjectionLifetimeSample", (
    PrimaryService primaryService,
    SecondaryService secondaryService,
    TertiaryService tertiaryService) =>
new 
{
    RequestId = Guid.NewGuid(),
    PrimaryServiceId = primaryService.Id,
    SecondaryService =  new 
    {
        Id = secondaryService.Id,
        PrimaryServiceId = secondaryService.PrimaryServiceId
    },
    TertiaryService = new 
    {
        Id = tertiaryService.Id,
        PrimaryServiceId = tertiaryService.PrimaryServiceId,
        SecondaryServiceId = tertiaryService.SecondaryServiceId,
        SecondaryServiceNewInstanceId = tertiaryService.SecondaryServiceNewInstanceId
    }
});

app.MapGet("TryAddSample", (IEnumerable<IService> services) 
    => Results.Ok(services.Select(x => x.GetType().Name)));

app.MapControllers();
app.Run();