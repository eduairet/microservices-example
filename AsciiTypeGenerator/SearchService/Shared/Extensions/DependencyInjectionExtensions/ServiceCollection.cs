using SearchService.Repositories.SearchRepository;

namespace SearchService.Shared.Extensions.DependencyInjectionExtensions;

public static class ServiceCollection
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISearchRepository, SearchRepository>();
    }
}