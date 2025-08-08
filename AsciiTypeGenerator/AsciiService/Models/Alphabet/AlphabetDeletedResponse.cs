namespace AsciiService.Models.Alphabet;

public class AlphabetDeletedResponse
{
    public int Id { get; set; }

    public string Message { get; set; } = string.Empty;

    public static AlphabetDeletedResponse FromId(int id)
    {
        return new AlphabetDeletedResponse
        {
            Id = id,
            Message = Shared.Constants.SuccessMessages.AlphabetDeleted(id)
        };
    }
}