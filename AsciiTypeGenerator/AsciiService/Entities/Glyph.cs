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
    [ForeignKey("AlphabetId")] public Alphabet Alphabet { get; set; } = new();

    [Required]
    [MaxLength(int.MaxValue)]
    public string Drawing { get; set; } = string.Empty;
}