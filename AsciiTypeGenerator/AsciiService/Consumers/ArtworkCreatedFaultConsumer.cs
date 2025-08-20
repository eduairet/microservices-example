using Contracts;
using MassTransit;

namespace AsciiService.Consumers;

public class ArtworkCreatedFaultConsumer : IConsumer<Fault<ArtworkCreated>>
{
    public Task Consume(ConsumeContext<Fault<ArtworkCreated>> context)
    {
        Console.WriteLine($"Error creating artwork: {context.Message.Exceptions.FirstOrDefault()?.Message}");
        return Task.CompletedTask;
    }
}