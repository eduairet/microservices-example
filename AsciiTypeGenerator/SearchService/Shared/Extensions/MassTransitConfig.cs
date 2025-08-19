using MassTransit;
using SearchService.Consumers.Alphabet;
using SearchService.Consumers.Artwork;
using SearchService.Shared.Constants;

namespace SearchService.Shared.Extensions;

public static class MassTransitConfig
{
    private static readonly List<(string slug, Type type)> _consumers =
    [
        (RabbitMqEndpoints.Alphabets.Created, typeof(AlphabetCreatedConsumer)),
        (RabbitMqEndpoints.Alphabets.Updated, typeof(AlphabetUpdatedConsumer)),
        (RabbitMqEndpoints.Alphabets.Deleted, typeof(AlphabetDeletedConsumer)),
        (RabbitMqEndpoints.Artworks.Created, typeof(ArtworkCreatedConsumer)),
        (RabbitMqEndpoints.Artworks.Updated, typeof(ArtworkUpdatedConsumer)),
        (RabbitMqEndpoints.Artworks.Deleted, typeof(ArtworkDeletedConsumer))
    ];

    public static void AddAllConsumersFromNamespaceContaining(this IBusRegistrationConfigurator configurator)
    {
        foreach (var consumer in _consumers) configurator.AddConsumersFromNamespaceContaining(consumer.type);
    }

    public static void ConfigureMessageRetries(this IRabbitMqBusFactoryConfigurator configurator,
        IBusRegistrationContext context)
    {
        foreach (var consumer in _consumers)
        {
            configurator.ReceiveEndpoint(consumer.slug, e =>
            {
                e.UseMessageRetry(r => r.Interval(5, 5));
                e.ConfigureConsumer(context, consumer.type);
            });
        }
    }
}