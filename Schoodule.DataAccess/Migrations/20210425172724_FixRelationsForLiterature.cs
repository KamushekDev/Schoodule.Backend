using Microsoft.EntityFrameworkCore.Migrations;

namespace Schoodule.DataAccess.Migrations
{
    public partial class FixRelationsForLiterature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_literatures_lessons_LessonEntityId",
                table: "literatures");

            migrationBuilder.DropIndex(
                name: "IX_literatures_LessonEntityId",
                table: "literatures");

            migrationBuilder.DropColumn(
                name: "LessonEntityId",
                table: "literatures");

            migrationBuilder.CreateIndex(
                name: "IX_literatures_group_id",
                table: "literatures",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_literatures_lesson_id",
                table: "literatures",
                column: "lesson_id");

            migrationBuilder.AddForeignKey(
                name: "FK_literatures_groups_group_id",
                table: "literatures",
                column: "group_id",
                principalTable: "groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_literatures_lessons_lesson_id",
                table: "literatures",
                column: "lesson_id",
                principalTable: "lessons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_literatures_groups_group_id",
                table: "literatures");

            migrationBuilder.DropForeignKey(
                name: "FK_literatures_lessons_lesson_id",
                table: "literatures");

            migrationBuilder.DropIndex(
                name: "IX_literatures_group_id",
                table: "literatures");

            migrationBuilder.DropIndex(
                name: "IX_literatures_lesson_id",
                table: "literatures");

            migrationBuilder.AddColumn<long>(
                name: "LessonEntityId",
                table: "literatures",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_literatures_LessonEntityId",
                table: "literatures",
                column: "LessonEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_literatures_lessons_LessonEntityId",
                table: "literatures",
                column: "LessonEntityId",
                principalTable: "lessons",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
