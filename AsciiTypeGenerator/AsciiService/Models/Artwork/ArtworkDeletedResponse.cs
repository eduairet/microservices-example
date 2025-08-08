namespace AsciiService.Models.Artwork;

public class ArtworkDeletedResponse
{
    public int Id { get; set; }

    public string Message { get; set; } = string.Empty;

    public static ArtworkDeletedResponse FromId(int id)
    {
        return new ArtworkDeletedResponse
        {
            Id = id,
            Message = Shared.Constants.SuccessMessages.ArtworkDeleted(id)
        };
    }
}