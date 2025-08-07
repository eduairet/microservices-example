namespace Contracts;

public sealed class UserContract
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public List<ArtworkContract> Artworks { get; set; } = [];
    public List<AlphabetContract> Alphabets { get; set; } = [];
}