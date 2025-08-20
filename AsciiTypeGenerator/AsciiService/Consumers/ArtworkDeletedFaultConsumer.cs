using Contracts;
using MassTransit;

namespace AsciiService.Consumers;

public class ArtworkDeletedFaultConsumer : IConsumer<Fault<ArtworkDeleted>>
{
    public Task Consume(ConsumeContext<Fault<ArtworkDeleted>> context)
    {
        Console.WriteLine($"Error deleting artwork: {context.Message.Exceptions.FirstOrDefault()?.Message}");
        return Task.CompletedTask;
    }
}