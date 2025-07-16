using IdentityService.Entities;
using IdentityService.Shared.Constants;
using IdentityService.Shared.Helpers;
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

        if (context.Users.Any(u => u.Role.Name == nameof(IdentityRoles.SuperAdmin)))
        {
            Console.WriteLine("Database already has SuperAdmin user. Skipping seeding.");
            return;
        }

        var superAdminEmail = new EnvironmentConstants(configuration).SuperAdminEmail;
        var superAdminPassword = new EnvironmentConstants(configuration).SuperAdminPassword;

        var superAdmin = new User
        {
            UserName = nameof(IdentityRoles.SuperAdmin),
            NormalizedUserName = nameof(IdentityRoles.SuperAdmin).ToUpper(),
            Email = superAdminEmail,
            NormalizedEmail = superAdminEmail.ToUpper(),
            RoleId = ((int)IdentityRoles.SuperAdmin).ToString()
        };

        superAdmin.PasswordHash = PasswordHelpers.Hash(superAdmin, superAdminPassword);

        await context.AddAsync(superAdmin);
        await context.SaveChangesAsync();
    }
}