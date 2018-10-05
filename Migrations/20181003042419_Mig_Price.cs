using Microsoft.EntityFrameworkCore.Migrations;

namespace bookshop.Migrations
{
    public partial class Mig_Price : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "BookInsts",
                nullable: false,
                defaultValue: 0m);               
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "BookInsts");

        }
    }
}
