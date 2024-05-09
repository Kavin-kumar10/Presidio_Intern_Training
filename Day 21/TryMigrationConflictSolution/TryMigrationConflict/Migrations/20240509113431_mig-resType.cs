using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TryMigrationConflict.Migrations
{
    public partial class migresType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResponseType",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponseType",
                table: "Requests");
        }
    }
}
