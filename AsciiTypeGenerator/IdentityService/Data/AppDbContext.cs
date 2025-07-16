using IdentityService.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Data;

public class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>()
            .ToTable("IdentityRoles")
            .HasData(
                new IdentityRole
                {
                    Id = ((int)IdentityRoles.SuperAdmin).ToString(),
                    Name = nameof(IdentityRoles.SuperAdmin),
                    NormalizedName = nameof(IdentityRoles.SuperAdmin).ToUpper()
                },
                new IdentityRole
                {
                    Id = ((int)IdentityRoles.Admin).ToString(),
                    Name = nameof(IdentityRoles.Admin),
                    NormalizedName = nameof(IdentityRoles.Admin).ToUpper()
                },
                new IdentityRole
                {
                    Id = ((int)IdentityRoles.User).ToString(),
                    Name = nameof(IdentityRoles.User),
                    NormalizedName = nameof(IdentityRoles.User).ToUpper()
                },
                new IdentityRole
                {
                    Id = ((int)IdentityRoles.Guest).ToString(),
                    Name = nameof(IdentityRoles.Guest),
                    NormalizedName = nameof(IdentityRoles.Guest).ToUpper()
                }
            );

        modelBuilder.Entity<User>().ToTable("Users");
    }
}