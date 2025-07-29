namespace SearchService.Models.Virtualize;

public class VirtualizeResponse<T>
{
    public List<T> Items { get; set; } = [];
    public long PageCount { get; set; }
    public long TotalCount { get; set; }
}