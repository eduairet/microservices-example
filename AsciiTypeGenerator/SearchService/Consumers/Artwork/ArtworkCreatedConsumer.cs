using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models.Artwork;

namespace SearchService.Consumers.Artwork;

public class ArtworkCreatedConsumer : IConsumer<ArtworkCreated>
{
    public async Task Consume(ConsumeContext<ArtworkCreated> context)
    {
        Console.WriteLine($"Artwork created: {context.Message.Id}");
        var artwork = ArtworkDto.ToEntity(context.Message);
        await artwork.SaveAsync();
    }
}