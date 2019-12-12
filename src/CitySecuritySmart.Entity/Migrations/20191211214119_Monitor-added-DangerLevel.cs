using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CitySecuritySmart.Entity.Migrations
{
    public partial class MonitoraddedDangerLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DangerLevel",
                table: "Monitor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DangerLabels",
                columns: table => new
                {
                    DangerLabelId = table.Column<Guid>(nullable: false),
                    DangerLabelName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangerLabels", x => x.DangerLabelId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DangerLabels");

            migrationBuilder.DropColumn(
                name: "DangerLevel",
                table: "Monitor");
        }
    }
}
