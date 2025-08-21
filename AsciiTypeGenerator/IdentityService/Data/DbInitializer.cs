using IdentityService.Data.SeedDataObjects;
using IdentityService.Entities;
using IdentityService.Shared.Constants.Messages;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Data;

public static class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        await SeedData(scope.ServiceProvider.GetService<AppDbContext>(),
            scope.ServiceProvider.GetService<IConfiguration>(),
            scope.ServiceProvider.GetService<ILogger<Program>>());
    }

    private static async Task SeedData(AppDbContext context, IConfiguration configuration, ILogger logger)
    {
        await context.Database.MigrateAsync();

        if (context.Users.Any(u => u.Role.Name == nameof(IdentityRolesEnum.SuperAdmin)))
        {
            logger.LogInformation(Messages.Info.DatabaseSuperAdminAlreadyExists);
            return;
        }

        await context.AddAsync(new SeedDataUsers(configuration).SuperAdmin());
        await context.SaveChangesAsync();
    }
}