using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AsciiService.Data.Migrations
{
    /// <inheritdoc />
    public partial class AuthorRelationsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alphabets_Users_AuthorId",
                table: "Alphabets");

            migrationBuilder.DropForeignKey(
                name: "FK_Artworks_Users_AuthorId",
                table: "Artworks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Artworks_AuthorId",
                table: "Artworks");

            migrationBuilder.DropIndex(
                name: "IX_Alphabets_AuthorId",
                table: "Alphabets");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Artworks",
                type: "text",
                maxLength: 2147483647,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Artworks",
                type: "text",
                maxLength: 2147483647,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Alphabets",
                type: "text",
                maxLength: 2147483647,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Alphabets",
                type: "text",
                maxLength: 2147483647,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Artworks");

            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Alphabets");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Artworks",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldMaxLength: 2147483647,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Alphabets",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldMaxLength: 2147483647,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", maxLength: 2147483647, nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artworks_AuthorId",
                table: "Artworks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Alphabets_AuthorId",
                table: "Alphabets",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alphabets_Users_AuthorId",
                table: "Alphabets",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Artworks_Users_AuthorId",
                table: "Artworks",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
