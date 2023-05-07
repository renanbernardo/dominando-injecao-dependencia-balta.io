using DependencyStore.Repositories;
using DependencyStore.Repositories.Contracts;
using DependencyStore.Services;
using DependencyStore.Services.Contracts;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
builder.Services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
// builder.Services.AddScoped<SqlConnection>();
builder.Services.AddScoped(x => new SqlConnection("CONN_STRING"));
// Para o Entity Framework, usar o AddDbContext
// builder.Services.AddDbContext<DependencyStoreContext>(options => options.UseSqlServer("CONN_STRING"));

builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();