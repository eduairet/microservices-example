using SearchService.Models.ArtworkGlyph;

namespace SearchService.Models.Artwork;

public class ArtworkDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public string AuthorName { get; set; }
    public List<ArtworkGlyphDto> ArtworkGlyphs { get; set; }

    public static Entities.Artwork ToEntity(ArtworkDto dto) => new()
    {
        ID = dto.Id.ToString(),
        Title = dto.Title,
        Description = dto.Description,
        CreatedAt = dto.CreatedAt,
        UpdatedAt = dto.UpdatedAt,
        AuthorName = dto.AuthorName,
        ArtworkGlyphs = dto.ArtworkGlyphs.Select(ArtworkGlyphDto.ToEntity).ToList()
    };

    public static Entities.Artwork ToEntity(Contracts.ArtworkContract contract) => new()
    {
        ID = contract.Id.ToString(),
        Title = contract.Title,
        Description = contract.Description,
        CreatedAt = contract.CreatedAt,
        UpdatedAt = contract.UpdatedAt,
        AuthorName = contract.AuthorName,
        ArtworkGlyphs = contract.ArtworkGlyphs.Select(ArtworkGlyphDto.ToEntity).ToList()
    };
}