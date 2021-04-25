using Microsoft.EntityFrameworkCore.Migrations;

namespace Schoodule.DataAccess.Migrations
{
    public partial class RenamedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lessons_schools_group_id",
                table: "lessons");

            migrationBuilder.RenameColumn(
                name: "group_id",
                table: "lessons",
                newName: "school_id");

            migrationBuilder.RenameIndex(
                name: "IX_lessons_group_id",
                table: "lessons",
                newName: "IX_lessons_school_id");

            migrationBuilder.AddForeignKey(
                name: "FK_lessons_schools_school_id",
                table: "lessons",
                column: "school_id",
                principalTable: "schools",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_lessons_schools_school_id",
                table: "lessons");

            migrationBuilder.RenameColumn(
                name: "school_id",
                table: "lessons",
                newName: "group_id");

            migrationBuilder.RenameIndex(
                name: "IX_lessons_school_id",
                table: "lessons",
                newName: "IX_lessons_group_id");

            migrationBuilder.AddForeignKey(
                name: "FK_lessons_schools_group_id",
                table: "lessons",
                column: "group_id",
                principalTable: "schools",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
