using Contracts;
using MassTransit;

namespace AsciiService.Consumers;

public class AlphabetUpdatedFaultConsumer : IConsumer<Fault<AlphabetUpdated>>
{
    public Task Consume(ConsumeContext<Fault<AlphabetUpdated>> context)
    {
        Console.WriteLine($"Error updating alphabet: {context.Message.Exceptions.FirstOrDefault()?.Message}");
        return Task.CompletedTask;
    }
}