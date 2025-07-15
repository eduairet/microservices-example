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

    [Required] [MaxLength(int.MaxValue)] public string Characters { get; set; } = string.Empty;

    [Required] public string AuthorId { get; set; } = string.Empty;

    [ForeignKey("AuthorId")] public User Author { get; set; }
}