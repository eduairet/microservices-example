using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Entities;
using SearchService.Shared.Constants;
using SearchService.Shared.Helpers.Services;

namespace SearchService.Data;

public class DbInitializer(WebApplication app)
{
    public async Task Initialize()
    {
        var configuration = app.Services.GetRequiredService<IConfiguration>();
        if (configuration == null)
            throw new ArgumentNullException(nameof(configuration), ErrorMessages.InvalidConfiguration);

        var env = new EnvironmentConstants(configuration);

        await DB.InitAsync(
            env.DatabaseName,
            MongoClientSettings.FromConnectionString(env.ConnectionString)
        );

        await DB.Index<Alphabet>()
            .Key(x => x.Title, KeyType.Text)
            .Key(x => x.Description, KeyType.Text)
            .Key(x => x.AuthorName, KeyType.Text)
            .CreateAsync();

        await DB.Index<Artwork>()
            .Key(x => x.Title, KeyType.Text)
            .Key(x => x.Description, KeyType.Text)
            .Key(x => x.AuthorName, KeyType.Text)
            .CreateAsync();

        using var scope = app.Services.CreateScope();
        var asciiServiceHttpClient = scope.ServiceProvider.GetRequiredService<AsciiServiceHttpClient>();

        var alphabets = await asciiServiceHttpClient.GetAlphabetsForSearchDb();
        if (alphabets is not null && alphabets.Count > 0) await DB.SaveAsync(alphabets);

        var artworks = await asciiServiceHttpClient.GetArtworksForSearchDb();
        if (artworks is not null && artworks.Count > 0) await DB.SaveAsync(artworks);
    }
}