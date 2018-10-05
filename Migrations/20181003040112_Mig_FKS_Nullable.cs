using Microsoft.EntityFrameworkCore.Migrations;

namespace bookshop.Migrations
{
    public partial class Mig_FKS_Nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "TranslatorId",
                table: "BookInsts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PublisherId",
                table: "BookInsts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "BookInsts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_BookInsts_Languages_LanguageId",
                table: "BookInsts",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInsts_Publishers_PublisherId",
                table: "BookInsts",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookInsts_Translators_TranslatorId",
                table: "BookInsts",
                column: "TranslatorId",
                principalTable: "Translators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.AlterColumn<int>(
                name: "TranslatorId",
                table: "BookInsts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PublisherId",
                table: "BookInsts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LanguageId",
                table: "BookInsts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
    }
}
