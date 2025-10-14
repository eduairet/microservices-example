using AsciiService.Data;
using AsciiService.Shared.Constants;
using AsciiService.Shared.Extensions;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

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

builder.Services.AddMassTransit(config =>
{
    config.AddAllConsumersFromNamespaceContaining();
    config.SetEndpointNameFormatter(new KebabCaseEndpointNameFormatter(RabbitMqEndpoints.Prefix, false));
    config.AddEntityFrameworkOutbox<AppDbContext>(o =>
    {
        o.QueryDelay = TimeSpan.FromSeconds(10);
        o.UsePostgres();
        o.UseBusOutbox();
    });

    config.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(env.RabbitMqHost, "/", h =>
        {
            h.Username(env.RabbitMqUsername);
            h.Password(env.RabbitMqPassword);
        });

        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddRepositories();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = env.IdentityServiceUrl;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters.ValidateAudience = false;
        options.TokenValidationParameters.NameClaimType = "username";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(ApiRoutes.OpenApiPath);
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

try
{
    await DbInitializer.InitDb(app);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

app.Run();