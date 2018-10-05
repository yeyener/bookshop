using Microsoft.EntityFrameworkCore.Migrations;

namespace bookshop.Migrations
{
    public partial class Mig_3Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDefs_Writers_WriterId",
                table: "BookDefs");

            migrationBuilder.AlterColumn<int>(
                name: "WriterId",
                table: "BookDefs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookDefs_Writers_WriterId",
                table: "BookDefs",
                column: "WriterId",
                principalTable: "Writers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDefs_Writers_WriterId",
                table: "BookDefs");

            migrationBuilder.AlterColumn<int>(
                name: "WriterId",
                table: "BookDefs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BookDefs_Writers_WriterId",
                table: "BookDefs",
                column: "WriterId",
                principalTable: "Writers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
