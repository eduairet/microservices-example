namespace AsciiService.Models.Alphabets;

public class GetAllAlphabetsRequest
{
    public string SearchText { get; set; }
    public int Skip { get; set; }
    public int Take { get; set; }
}