using System.ComponentModel.DataAnnotations;
using AsciiService.Models.Glyph;

namespace AsciiService.Models.Alphabet;

public class AlphabetUpdateDto
{
    [Required] [MaxLength(100)] public string Title { get; set; } = string.Empty;
    [Required] [MaxLength(2000)] public string Description { get; set; } = string.Empty;
    public List<GlyphUpsertDto> Glyphs { get; set; }
}