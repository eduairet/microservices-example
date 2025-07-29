using SearchService.Shared.Constants;

namespace SearchService.Models.Virtualize;

public class VirtualizeQueryParameters
{
    public string SearchText { get; set; } = string.Empty;
    public int StartIndex { get; set; }
    public int PageSize { get; set; } = ModelConstants.VirtualizeDefaultPageSize;
    public SortByParameter SortBy { get; set; }
    public List<Func<bool>> Filter { get; set; } = [];
}

public abstract class SortByParameter
{
    public string Field { get; set; }
    public bool Descending { get; set; }
}