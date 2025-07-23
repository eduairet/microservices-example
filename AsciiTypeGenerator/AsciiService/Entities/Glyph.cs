using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsciiService.Entities;

public class Glyph
{
    [Key] [MaxLength(int.MaxValue)] public string Name { get; set; } = string.Empty;
    [Required] public int Unicode { get; set; }
    [Required] public List<List<char>> Drawing { get; set; } = [];
    [Required] public MatricesEnum MatrixId { get; set; }
    [ForeignKey("MatrixId")] public Matrix Matrix { get; set; } = new();
    [Required] public int AlphabetId { get; set; }
    [ForeignKey("AlphabetId")] public Alphabet Alphabet { get; set; }
}