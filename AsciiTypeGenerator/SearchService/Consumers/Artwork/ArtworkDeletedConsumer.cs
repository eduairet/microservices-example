using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace SearchService.Consumers.Artwork;

public class ArtworkDeletedConsumer : IConsumer<ArtworkDeleted>
{
    public async Task Consume(ConsumeContext<ArtworkDeleted> context)
    {
        Console.WriteLine($"Consuming ArtworkDeleted: {context.Message.Id}");

        var result = await DB.DeleteAsync<Entities.Artwork>(context.Message.Id);

        if (!result.IsAcknowledged)
            throw new MessageException(typeof(ArtworkDeleted),
                $"Failed to delete Artwork with ID {context.Message.Id}");
    }
}