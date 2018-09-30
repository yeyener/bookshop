using Microsoft.EntityFrameworkCore.Migrations;

namespace bookshop.Migrations
{
    public partial class Mig_Redund1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BookName",
                table: "BookInsts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WriterName",
                table: "BookInsts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookName",
                table: "BookInsts");

            migrationBuilder.DropColumn(
                name: "WriterName",
                table: "BookInsts");
        }
    }
}
