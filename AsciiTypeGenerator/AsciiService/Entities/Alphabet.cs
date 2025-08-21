using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsciiService.Entities;

public sealed class Alphabet
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] [MaxLength(100)] public string Title { get; set; } = string.Empty;
    [Required] [MaxLength(2000)] public string Description { get; set; } = string.Empty;
    [Required] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Required] public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    [MaxLength(int.MaxValue)] public string AuthorId { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    [ForeignKey("AuthorId")]
    public User Author { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public ICollection<Glyph> Glyphs { get; set; } = new List<Glyph>();
}