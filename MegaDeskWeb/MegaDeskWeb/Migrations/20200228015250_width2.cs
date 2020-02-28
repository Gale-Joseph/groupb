using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDeskWeb.Migrations
{
    public partial class width2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "width2",
                table: "Quote",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "width2",
                table: "Quote");
        }
    }
}
