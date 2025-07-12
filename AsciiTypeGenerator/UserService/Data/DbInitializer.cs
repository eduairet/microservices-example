using Microsoft.EntityFrameworkCore;
using UserService.Entities;
using UserService.Shared.Constants;
using UserService.Shared.Helpers;

namespace UserService.Data;

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

        var superAdminEmail = new Constants.Environment(configuration).SuperAdminEmail;
        var superAdminPassword = new Constants.Environment(configuration).SuperAdminPassword;

        var superAdmin = new User
        {
            UserName = nameof(IdentityRoles.SuperAdmin),
            NormalizedUserName = nameof(IdentityRoles.SuperAdmin).ToUpper(),
            Email = superAdminEmail,
            NormalizedEmail = superAdminEmail.ToUpper(),
            RoleId = ((int)IdentityRoles.SuperAdmin).ToString()
        };

        superAdmin.PasswordHash = Helpers.Password.Hash(superAdmin, superAdminPassword);

        await context.AddAsync(superAdmin);
        await context.SaveChangesAsync();
    }
}