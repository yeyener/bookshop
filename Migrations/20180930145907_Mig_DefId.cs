using Microsoft.EntityFrameworkCore.Migrations;

namespace bookshop.Migrations
{
    public partial class Mig_DefId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookInsts_BookDefs_DefinitionId",
                table: "BookInsts");

            migrationBuilder.AlterColumn<int>(
                name: "DefinitionId",
                table: "BookInsts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInsts_BookDefs_DefinitionId",
                table: "BookInsts",
                column: "DefinitionId",
                principalTable: "BookDefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookInsts_BookDefs_DefinitionId",
                table: "BookInsts");

            migrationBuilder.AlterColumn<int>(
                name: "DefinitionId",
                table: "BookInsts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BookInsts_BookDefs_DefinitionId",
                table: "BookInsts",
                column: "DefinitionId",
                principalTable: "BookDefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
