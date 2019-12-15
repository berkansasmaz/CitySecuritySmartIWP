using Microsoft.EntityFrameworkCore.Migrations;

namespace CitySecuritySmart.Entity.Migrations
{
    public partial class Monitoraddednewcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uri",
                table: "Monitor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Monitor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uri",
                table: "Monitor");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Monitor");
        }
    }
}
