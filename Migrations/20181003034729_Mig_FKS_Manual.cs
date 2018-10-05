using Microsoft.EntityFrameworkCore.Migrations;

namespace bookshop.Migrations
{
    public partial class Mig_FKS_Manual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_BookInsts_Languages_LanguageId",
                table: "BookInsts",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInsts_Publishers_PublisherId",
                table: "BookInsts",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInsts_Translators_TranslatorId",
                table: "BookInsts",
                column: "TranslatorId",
                principalTable: "Translators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookInsts_Languages_LanguageId",
                table: "BookInsts");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInsts_Publishers_PublisherId",
                table: "BookInsts");

            migrationBuilder.DropForeignKey(
                name: "FK_BookInsts_Translators_TranslatorId",
                table: "BookInsts");
        }
    }
}
