using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models.Alphabet;

namespace SearchService.Consumers.Alphabet;

public class AlphabetCreatedConsumer : IConsumer<AlphabetCreated>
{
    public async Task Consume(ConsumeContext<AlphabetCreated> context)
    {
        Console.WriteLine($"Consuming AlphabetCreated: {context.Message.Id}");
        var alphabet = AlphabetDto.ToEntity(context.Message);
        await alphabet.SaveAsync();
    }
}