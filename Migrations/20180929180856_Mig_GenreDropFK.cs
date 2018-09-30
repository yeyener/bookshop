using Microsoft.EntityFrameworkCore.Migrations;

namespace bookshop.Migrations
{
    public partial class Mig_GenreDropFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDefs_Genres_GenreId",
                table: "BookDefs");

            migrationBuilder.DropIndex(
                name: "IX_BookDefs_GenreId",
                table: "BookDefs");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "BookDefs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "BookDefs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookDefs_GenreId",
                table: "BookDefs",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookDefs_Genres_GenreId",
                table: "BookDefs",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
