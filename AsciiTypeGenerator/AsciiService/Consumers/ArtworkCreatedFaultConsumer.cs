using AsciiService.Shared.Constants.Messages;
using Contracts;
using MassTransit;

namespace AsciiService.Consumers;

public class ArtworkCreatedFaultConsumer : IConsumer<Fault<ArtworkCreated>>
{
    public Task Consume(ConsumeContext<Fault<ArtworkCreated>> context)
    {
        Console.WriteLine(Messages.Error.ArtworkErrorCreating(context.Message.Exceptions.FirstOrDefault()?.Message));
        return Task.CompletedTask;
    }
}