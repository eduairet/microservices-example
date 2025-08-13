using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models.Alphabet;

namespace SearchService.Consumers.Alphabet;

public class AlphabetUpsertedConsumer : IConsumer<AlphabetUpserted>
{
    public async Task Consume(ConsumeContext<AlphabetUpserted> context)
    {
        Console.WriteLine($"Alphabet created/updated: {context.Message.Id}");
        var alphabet = AlphabetDto.ToEntity(context.Message);
        await alphabet.SaveAsync();
    }
}