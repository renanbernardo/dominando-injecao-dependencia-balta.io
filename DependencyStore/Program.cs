using DependencyStore;
using DependencyStore.Extensions;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRepositories();
builder.Services.AddServices();
// builder.Services.AddScoped<SqlConnection>();
builder.Services.AddScoped(x => new SqlConnection("CONN_STRING"));
// Para o Entity Framework, usar o AddDbContext
// builder.Services.AddDbContext<DependencyStoreContext>(options => options.UseSqlServer("CONN_STRING"));
builder.Services.AddSingleton<Configuration>();

builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();