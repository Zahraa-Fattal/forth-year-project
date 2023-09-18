using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class fixdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentDates_timeSlotes_TimeSloteId",
                table: "studentDates");

            migrationBuilder.DropTable(
                name: "timeSlotes");

            migrationBuilder.DropIndex(
                name: "IX_studentDates_TimeSloteId",
                table: "studentDates");

            migrationBuilder.DropColumn(
                name: "TimeSloteId",
                table: "studentDates");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "studentDates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "vacationDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vacationDates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vacationDates");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "students");

            migrationBuilder.DropColumn(
                name: "date",
                table: "studentDates");

            migrationBuilder.AddColumn<int>(
                name: "TimeSloteId",
                table: "studentDates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "timeSlotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    slote = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timeSlotes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_studentDates_TimeSloteId",
                table: "studentDates",
                column: "TimeSloteId");

            migrationBuilder.AddForeignKey(
                name: "FK_studentDates_timeSlotes_TimeSloteId",
                table: "studentDates",
                column: "TimeSloteId",
                principalTable: "timeSlotes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
