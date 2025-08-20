using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace SearchService.Consumers.Alphabet;

public class AlphabetDeletedConsumer : IConsumer<AlphabetDeleted>
{
    public async Task Consume(ConsumeContext<AlphabetDeleted> context)
    {
        Console.WriteLine($"Consuming AlphabetDeleted: {context.Message.Id}");

        var result = await DB.DeleteAsync<Entities.Alphabet>(context.Message.Id);

        if (!result.IsAcknowledged)
            throw new MessageException(typeof(AlphabetDeleted),
                $"Failed to delete Alphabet with ID {context.Message.Id}");
    }
}