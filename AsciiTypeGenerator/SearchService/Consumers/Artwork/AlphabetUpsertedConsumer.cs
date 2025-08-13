using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models.Artwork;

namespace SearchService.Consumers.Artwork;

public class ArtworkUpsertedConsumer : IConsumer<ArtworkUpserted>
{
    public async Task Consume(ConsumeContext<ArtworkUpserted> context)
    {
        Console.WriteLine($"Artwork created/updated: {context.Message.Id}");
        var artwork = ArtworkDto.ToEntity(context.Message);
        await artwork.SaveAsync();
    }
}