using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models.Alphabet;

namespace SearchService.Consumers.Alphabet;

public class AlphabetUpdatedConsumer : IConsumer<AlphabetUpdated>
{
    public async Task Consume(ConsumeContext<AlphabetUpdated> context)
    {
        Console.WriteLine($"Consuming AlphabetUpdated: {context.Message.Id}");

        var result = await DB.Update<Entities.Alphabet>()
            .Match(x => x.ID == context.Message.Id.ToString())
            .ModifyOnly(x => new
            {
                x.Title,
                x.Description,
                x.CreatedAt,
                x.UpdatedAt,
                x.Author,
                x.Glyphs
            }, AlphabetDto.ToEntity(context.Message)).ExecuteAsync();

        if (!result.IsAcknowledged)
            throw new MessageException(typeof(AlphabetUpdated),
                $"Failed to update alphabet with ID {context.Message.Id}");
    }
}