using AsciiService.Shared.Constants.Messages;
using Contracts;
using MassTransit;

namespace AsciiService.Consumers;

public class AlphabetUpdatedFaultConsumer : IConsumer<Fault<AlphabetUpdated>>
{
    public Task Consume(ConsumeContext<Fault<AlphabetUpdated>> context)
    {
        Console.WriteLine(Messages.Error.AlphabetErrorUpdating(context.Message.Exceptions.FirstOrDefault()?.Message));
        return Task.CompletedTask;
    }
}