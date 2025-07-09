namespace AsciiTypeGenerator.Common.Models.Virtualize;

public class VirtualizeResponse<T>(List<T> items)
{
    public VirtualizeResponse() : this([])
    {
    }

    public List<T> Items { get; set; } = items;
    public int TotalCount { get; set; }
}