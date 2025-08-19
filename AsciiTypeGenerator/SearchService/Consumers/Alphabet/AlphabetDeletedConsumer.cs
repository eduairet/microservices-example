using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace SearchService.Consumers.Alphabet;

public class AlphabetDeletedConsumer : IConsumer<AlphabetDeleted>
{
    public async Task Consume(ConsumeContext<AlphabetDeleted> context)
    {
        var alphabet = await DB.Find<Entities.Alphabet>()
            .MatchID(context.Message.Id)
            .ExecuteFirstAsync();

        if (alphabet is null)
        {
            Console.WriteLine($"Alphabet with ID {context.Message.Id} not found for deletion.");
            return;
        }

        Console.WriteLine($"Alphabet deleted: {context.Message.Id}");
        await DB.DeleteAsync<Entities.Alphabet>(alphabet);
    }
}