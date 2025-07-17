using AsciiService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsciiService.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Alphabet> Alphabets { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Alphabet>().ToTable("Alphabets").HasIndex(a => a.Title).IsUnique();
        modelBuilder.Entity<Artwork>().ToTable("Artworks");
        modelBuilder.Entity<User>().ToTable("Users");
    }
}