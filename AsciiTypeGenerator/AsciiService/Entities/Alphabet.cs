using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsciiService.Entities;

public class Alphabet
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] [MaxLength(100)] public string Title { get; set; } = string.Empty;
    [Required] [MaxLength(2000)] public string Description { get; set; } = string.Empty;
    [Required] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Required] public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public int? AuthorId { get; set; }
    [ForeignKey("AuthorId")] public User Author { get; set; }
    public virtual ICollection<Glyph> Glyphs { get; set; } = new List<Glyph>();
}