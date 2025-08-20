using Contracts;
using MassTransit;

namespace AsciiService.Consumers;

public class AlphabetDeletedFaultConsumer : IConsumer<Fault<AlphabetDeleted>>
{
    public Task Consume(ConsumeContext<Fault<AlphabetDeleted>> context)
    {
        Console.WriteLine($"Error deleting alphabet: {context.Message.Exceptions.FirstOrDefault()?.Message}");
        return Task.CompletedTask;
    }
}