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
                    Id = ((int)IdentityRolesEnum.SuperAdmin).ToString(),
                    Name = nameof(IdentityRolesEnum.SuperAdmin),
                    NormalizedName = nameof(IdentityRolesEnum.SuperAdmin).ToUpper()
                },
                new IdentityRole
                {
                    Id = ((int)IdentityRolesEnum.Admin).ToString(),
                    Name = nameof(IdentityRolesEnum.Admin),
                    NormalizedName = nameof(IdentityRolesEnum.Admin).ToUpper()
                },
                new IdentityRole
                {
                    Id = ((int)IdentityRolesEnum.User).ToString(),
                    Name = nameof(IdentityRolesEnum.User),
                    NormalizedName = nameof(IdentityRolesEnum.User).ToUpper()
                },
                new IdentityRole
                {
                    Id = ((int)IdentityRolesEnum.Guest).ToString(),
                    Name = nameof(IdentityRolesEnum.Guest),
                    NormalizedName = nameof(IdentityRolesEnum.Guest).ToUpper()
                }
            );

        modelBuilder.Entity<User>().ToTable("Users");
    }
}