namespace AsciiService.Models.Artwork;

public class ArtworkDeletedResponse
{
    public string Id { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public static ArtworkDeletedResponse FromId(string id)
    {
        return new ArtworkDeletedResponse
        {
            Id = id,
            Message = Shared.Constants.SuccessMessages.ArtworkDeleted(id)
        };
    }
}