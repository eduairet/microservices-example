using SearchService.Models.ArtworkGlyph;
using SearchService.Models.User;

namespace SearchService.Models.Artwork;

public class ArtworkDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public AuthorDto Author { get; set; } = new();
    public List<ArtworkGlyphDto> ArtworkGlyphs { get; set; } = [];
}

public static class ArtworkDtoEx
{
    public static Entities.Artwork ToEntity(ArtworkDto dto) => new()
    {
        ID = dto.Id.ToString(),
        Title = dto.Title,
        Description = dto.Description,
        CreatedAt = dto.CreatedAt,
        UpdatedAt = dto.UpdatedAt,
        Author = dto.Author is null ? null: AuthorDtoEx.ToEntity(dto.Author),
        ArtworkGlyphs = dto.ArtworkGlyphs.Select(ArtworkGlyphDtoEx.ToEntity).ToList()
    };
}