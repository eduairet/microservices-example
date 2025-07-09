using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace UserService.Entities;

[Table("Users")] // Specify the table name in the database
public class User : IdentityUser
{
    [MaxLength(100)] public string FirstName { get; set; }

    [MaxLength(100)] public string LastName { get; set; }

    [MaxLength(Int32.MaxValue)] public string AvatarUrl { get; set; }
}