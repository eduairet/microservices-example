using AsciiService.Consumers;
using AsciiService.Shared.Constants;
using MassTransit;

namespace AsciiService.Shared.Extensions;

public static class MassTransitConfig
{
    private static readonly List<(string slug, Type type)> _consumers =
    [
        (RabbitMqEndpoints.Alphabets.Created, typeof(AlphabetCreatedFaultConsumer)),
        (RabbitMqEndpoints.Alphabets.Updated, typeof(AlphabetUpdatedFaultConsumer)),
        (RabbitMqEndpoints.Alphabets.Deleted, typeof(AlphabetDeletedFaultConsumer)),
        (RabbitMqEndpoints.Artworks.Created, typeof(ArtworkCreatedFaultConsumer)),
        (RabbitMqEndpoints.Artworks.Updated, typeof(ArtworkUpdatedFaultConsumer)),
        (RabbitMqEndpoints.Artworks.Deleted, typeof(ArtworkDeletedFaultConsumer))
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