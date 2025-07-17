namespace AsciiService.Models.Virtualize;

public class VirtualizeResponse<T>
{
    public List<T> Items { get; set; } = [];
    public int TotalCount { get; set; }
}