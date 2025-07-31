using IdentityService.Data.SeedDataObjects;
using IdentityService.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Data;

public static class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        await SeedData(scope.ServiceProvider.GetService<AppDbContext>(),
            scope.ServiceProvider.GetService<IConfiguration>());
    }

    private static async Task SeedData(AppDbContext context, IConfiguration configuration)
    {
        await context.Database.MigrateAsync();

        if (context.Users.Any(u => u.Role.Name == nameof(IdentityRolesEnum.SuperAdmin)))
        {
            Console.WriteLine("Database already has SuperAdmin user. Skipping seeding.");
            return;
        }

        await context.AddAsync(new SeedDataUsers(configuration).SuperAdmin());
        await context.SaveChangesAsync();
    }
}