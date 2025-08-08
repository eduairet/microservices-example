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
    public AuthorDto Author { get; set; }
    public List<ArtworkGlyphDto> ArtworkGlyphs { get; set; }

    public static Entities.Artwork ToEntity(ArtworkDto dto) => new()
    {
        ID = dto.Id.ToString(),
        Title = dto.Title,
        Description = dto.Description,
        CreatedAt = dto.CreatedAt,
        UpdatedAt = dto.UpdatedAt,
        Author = dto.Author is null ? null : AuthorDto.ToEntity(dto.Author),
        ArtworkGlyphs = dto.ArtworkGlyphs.Select(ArtworkGlyphDto.ToEntity).ToList()
    };

    public static Entities.Artwork ToEntity(Contracts.ArtworkContract contract) => new()
    {
        ID = contract.Id.ToString(),
        Title = contract.Title,
        Description = contract.Description,
        CreatedAt = contract.CreatedAt,
        UpdatedAt = contract.UpdatedAt,
        Author = AuthorDto.ToEntity(contract.Author),
        ArtworkGlyphs = contract.ArtworkGlyphs.Select(ArtworkGlyphDto.ToEntity).ToList()
    };
}