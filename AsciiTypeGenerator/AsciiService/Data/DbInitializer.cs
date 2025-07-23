using AsciiService.Entities;
using AsciiService.Shared.Constants;
using Microsoft.EntityFrameworkCore;

namespace AsciiService.Data;

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

        if (context.Matrices.Any(m => m.Depth == (int)MatricesEnum.Classic))
        {
            Console.WriteLine("Database already has the default AsciiService data. Skipping seeding.");
            return;
        }

        var newMatrix = new Matrix
        {
            Name = nameof(MatricesEnum.Classic),
            Depth = (int)MatricesEnum.Classic
        };

        await context.AddAsync(newMatrix);
        await context.SaveChangesAsync();
    }
}