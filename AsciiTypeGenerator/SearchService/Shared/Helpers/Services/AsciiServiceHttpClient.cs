using SearchService.Models;
using SearchService.Shared.Constants;
using SearchService.Shared.Constants.ServicesRoutes;

namespace SearchService.Shared.Helpers.Services;

public class AsciiServiceHttpClient(IConfiguration configuration) : ServiceHttpClient(configuration,
    new EnvironmentConstants(configuration).AsciiServiceUrl)
{
    private readonly AsciiServiceRoutes _asciiServiceRoutes = new(configuration);

    public async Task<List<Alphabet>> GetAlphabetsForSearchDb()
    {
        var alphabets = await HttpClient.GetFromJsonAsync<List<Alphabet>>(_asciiServiceRoutes.GetAllAlphabets);
        return alphabets;
    }

    public async Task<List<Artwork>> GetArtworksForSearchDb()
    {
        var alphabets = await HttpClient.GetFromJsonAsync<List<Artwork>>(_asciiServiceRoutes.GetAllArtworks);
        return alphabets;
    }
}