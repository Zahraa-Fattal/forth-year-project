using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class AddDateToStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RecordedDate",
                table: "students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UnitName",
                table: "GetStudentCountInUniteSBRs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentCount",
                table: "GetAllUnitsInfoSBRs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GetAllUnRecordedStudentsSBRs",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "GetFreeRoomsByUnitIdSBRs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "GetRoomsInUnitSBRs",
                columns: table => new
                {
                    StudentCount = table.Column<int>(type: "int", nullable: false),
                    unitRoomsId = table.Column<int>(type: "int", nullable: false),
                    roomName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "GetSpecificStudentSBRs",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false),
                    studentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudyBranchId = table.Column<int>(type: "int", nullable: false),
                    studyBranchesName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    studentCityId = table.Column<int>(type: "int", nullable: false),
                    mainOrCountryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mainCityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainCity = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "GetStudentInRoomSBRs",
                columns: table => new
                {
                    studentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitRoomsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetAllUnRecordedStudentsSBRs");

            migrationBuilder.DropTable(
                name: "GetFreeRoomsByUnitIdSBRs");

            migrationBuilder.DropTable(
                name: "GetRoomsInUnitSBRs");

            migrationBuilder.DropTable(
                name: "GetSpecificStudentSBRs");

            migrationBuilder.DropTable(
                name: "GetStudentInRoomSBRs");

            migrationBuilder.DropColumn(
                name: "RecordedDate",
                table: "students");

            migrationBuilder.DropColumn(
                name: "UnitName",
                table: "GetStudentCountInUniteSBRs");

            migrationBuilder.DropColumn(
                name: "StudentCount",
                table: "GetAllUnitsInfoSBRs");
        }
    }
}
