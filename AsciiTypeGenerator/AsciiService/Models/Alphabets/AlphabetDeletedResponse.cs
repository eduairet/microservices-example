namespace AsciiService.Models.Alphabets;

public class AlphabetDeletedResponse
{
    public string Id { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public static AlphabetDeletedResponse FromId(string id)
    {
        return new AlphabetDeletedResponse
        {
            Id = id,
            Message = Shared.Constants.SuccessMessages.AlphabetDeleted(id)
        };
    }
}