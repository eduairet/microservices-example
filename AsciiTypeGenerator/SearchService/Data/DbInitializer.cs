using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;
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

        var environmentConstants = new EnvironmentConstants(configuration);

        await DB.InitAsync(
            environmentConstants.DatabaseName,
            MongoClientSettings.FromConnectionString(environmentConstants.ConnectionString)
        );

        await DB.Index<Alphabet>()
            .Key(x => x.ID, KeyType.Text)
            .CreateAsync();

        await DB.Index<Artwork>()
            .Key(x => x.ID, KeyType.Text)
            .CreateAsync();

        await DB.Index<Glyph>()
            .Key(x => x.ID, KeyType.Text)
            .CreateAsync();

        await DB.Index<ArtworkGlyph>()
            .Key(x => x.Index, KeyType.Ascending)
            .Key(x => x.ID, KeyType.Text)
            .Key(x => x.Artwork.ID, KeyType.Text)
            .Key(x => x.Glyph.ID, KeyType.Text)
            .CreateAsync();

        await DB.Index<User>()
            .Key(x => x.ID, KeyType.Text)
            .Key(x => x.UserName, KeyType.Text)
            .CreateAsync();

        using var scope = app.Services.CreateScope();
        var asciiServiceHttpClient = scope.ServiceProvider.GetRequiredService<AsciiServiceHttpClient>();

        var alphabets = await asciiServiceHttpClient.GetAlphabetsForSearchDb();
        if (alphabets is not null && alphabets.Count > 0) await DB.SaveAsync(alphabets);

        var artworks = await asciiServiceHttpClient.GetArtworksForSearchDb();
        if (artworks is not null && artworks.Count > 0) await DB.SaveAsync(artworks);
    }
}