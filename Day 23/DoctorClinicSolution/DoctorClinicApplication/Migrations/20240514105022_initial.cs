using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorClinicApplication.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Age", "Experience", "Name", "Qualification", "Speciality" },
                values: new object[] { 101, 25, 12, "Kavin", "MBBS.,", "Cardio" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Age", "Experience", "Name", "Qualification", "Speciality" },
                values: new object[] { 102, 35, 15, "Pravin", "MBBS.,", "Ortho" });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Age", "Experience", "Name", "Qualification", "Speciality" },
                values: new object[] { 103, 45, 22, "Raja", "MBBS.,M.sc.,", "Cardio" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");
        }
    }
}
