using System.ComponentModel.DataAnnotations;
using SearchService.Shared.Constants;

namespace SearchService.Models.Virtualize;

public class VirtualizeRequest
{
    public string SearchText { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.PositivePageNumber)]
    public int Page { get; set; }
}