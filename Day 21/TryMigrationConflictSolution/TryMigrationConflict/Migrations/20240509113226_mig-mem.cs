using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TryMigrationConflict.Migrations
{
    public partial class migmem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "membership",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "membership",
                table: "Employees");
        }
    }
}
