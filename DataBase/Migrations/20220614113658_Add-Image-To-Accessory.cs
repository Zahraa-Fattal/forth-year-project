using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class AddImageToAccessory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RecordedDate",
                table: "GetStudentInRoomSBRs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StudentCount",
                table: "GetStudentInRoomSBRs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "accessories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GetAccessoriesDetailsSBRs",
                columns: table => new
                {
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "GetAllRecorderStudentsSBRs",
                columns: table => new
                {
                    studentId = table.Column<int>(type: "int", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UniversityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetAccessoriesDetailsSBRs");

            migrationBuilder.DropTable(
                name: "GetAllRecorderStudentsSBRs");

            migrationBuilder.DropColumn(
                name: "RecordedDate",
                table: "GetStudentInRoomSBRs");

            migrationBuilder.DropColumn(
                name: "StudentCount",
                table: "GetStudentInRoomSBRs");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "accessories");
        }
    }
}
