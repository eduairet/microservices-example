using Contracts;
using MassTransit;

namespace AsciiService.Consumers;

public class ArtworkUpdatedFaultConsumer : IConsumer<Fault<ArtworkUpdated>>
{
    public Task Consume(ConsumeContext<Fault<ArtworkUpdated>> context)
    {
        Console.WriteLine($"Error updating artwork: {context.Message.Exceptions.FirstOrDefault()?.Message}");
        return Task.CompletedTask;
    }
}