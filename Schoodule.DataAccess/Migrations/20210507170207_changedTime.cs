using Microsoft.EntityFrameworkCore.Migrations;
using NodaTime;

namespace Schoodule.DataAccess.Migrations
{
    public partial class changedTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "time",
                table: "lesson_times");

            migrationBuilder.AddColumn<int>(
                name: "duration",
                table: "lesson_times",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "hour",
                table: "lesson_times",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "minutes",
                table: "lesson_times",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "duration",
                table: "lesson_times");

            migrationBuilder.DropColumn(
                name: "hour",
                table: "lesson_times");

            migrationBuilder.DropColumn(
                name: "minutes",
                table: "lesson_times");

            migrationBuilder.AddColumn<LocalTime>(
                name: "time",
                table: "lesson_times",
                type: "time",
                nullable: false,
                defaultValue: new NodaTime.LocalTime(0, 0));
        }
    }
}
