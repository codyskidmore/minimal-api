using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Api.Migrations.Library
{
    /// <inheritdoc />
    public partial class addisbnindex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Isbn",
                schema: "Library",
                table: "books",
                type: "varchar(13)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_books_Isbn",
                schema: "Library",
                table: "books",
                column: "Isbn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_books_Isbn",
                schema: "Library",
                table: "books");

            migrationBuilder.AlterColumn<string>(
                name: "Isbn",
                schema: "Library",
                table: "books",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(13)");
        }
    }
}
