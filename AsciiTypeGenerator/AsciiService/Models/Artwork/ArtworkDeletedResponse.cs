using AsciiService.Shared.Constants.Messages;

namespace AsciiService.Models.Artwork;

public class ArtworkDeletedResponse
{
    public int Id { get; set; }

    public string Message { get; set; } = string.Empty;

    public static ArtworkDeletedResponse FromId(int id) => new()
    {
        Id = id,
        Message = Messages.Info.ArtworkDeleted(id)
    };
}