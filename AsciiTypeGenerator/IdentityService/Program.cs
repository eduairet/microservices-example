using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityService.Data;
using IdentityService.Entities;
using IdentityService.Shared.Constants;
using IdentityService.Shared.Constants.Messages;
using IdentityService.Shared.Helpers;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var env = new EnvironmentConstants(builder.Configuration);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(env.ConnectionString)
);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = JwtHelpers.GetTokenValidationParameters(builder.Configuration);
});

builder.Services.AddIdentityCore<User>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Host.UseSerilog((context, loggerConfiguration) =>
    loggerConfiguration.WriteTo.Console().ReadFrom.Configuration(context.Configuration));

// Needed to allow cookies to be sent in cross-origin requests
builder.Services.ConfigureApplicationCookie(options => { options.Cookie.SameSite = SameSiteMode.Lax; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(ApiRoutes.OpenApiPath);
    app.MapScalarApiReference();
    app.Lifetime.ApplicationStarted.Register(() =>
    {
        var logger = app.Services.GetService<ILogger<Program>>();
        var serverAddress = app.Urls.First();

        if (logger is null) return;

        logger.LogInformation("{Address}", serverAddress);
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

try
{
    await DbInitializer.InitDb(app);
}
catch (Exception ex)
{
    var logger = app.Services.GetService<ILogger<Program>>();
    logger?.LogError(ex, Messages.Error.DatabaseInitializationErrorLog, ex.Message);
}

app.Run();