using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace UserService.Entities;

public class User : IdentityUser
{
    [MaxLength(100)] public string FirstName { get; set; }

    [MaxLength(100)] public string LastName { get; set; }

    [MaxLength(int.MaxValue)] public string AvatarUrl { get; set; }

    [Required] [MaxLength(50)] public string RoleId { get; set; } = ((int)IdentityRoles.User).ToString();

    [ForeignKey("RoleId")] public IdentityRole Role { get; set; }
}