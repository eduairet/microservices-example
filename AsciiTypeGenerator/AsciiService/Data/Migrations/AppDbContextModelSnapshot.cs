﻿// <auto-generated />
using System;
using AsciiService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AsciiService.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AsciiService.Entities.Alphabet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Alphabets", (string)null);
                });

            modelBuilder.Entity("AsciiService.Entities.Artwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("Artworks", (string)null);
                });

            modelBuilder.Entity("AsciiService.Entities.Glyph", b =>
                {
                    b.Property<string>("Name")
                        .HasMaxLength(2147483647)
                        .HasColumnType("text");

                    b.Property<int>("AlphabetId")
                        .HasColumnType("integer");

                    b.Property<int?>("ArtworkId")
                        .HasColumnType("integer");

                    b.Property<string>("DrawingSerialized")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("text");

                    b.Property<int>("MatrixId")
                        .HasColumnType("integer");

                    b.Property<int>("Unicode")
                        .HasColumnType("integer");

                    b.HasKey("Name");

                    b.HasIndex("AlphabetId");

                    b.HasIndex("ArtworkId");

                    b.HasIndex("MatrixId");

                    b.ToTable("Glyphs", (string)null);
                });

            modelBuilder.Entity("AsciiService.Entities.Matrix", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Depth")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("Depth")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Matrices", (string)null);
                });

            modelBuilder.Entity("AsciiService.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("AsciiService.Entities.Alphabet", b =>
                {
                    b.HasOne("AsciiService.Entities.User", "Author")
                        .WithMany("Alphabets")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("AsciiService.Entities.Artwork", b =>
                {
                    b.HasOne("AsciiService.Entities.User", "Author")
                        .WithMany("Artworks")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("AsciiService.Entities.Glyph", b =>
                {
                    b.HasOne("AsciiService.Entities.Alphabet", "Alphabet")
                        .WithMany("Glyphs")
                        .HasForeignKey("AlphabetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AsciiService.Entities.Artwork", null)
                        .WithMany("Text")
                        .HasForeignKey("ArtworkId");

                    b.HasOne("AsciiService.Entities.Matrix", "Matrix")
                        .WithMany()
                        .HasForeignKey("MatrixId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alphabet");

                    b.Navigation("Matrix");
                });

            modelBuilder.Entity("AsciiService.Entities.Alphabet", b =>
                {
                    b.Navigation("Glyphs");
                });

            modelBuilder.Entity("AsciiService.Entities.Artwork", b =>
                {
                    b.Navigation("Text");
                });

            modelBuilder.Entity("AsciiService.Entities.User", b =>
                {
                    b.Navigation("Alphabets");

                    b.Navigation("Artworks");
                });
#pragma warning restore 612, 618
        }
    }
}
