using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;
using SearchService.Shared.Constants;

namespace SearchService.Data;

public class DbInitializer(IConfiguration configuration)
{
    public async Task Initialize()
    {
        var environmentConstants = new EnvironmentConstants(configuration);

        await DB.InitAsync(
            environmentConstants.DatabaseName,
            MongoClientSettings.FromConnectionString(environmentConstants.ConnectionString)
        );

        await DB.Index<Alphabet>()
            .Key(x => x.Title, KeyType.Text)
            .CreateAsync();

        await DB.Index<Artwork>()
            .Key(x => x.Title, KeyType.Text)
            .CreateAsync();

        await DB.Index<Glyph>()
            .Key(x => x.Unicode, KeyType.Text)
            .CreateAsync();

        await DB.Index<Matrix>()
            .Key(x => x.Name, KeyType.Text)
            .CreateAsync();

        await DB.Index<User>()
            .Key(x => x.UserName, KeyType.Text)
            .CreateAsync();
    }
}