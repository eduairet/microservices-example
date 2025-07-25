using SearchService.Shared.Constants;

namespace SearchService.Models.Virtualize;

public class VirtualizeQueryParameters
{
    public int StartIndex { get; set; }
    public int PageSize { get; set; } = ModelConstants.VirtualizeDefaultPageSize;
}