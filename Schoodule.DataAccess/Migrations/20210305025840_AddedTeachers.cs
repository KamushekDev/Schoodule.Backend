using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Schoodule.DataAccess.Migrations
{
    public partial class AddedTeachers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupEntityUserEntity_groups_GroupsGroupId",
                table: "GroupEntityUserEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupEntityUserEntity_users_UsersUserId",
                table: "GroupEntityUserEntity");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "GroupEntityUserEntity",
                newName: "UsersId");

            migrationBuilder.RenameColumn(
                name: "GroupsGroupId",
                table: "GroupEntityUserEntity",
                newName: "GroupsId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupEntityUserEntity_UsersUserId",
                table: "GroupEntityUserEntity",
                newName: "IX_GroupEntityUserEntity_UsersId");

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    school_id = table.Column<long>(type: "bigint", nullable: false),
                    room = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    uri = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.id);
                    table.ForeignKey(
                        name: "FK_rooms_schools_school_id",
                        column: x => x.school_id,
                        principalTable: "schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SchoolId = table.Column<long>(type: "bigint", nullable: false),
                    firstname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    lastname = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    patronymic = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.id);
                    table.ForeignKey(
                        name: "FK_teachers_schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "schools",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rooms_school_id",
                table: "rooms",
                column: "school_id");

            migrationBuilder.CreateIndex(
                name: "IX_teachers_SchoolId",
                table: "teachers",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupEntityUserEntity_groups_GroupsId",
                table: "GroupEntityUserEntity",
                column: "GroupsId",
                principalTable: "groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupEntityUserEntity_users_UsersId",
                table: "GroupEntityUserEntity",
                column: "UsersId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupEntityUserEntity_groups_GroupsId",
                table: "GroupEntityUserEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupEntityUserEntity_users_UsersId",
                table: "GroupEntityUserEntity");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "teachers");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "GroupEntityUserEntity",
                newName: "UsersUserId");

            migrationBuilder.RenameColumn(
                name: "GroupsId",
                table: "GroupEntityUserEntity",
                newName: "GroupsGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupEntityUserEntity_UsersId",
                table: "GroupEntityUserEntity",
                newName: "IX_GroupEntityUserEntity_UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupEntityUserEntity_groups_GroupsGroupId",
                table: "GroupEntityUserEntity",
                column: "GroupsGroupId",
                principalTable: "groups",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupEntityUserEntity_users_UsersUserId",
                table: "GroupEntityUserEntity",
                column: "UsersUserId",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
