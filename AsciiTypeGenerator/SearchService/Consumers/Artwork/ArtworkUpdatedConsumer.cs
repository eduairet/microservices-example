using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models.Artwork;

namespace SearchService.Consumers.Artwork;

public class ArtworkUpdatedConsumer : IConsumer<ArtworkUpdated>
{
    public async Task Consume(ConsumeContext<ArtworkUpdated> context)
    {
        Console.WriteLine($"Artwork updated: {context.Message.Id}");
        var artwork = ArtworkDto.ToEntity(context.Message);
        await artwork.SaveAsync();
    }
}