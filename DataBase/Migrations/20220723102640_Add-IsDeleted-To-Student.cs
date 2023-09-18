using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class AddIsDeletedToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                table: "GetSpecificStudentSBRs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SuggestedUnitId",
                table: "GetSpecificStudentSBRs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "unitRoomId",
                table: "GetSpecificStudentSBRs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessoriesId",
                table: "GetAccessoriesDetailsSBRs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoreDetailsId",
                table: "GetAccessoriesDetailsSBRs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GetItemsByStudentIdSBRs",
                columns: table => new
                {
                    AccessoriesName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentAccessoriesAmount = table.Column<int>(type: "int", nullable: false),
                    AccessoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "GetStudentThatHasItemsSBRs",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessoriesDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetItemsByStudentIdSBRs");

            migrationBuilder.DropTable(
                name: "GetStudentThatHasItemsSBRs");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "students");

            migrationBuilder.DropColumn(
                name: "RoomName",
                table: "GetSpecificStudentSBRs");

            migrationBuilder.DropColumn(
                name: "SuggestedUnitId",
                table: "GetSpecificStudentSBRs");

            migrationBuilder.DropColumn(
                name: "unitRoomId",
                table: "GetSpecificStudentSBRs");

            migrationBuilder.DropColumn(
                name: "AccessoriesId",
                table: "GetAccessoriesDetailsSBRs");

            migrationBuilder.DropColumn(
                name: "StoreDetailsId",
                table: "GetAccessoriesDetailsSBRs");
        }
    }
}
