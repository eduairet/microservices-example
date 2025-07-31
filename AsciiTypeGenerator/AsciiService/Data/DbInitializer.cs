using AsciiService.Data.SeedDataObjects;
using Microsoft.EntityFrameworkCore;

namespace AsciiService.Data;

public static class DbInitializer
{
    public static async Task InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        await SeedData(scope.ServiceProvider.GetService<AppDbContext>());
    }

    private static async Task SeedData(AppDbContext context)
    {
        await context.Database.MigrateAsync();

        var defaultAlphabet = SeedDataAlphabets.Default();

        if (context.Alphabets.Any(a => a.Title == defaultAlphabet.Title))
        {
            Console.WriteLine("Database already has default alphabet. Skipping seeding.");
            return;
        }

        await context.AddAsync(defaultAlphabet);
        await context.SaveChangesAsync();
    }
}