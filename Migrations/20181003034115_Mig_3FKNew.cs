using Microsoft.EntityFrameworkCore.Migrations;

namespace bookshop.Migrations
{
    public partial class Mig_3FKNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "BookInsts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "BookInsts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TranslatorId",
                table: "BookInsts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookInsts_LanguageId",
                table: "BookInsts",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_BookInsts_PublisherId",
                table: "BookInsts",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_BookInsts_TranslatorId",
                table: "BookInsts",
                column: "TranslatorId");

            //@yey column yaratmadan FK yaratamya çalışıyor, burayı kapat. bir sonraki migrationa ekle
            // migrationBuilder.AddForeignKey(
            //     name: "FK_BookInsts_Languages_LanguageId",
            //     table: "BookInsts",
            //     column: "LanguageId",
            //     principalTable: "Languages",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_BookInsts_Publishers_PublisherId",
            //     table: "BookInsts",
            //     column: "PublisherId",
            //     principalTable: "Publishers",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_BookInsts_Translators_TranslatorId",
            //     table: "BookInsts",
            //     column: "TranslatorId",
            //     principalTable: "Translators",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //@yey column yaratmadan FK yaratamya çalışıyor, burayı kapat. bir sonraki migrationa ekle
            // migrationBuilder.DropForeignKey(
            //     name: "FK_BookInsts_Languages_LanguageId",
            //     table: "BookInsts");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_BookInsts_Publishers_PublisherId",
            //     table: "BookInsts");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_BookInsts_Translators_TranslatorId",
            //     table: "BookInsts");

            migrationBuilder.DropIndex(
                name: "IX_BookInsts_LanguageId",
                table: "BookInsts");

            migrationBuilder.DropIndex(
                name: "IX_BookInsts_PublisherId",
                table: "BookInsts");

            migrationBuilder.DropIndex(
                name: "IX_BookInsts_TranslatorId",
                table: "BookInsts");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "BookInsts");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "BookInsts");

            migrationBuilder.DropColumn(
                name: "TranslatorId",
                table: "BookInsts");
        }
    }
}
