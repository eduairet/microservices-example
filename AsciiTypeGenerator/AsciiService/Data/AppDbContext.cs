using AsciiService.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsciiService.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Alphabet> Alphabets { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Glyph> Glyphs { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Alphabet

        modelBuilder.Entity<Alphabet>().ToTable("Alphabets")
            .HasOne(a => a.Author)
            .WithMany(u => u.Alphabets)
            .HasForeignKey(a => a.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Alphabet>().HasMany(a => a.Glyphs)
            .WithOne(g => g.Alphabet)
            .HasForeignKey(g => g.AlphabetId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Alphabet>()
            .HasIndex(a => a.Title)
            .IsUnique();

        #endregion

        #region Artwork

        modelBuilder.Entity<Artwork>().ToTable("Artworks")
            .HasIndex(a => a.Title)
            .IsUnique();
        modelBuilder.Entity<Artwork>()
            .HasOne(a => a.Author)
            .WithMany(u => u.Artworks)
            .HasForeignKey(a => a.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region Glyphs

        modelBuilder.Entity<Glyph>().ToTable("Glyphs")
            .HasOne(g => g.Alphabet)
            .WithMany(a => a.Glyphs)
            .HasForeignKey(g => g.AlphabetId)
            .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region ArtworkGlyphs

        modelBuilder.Entity<ArtworkGlyph>().ToTable("ArtworkGlyphs")
            .HasOne(ag => ag.Artwork)
            .WithMany(a => a.ArtworkGlyphs)
            .HasForeignKey(ag => ag.ArtworkId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ArtworkGlyph>()
            .HasOne(ag => ag.Glyph)
            .WithMany(g => g.ArtworkGlyphs)
            .HasForeignKey(ag => ag.GlyphId)
            .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region User

        modelBuilder.Entity<User>().ToTable("Users")
            .HasIndex(u => u.UserName)
            .IsUnique();
        modelBuilder.Entity<User>().HasMany(u => u.Artworks)
            .WithOne(a => a.Author)
            .HasForeignKey(a => a.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<User>().HasMany(u => u.Alphabets)
            .WithOne(a => a.Author)
            .HasForeignKey(a => a.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

        #endregion
    }
}