using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models.Alphabet;

namespace SearchService.Consumers.Alphabet;

public class AlphabetUpdatedConsumer : IConsumer<AlphabetUpdated>
{
    public async Task Consume(ConsumeContext<AlphabetUpdated> context)
    {
        Console.WriteLine($"Alphabet updated: {context.Message.Id}");
        var alphabet = AlphabetDto.ToEntity(context.Message);
        await alphabet.SaveAsync();
    }
}