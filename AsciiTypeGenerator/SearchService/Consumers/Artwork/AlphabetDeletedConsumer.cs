using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace SearchService.Consumers.Artwork;

public class ArtworkDeletedConsumer : IConsumer<ArtworkUpserted>
{
    public async Task Consume(ConsumeContext<ArtworkUpserted> context)
    {
        var artwork = await DB.Find<Entities.Artwork>()
            .MatchID(context.Message.Id)
            .ExecuteFirstAsync();

        if (artwork is null)
        {
            Console.WriteLine($"Artwork with ID {context.Message.Id} not found for deletion.");
            return;
        }

        Console.WriteLine($"Artwork deleted: {context.Message.Id}");
        await DB.DeleteAsync<Entities.Artwork>(artwork);
    }
}