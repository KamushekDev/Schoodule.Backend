using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Schoodule.DataAccess.Migrations
{
    public partial class AddedClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "classes",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    lesson_id = table.Column<long>(type: "bigint", nullable: false),
                    lesson_type_id = table.Column<long>(type: "bigint", nullable: false),
                    lesson_time_id = table.Column<long>(type: "bigint", nullable: false),
                    school_id = table.Column<long>(type: "bigint", nullable: false),
                    teacher_id = table.Column<long>(type: "bigint", nullable: false),
                    group_id = table.Column<long>(type: "bigint", nullable: false),
                    room_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classes", x => x.id);
                    table.ForeignKey(
                        name: "FK_classes_groups_group_id",
                        column: x => x.group_id,
                        principalTable: "groups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classes_lesson_times_lesson_time_id",
                        column: x => x.lesson_time_id,
                        principalTable: "lesson_times",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classes_lesson_types_lesson_type_id",
                        column: x => x.lesson_type_id,
                        principalTable: "lesson_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classes_lessons_lesson_id",
                        column: x => x.lesson_id,
                        principalTable: "lessons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classes_rooms_room_id",
                        column: x => x.room_id,
                        principalTable: "rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classes_schools_school_id",
                        column: x => x.school_id,
                        principalTable: "schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classes_teachers_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "teachers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_classes_group_id",
                table: "classes",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_classes_lesson_id",
                table: "classes",
                column: "lesson_id");

            migrationBuilder.CreateIndex(
                name: "IX_classes_lesson_time_id",
                table: "classes",
                column: "lesson_time_id");

            migrationBuilder.CreateIndex(
                name: "IX_classes_lesson_type_id",
                table: "classes",
                column: "lesson_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_classes_room_id",
                table: "classes",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_classes_school_id",
                table: "classes",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "IX_classes_teacher_id",
                table: "classes",
                column: "teacher_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classes");
        }
    }
}
