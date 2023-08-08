using DependencyStore.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfiguration(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
// builder.Services.AddScoped<SqlConnection>();
// Para o Entity Framework, usar o AddDbContext
// builder.Services.AddDbContext<DependencyStoreContext>(options => options.UseSqlServer("CONN_STRING"));

builder.Services.AddControllers();

var app = builder.Build();
app.MapControllers();
app.Run();