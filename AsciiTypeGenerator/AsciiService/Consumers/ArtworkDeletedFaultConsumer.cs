using AsciiService.Shared.Constants.Messages;
using Contracts;
using MassTransit;

namespace AsciiService.Consumers;

public class ArtworkDeletedFaultConsumer : IConsumer<Fault<ArtworkDeleted>>
{
    public Task Consume(ConsumeContext<Fault<ArtworkDeleted>> context)
    {
        Console.WriteLine(Messages.Error.ArtworkErrorDeleting(context.Message.Exceptions.FirstOrDefault()?.Message));
        return Task.CompletedTask;
    }
}