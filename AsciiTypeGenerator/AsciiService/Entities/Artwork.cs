using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsciiService.Entities;

public class Artwork
{
    [Key]
    [MaxLength(int.MaxValue)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required] [MaxLength(100)] public string Title { get; set; } = string.Empty;

    [Required] [MaxLength(2000)] public string Description { get; set; } = string.Empty;

    [Required] [MaxLength(int.MaxValue)] public string Drawing { get; set; } = string.Empty;

    [Required] [MaxLength(int.MaxValue)] public string AuthorId { get; set; } = string.Empty;

    [ForeignKey("AuthorId")] public User Author { get; set; }
}