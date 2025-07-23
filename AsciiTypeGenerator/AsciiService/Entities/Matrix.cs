using System.ComponentModel.DataAnnotations;

namespace AsciiService.Entities;

public class Matrix
{
    [Key] public int Id { get; set; }
    [Required] [MaxLength(100)] public string Name { get; set; } = string.Empty;
    [Required] public int Depth { get; set; }
}