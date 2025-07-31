using Scalar.AspNetCore;
using SearchService.Data;
using SearchService.Shared.Constants;
using SearchService.Shared.Extensions.DependencyInjectionExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHttpClients();
builder.Services.AddRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(ApiRoutes.OpenApiPath);
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Lifetime.ApplicationStarted.Register(async void () =>
{
    try
    {
        await new DbInitializer(app).Initialize();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
});

app.Run();