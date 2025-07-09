using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserService.Entities;

namespace UserService.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = ((int)UserRoles.SuperAdmin).ToString(),
                Name = nameof(UserRoles.SuperAdmin),
                NormalizedName = nameof(UserRoles.SuperAdmin).ToUpper()
            },
            new IdentityRole
            {
                Id = ((int)UserRoles.Admin).ToString(),
                Name = nameof(UserRoles.Admin),
                NormalizedName = nameof(UserRoles.Admin).ToUpper()
            },
            new IdentityRole
            {
                Id = ((int)UserRoles.User).ToString(),
                Name = nameof(UserRoles.User),
                NormalizedName = nameof(UserRoles.User).ToUpper()
            },
            new IdentityRole
            {
                Id = ((int)UserRoles.Guest).ToString(),
                Name = nameof(UserRoles.Guest),
                NormalizedName = nameof(UserRoles.Guest).ToUpper()
            }
        );
    }

    public DbSet<User> Users { get; set; }
}