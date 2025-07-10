using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace UserService.Entities;

[Table("Users")] // Specify the table name in the database
public class User : IdentityUser
{
    [MaxLength(100)] public string FirstName { get; set; }

    [MaxLength(100)] public string LastName { get; set; }

    [MaxLength(201)]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string FullName { get; private set; }

    [MaxLength(int.MaxValue)] public string AvatarUrl { get; set; }

    [Required] public string RoleId { get; set; } = ((int)UserRoles.User).ToString();

    [ForeignKey("RoleId")] public IdentityRole Role { get; set; }
}