using MassTransit;
using SearchService.Consumers.Alphabet;
using SearchService.Consumers.Artwork;

namespace SearchService.Shared.Extensions;

public static class MassTransitConfig
{
    public static void AddAllConsumersFromNamespaceContaining(this IBusRegistrationConfigurator configurator)
    {
        var consumerTypes = new[]
        {
            typeof(AlphabetUpsertedConsumer),
            typeof(AlphabetDeletedConsumer),
            typeof(ArtworkUpsertedConsumer),
            typeof(ArtworkDeletedConsumer)
        };
        foreach (var consumerType in consumerTypes)
        {
            configurator.AddConsumersFromNamespaceContaining(consumerType);
        }
    }
}