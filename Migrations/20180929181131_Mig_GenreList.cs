using Microsoft.EntityFrameworkCore.Migrations;

namespace bookshop.Migrations
{
    public partial class Mig_GenreList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookDefId",
                table: "Genres",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_BookDefId",
                table: "Genres",
                column: "BookDefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genres_BookDefs_BookDefId",
                table: "Genres",
                column: "BookDefId",
                principalTable: "BookDefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genres_BookDefs_BookDefId",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_BookDefId",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "BookDefId",
                table: "Genres");
        }
    }
}
