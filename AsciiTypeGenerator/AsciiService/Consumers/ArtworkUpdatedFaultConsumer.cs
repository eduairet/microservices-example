using AsciiService.Shared.Constants.Messages;
using Contracts;
using MassTransit;

namespace AsciiService.Consumers;

public class ArtworkUpdatedFaultConsumer : IConsumer<Fault<ArtworkUpdated>>
{
    public Task Consume(ConsumeContext<Fault<ArtworkUpdated>> context)
    {
        Console.WriteLine(Messages.Error.ArtworkErrorUpdating(context.Message.Exceptions.FirstOrDefault()?.Message));
        return Task.CompletedTask;
    }
}