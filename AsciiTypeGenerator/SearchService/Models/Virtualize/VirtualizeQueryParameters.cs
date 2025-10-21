using SearchService.Shared.Constants;

namespace SearchService.Models.Virtualize;

public class VirtualizeQueryParameters
{
    public string SearchText { get; set; } = string.Empty;
    public int StartIndex { get; set; }
    public int PageSize { get; set; } = ModelConstants.VirtualizeDefaultPageSize;
    public string SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
}

public enum SortDirection
{
    Asc,
    Desc
}