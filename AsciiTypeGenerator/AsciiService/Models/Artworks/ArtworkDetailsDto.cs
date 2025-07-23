using AsciiService.Entities;

namespace AsciiService.Models.Artworks;

public class ArtworkDetailsDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Glyph> Text { get; set; } = [];
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public User Author { get; set; } = new();

    public static ArtworkDetailsDto FromEntity(Artwork artwork)
    {
        return new ArtworkDetailsDto
        {
            Id = artwork.Id,
            Title = artwork.Title,
            Description = artwork.Description,
            Text = artwork.Text,
            CreatedAt = artwork.CreatedAt,
            UpdatedAt = artwork.UpdatedAt,
            Author = artwork.Author
        };
    }
}