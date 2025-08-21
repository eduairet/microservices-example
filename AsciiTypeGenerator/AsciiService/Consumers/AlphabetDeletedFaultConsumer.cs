using AsciiService.Shared.Constants.Messages;
using Contracts;
using MassTransit;

namespace AsciiService.Consumers;

public class AlphabetDeletedFaultConsumer : IConsumer<Fault<AlphabetDeleted>>
{
    public Task Consume(ConsumeContext<Fault<AlphabetDeleted>> context)
    {
        Console.WriteLine(Messages.Error.AlphabetErrorDeleting(context.Message.Exceptions.FirstOrDefault()?.Message));
        return Task.CompletedTask;
    }
}