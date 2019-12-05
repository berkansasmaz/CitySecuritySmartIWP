using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CitySecuritySmart.Entity.Migrations
{
    public partial class AddedTableMonitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Monitor",
                columns: table => new
                {
                    MonitorId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Label = table.Column<string>(nullable: true),
                    LabelCategory = table.Column<string>(nullable: true),
                    StartTimeOffset = table.Column<string>(nullable: true),
                    EndTimeOffset = table.Column<string>(nullable: true),
                    Confidence = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitor", x => x.MonitorId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monitor");
        }
    }
}
