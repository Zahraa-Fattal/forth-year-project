using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class AddAccessoriesDateToStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AccessoriesDate",
                table: "students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "GetAccessoriesDetailsSBRs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GetItemsInStoreUnitSBRs",
                columns: table => new
                {
                    AccessoriesName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreDetailsAmount = table.Column<int>(type: "int", nullable: false),
                    StoreDetailsId = table.Column<int>(type: "int", nullable: false),
                    studentAmount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetItemsInStoreUnitSBRs");

            migrationBuilder.DropColumn(
                name: "AccessoriesDate",
                table: "students");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "GetAccessoriesDetailsSBRs");
        }
    }
}
