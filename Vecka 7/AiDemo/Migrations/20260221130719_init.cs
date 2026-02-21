using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AiDemo.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMovies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UserMovies",
                columns: new[] { "Id", "Genre", "Rating", "Title" },
                values: new object[,]
                {
                    { 1, "Sci-Fi", 5, "Inception" },
                    { 2, "Sci-Fi", 5, "Interstellar" },
                    { 3, "Sci-Fi", 5, "The Matrix" },
                    { 4, "Action", 4, "John Wick" },
                    { 5, "Action", 4, "Mad Max: Fury Road" },
                    { 6, "Romance", 2, "The Notebook" },
                    { 7, "Romance", 3, "Titanic" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserMovies");
        }
    }
}
