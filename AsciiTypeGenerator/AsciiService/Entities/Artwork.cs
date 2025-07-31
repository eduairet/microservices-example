using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsciiService.Entities;

public class Artwork
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] [MaxLength(100)] public string Title { get; set; } = string.Empty;
    [Required] [MaxLength(2000)] public string Description { get; set; } = string.Empty;
    [Required] public DateTime CreatedAt { get; set; }
    [Required] public DateTime UpdatedAt { get; set; }
    [Required] public int AuthorId { get; set; }
    [ForeignKey("AuthorId")] public User Author { get; set; } = new();
    public virtual ICollection<ArtworkGlyph> Text { get; set; } = new List<ArtworkGlyph>();
}