using Contracts;
using MassTransit;

namespace AsciiService.Consumers;

public class AlphabetCreatedFaultConsumer : IConsumer<Fault<AlphabetCreated>>
{
    public Task Consume(ConsumeContext<Fault<AlphabetCreated>> context)
    {
        Console.WriteLine($"Error creating alphabet: {context.Message.Exceptions.FirstOrDefault()?.Message}");
        return Task.CompletedTask;
    }
}