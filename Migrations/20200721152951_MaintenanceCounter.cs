using Microsoft.EntityFrameworkCore.Migrations;

namespace Zedx.Migrations
{
    public partial class MaintenanceCounter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaintenanceCounter",
                columns: table => new
                {
                    MaintenanceCounterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColumnName = table.Column<string>(nullable: true),
                    TableName = table.Column<string>(nullable: true),
                    Counter = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceCounter", x => x.MaintenanceCounterId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaintenanceCounter");
        }
    }
}
