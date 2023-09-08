using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Api.Migrations.Library
{
    /// <inheritdoc />
    public partial class makeisbnindexunique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_books_Isbn",
                schema: "Library",
                table: "books");

            migrationBuilder.CreateIndex(
                name: "IX_books_Isbn",
                schema: "Library",
                table: "books",
                column: "Isbn",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_books_Isbn",
                schema: "Library",
                table: "books");

            migrationBuilder.CreateIndex(
                name: "IX_books_Isbn",
                schema: "Library",
                table: "books",
                column: "Isbn");
        }
    }
}
