using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsciiService.Entities;

public class ArtworkGlyph
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] public int Index { get; set; }
    [Required] public int ArtworkId { get; set; }
    [ForeignKey("ArtworkId")] public Artwork Artwork { get; set; } = new();
    [Required] public int GlyphId { get; set; }
    [ForeignKey("GlyphId")] public Glyph Glyph { get; set; } = new();
}