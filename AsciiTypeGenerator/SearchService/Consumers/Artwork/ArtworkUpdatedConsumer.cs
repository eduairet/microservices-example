using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models.Artwork;

namespace SearchService.Consumers.Artwork;

public class ArtworkUpdatedConsumer : IConsumer<ArtworkUpdated>
{
    public async Task Consume(ConsumeContext<ArtworkUpdated> context)
    {
        Console.WriteLine($"Consuming ArtworkUpdated: {context.Message.Id}");

        var result = await DB.Update<Entities.Artwork>()
            .Match(x => x.ID == context.Message.Id.ToString())
            .ModifyOnly(x => new
            {
                x.Title,
                x.Description,
                x.CreatedAt,
                x.UpdatedAt,
                x.Author,
                x.ArtworkGlyphs
            }, ArtworkDto.ToEntity(context.Message)).ExecuteAsync();

        if (!result.IsAcknowledged)
            throw new MessageException(typeof(ArtworkUpdated),
                $"Failed to update Artwork with ID {context.Message.Id}");
    }
}