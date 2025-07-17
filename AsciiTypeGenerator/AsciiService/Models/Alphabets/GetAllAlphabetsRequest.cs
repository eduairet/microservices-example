using System.ComponentModel.DataAnnotations;
using AsciiService.Shared.Constants;

namespace AsciiService.Models.Alphabets;

public class GetAllAlphabetsRequest
{
    public string SearchText { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = ErrorMessages.PositivePageNumber)]
    public int Page { get; set; }
}