using AsciiService.Data;
using AsciiService.Shared.Constants;
using AsciiService.Shared.Extensions.DependencyInjection;
using AsciiTypeGenerator.Common.Transformers;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(new Constants.Environment(builder.Configuration).ConnectionString)
);
builder.Services.AddControllers(options =>
    options.Conventions.Add(
        new RouteTokenTransformerConvention(new SlugifyParameterTransformer())
    ));
builder.Services.AddRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();