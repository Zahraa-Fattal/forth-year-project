using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class AddPhoneNumber__SuggestedUnitToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SuggestedUnitId",
                table: "students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GetCountrySBRs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    countryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "GetMainCitySBRs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    mainCityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "GetStudentCountInUniteSBRs",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    StudentCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetCountrySBRs");

            migrationBuilder.DropTable(
                name: "GetMainCitySBRs");

            migrationBuilder.DropTable(
                name: "GetStudentCountInUniteSBRs");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "students");

            migrationBuilder.DropColumn(
                name: "SuggestedUnitId",
                table: "students");
        }
    }
}
