using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsciiService.Entities;

public class Glyph
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(int.MaxValue)] public string Name { get; set; } = string.Empty;
    [Required] public int Unicode { get; set; }
    [Required] public int AlphabetId { get; set; }
    [Required] [MaxLength(int.MaxValue)] public string Drawing { get; set; } = string.Empty;

    [System.Text.Json.Serialization.JsonIgnore]
    [ForeignKey("AlphabetId")]
    public Alphabet Alphabet { get; set; } = new();

    [System.Text.Json.Serialization.JsonIgnore]
    public virtual ICollection<ArtworkGlyph> ArtworkGlyphs { get; set; } = new List<ArtworkGlyph>();
}