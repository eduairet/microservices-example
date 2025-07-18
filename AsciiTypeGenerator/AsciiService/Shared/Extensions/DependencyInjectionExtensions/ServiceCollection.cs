using AsciiService.Repositories.AlphabetsRepository;
using AsciiService.Repositories.ArtworksRepository;

namespace AsciiService.Shared.Extensions.DependencyInjectionExtensions;

public static class ServiceCollection
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IArtworksRepository, ArtworksRepository>();
        services.AddScoped<IAlphabetsRepository, AlphabetsRepository>();
    }
}