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
        var alreadyHasDefaultAlphabet = context.Alphabets.Any(a => a.Title == defaultAlphabet.Title);
        var alreadyHasArtworks = context.Artworks.Any();

        switch (alreadyHasDefaultAlphabet)
        {
            case true when alreadyHasArtworks:
                Console.WriteLine("Database already seeded. Skipping seeding.");
                return;
            case true:
                Console.WriteLine("Database already has default alphabet. Skipping seeding.");
                break;
            default:
                await context.AddAsync(defaultAlphabet);
                break;
        }

        if (alreadyHasArtworks)
        {
            Console.WriteLine("Database already has artworks. Skipping seeding.");
            return;
        }

        var defaultArtwork = SeedDataArtworks.Default(defaultAlphabet);
        await context.AddAsync(defaultArtwork);

        await context.SaveChangesAsync();
    }
}