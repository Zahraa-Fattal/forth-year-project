using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class AddUserNameToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "user",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "GetSuperVisorInfoSBRs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "GetSuperVisorInfoSBRs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SuperVisorId",
                table: "GetSuperVisorInfoSBRs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "GetAllUnitsInfoSBRs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GetFreeStoreKeeperSBRs",
                columns: table => new
                {
                    StoreKeeperId = table.Column<int>(type: "int", nullable: false),
                    StoreKeeperName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "GetFreeStoreSBRs",
                columns: table => new
                {
                    unitStoresId = table.Column<int>(type: "int", nullable: false),
                    unitStoresName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "GetFreeSuperVisorSBRs",
                columns: table => new
                {
                    SuperVisorId = table.Column<int>(type: "int", nullable: false),
                    SuperVisorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "GetSpecificUnitSBRs",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "int", nullable: false),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuperVisorId = table.Column<int>(type: "int", nullable: false),
                    SuperVisorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreKeeperId = table.Column<int>(type: "int", nullable: false),
                    StoreKeeperName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    studyBranchesId = table.Column<int>(type: "int", nullable: false),
                    studyBrancheName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitStoresId = table.Column<int>(type: "int", nullable: false),
                    unitStoreName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "GetStoreKeeperInfoSBRs",
                columns: table => new
                {
                    StoreKeeperId = table.Column<int>(type: "int", nullable: false),
                    StoreKeeperName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    unitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GetFreeStoreKeeperSBRs");

            migrationBuilder.DropTable(
                name: "GetFreeStoreSBRs");

            migrationBuilder.DropTable(
                name: "GetFreeSuperVisorSBRs");

            migrationBuilder.DropTable(
                name: "GetSpecificUnitSBRs");

            migrationBuilder.DropTable(
                name: "GetStoreKeeperInfoSBRs");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "user");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "GetSuperVisorInfoSBRs");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "GetSuperVisorInfoSBRs");

            migrationBuilder.DropColumn(
                name: "SuperVisorId",
                table: "GetSuperVisorInfoSBRs");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "GetAllUnitsInfoSBRs");
        }
    }
}
