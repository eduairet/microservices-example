using SearchService.Entities;
using SearchService.Repositories.SearchRepository;
using SearchService.Shared.Constants.Policies;
using SearchService.Shared.Helpers.Services;

namespace SearchService.Shared.Extensions;

public static class ServiceCollection
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISearchRepository<Alphabet>, SearchRepository<Alphabet>>();
        services.AddScoped<ISearchRepository<Artwork>, SearchRepository<Artwork>>();
    }

    public static void AddHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient<AsciiServiceHttpClient>()
            .AddPolicyHandler(HttpClientPolicies.RetryWhenNotFound());
    }
}