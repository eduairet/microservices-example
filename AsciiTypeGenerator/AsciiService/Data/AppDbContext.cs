using AsciiService.Entities;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace AsciiService.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Alphabet> Alphabets { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Glyph> Glyphs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Alphabet

        modelBuilder.Entity<Alphabet>().ToTable("Alphabets")
            .HasMany(a => a.Glyphs)
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
            .HasMany(a => a.ArtworkGlyphs)
            .WithOne(ag => ag.Artwork)
            .HasForeignKey(ag => ag.ArtworkId)
            .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region Glyphs

        modelBuilder.Entity<Glyph>().ToTable("Glyphs")
            .HasOne(g => g.Alphabet)
            .WithMany(a => a.Glyphs)
            .HasForeignKey(g => g.AlphabetId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Glyph>()
            .HasIndex(g => new { g.AlphabetId, g.Unicode })
            .IsUnique();

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
        modelBuilder.Entity<ArtworkGlyph>()
            .HasIndex(ag => new { ag.ArtworkId, ag.Index })
            .IsUnique();

        #endregion

        #region OutboxMessage

        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();

        #endregion
    }
}