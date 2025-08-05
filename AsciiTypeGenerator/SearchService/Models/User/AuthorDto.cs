namespace SearchService.Models.User;

public class AuthorDto
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
}

public static class AuthorDtoEx
{
    public static Entities.User ToEntity(AuthorDto dto) => new()
    {
        ID = dto.Id.ToString(),
        UserId = dto.UserId?.ToString(),
        UserName = dto.UserName
    };
}