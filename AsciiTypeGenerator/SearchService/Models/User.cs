using MongoDB.Entities;

namespace SearchService.Models;

public class User : Entity
{
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
}