using AsciiService.Shared.Constants;

namespace AsciiService.Models.Virtualize;

public class VirtualizeQueryParameters
{
    public int StartIndex { get; set; }
    public int PageSize { get; set; } = ModelConstants.VirtualizeDefaultPageSize;
}