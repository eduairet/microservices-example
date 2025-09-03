using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsciiService.Data.Migrations
{
    /// <inheritdoc />
    public partial class IsActiveCheckAlphabetsAndArtworks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Artworks",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Alphabets",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Alphabets");
        }
    }
}
