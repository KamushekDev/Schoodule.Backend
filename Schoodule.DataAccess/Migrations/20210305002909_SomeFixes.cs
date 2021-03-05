using Microsoft.EntityFrameworkCore.Migrations;

namespace Schoodule.DataAccess.Migrations
{
    public partial class SomeFixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_group_school_school_id",
                table: "group");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupEntityUserEntity_group_GroupsGroupId",
                table: "GroupEntityUserEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupEntityUserEntity_uses_UsersUserId",
                table: "GroupEntityUserEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_school_school_type_school_type_id",
                table: "school");

            migrationBuilder.DropPrimaryKey(
                name: "PK_uses",
                table: "uses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_school_type",
                table: "school_type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_school",
                table: "school");

            migrationBuilder.DropPrimaryKey(
                name: "PK_group",
                table: "group");

            migrationBuilder.RenameTable(
                name: "uses",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "school_type",
                newName: "school_types");

            migrationBuilder.RenameTable(
                name: "school",
                newName: "schools");

            migrationBuilder.RenameTable(
                name: "group",
                newName: "groups");

            migrationBuilder.RenameIndex(
                name: "IX_school_school_type_id",
                table: "schools",
                newName: "IX_schools_school_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_school_name",
                table: "schools",
                newName: "IX_schools_name");

            migrationBuilder.RenameIndex(
                name: "IX_group_school_id",
                table: "groups",
                newName: "IX_groups_school_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_school_types",
                table: "school_types",
                column: "school_type_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_schools",
                table: "schools",
                column: "school_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_groups",
                table: "groups",
                column: "group_id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupEntityUserEntity_groups_GroupsGroupId",
                table: "GroupEntityUserEntity",
                column: "GroupsGroupId",
                principalTable: "groups",
                principalColumn: "group_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupEntityUserEntity_users_UsersUserId",
                table: "GroupEntityUserEntity",
                column: "UsersUserId",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_groups_schools_school_id",
                table: "groups",
                column: "school_id",
                principalTable: "schools",
                principalColumn: "school_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_schools_school_types_school_type_id",
                table: "schools",
                column: "school_type_id",
                principalTable: "school_types",
                principalColumn: "school_type_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupEntityUserEntity_groups_GroupsGroupId",
                table: "GroupEntityUserEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupEntityUserEntity_users_UsersUserId",
                table: "GroupEntityUserEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_groups_schools_school_id",
                table: "groups");

            migrationBuilder.DropForeignKey(
                name: "FK_schools_school_types_school_type_id",
                table: "schools");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_schools",
                table: "schools");

            migrationBuilder.DropPrimaryKey(
                name: "PK_school_types",
                table: "school_types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_groups",
                table: "groups");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "uses");

            migrationBuilder.RenameTable(
                name: "schools",
                newName: "school");

            migrationBuilder.RenameTable(
                name: "school_types",
                newName: "school_type");

            migrationBuilder.RenameTable(
                name: "groups",
                newName: "group");

            migrationBuilder.RenameIndex(
                name: "IX_schools_school_type_id",
                table: "school",
                newName: "IX_school_school_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_schools_name",
                table: "school",
                newName: "IX_school_name");

            migrationBuilder.RenameIndex(
                name: "IX_groups_school_id",
                table: "group",
                newName: "IX_group_school_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_uses",
                table: "uses",
                column: "user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_school",
                table: "school",
                column: "school_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_school_type",
                table: "school_type",
                column: "school_type_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_group",
                table: "group",
                column: "group_id");

            migrationBuilder.AddForeignKey(
                name: "FK_group_school_school_id",
                table: "group",
                column: "school_id",
                principalTable: "school",
                principalColumn: "school_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupEntityUserEntity_group_GroupsGroupId",
                table: "GroupEntityUserEntity",
                column: "GroupsGroupId",
                principalTable: "group",
                principalColumn: "group_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupEntityUserEntity_uses_UsersUserId",
                table: "GroupEntityUserEntity",
                column: "UsersUserId",
                principalTable: "uses",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_school_school_type_school_type_id",
                table: "school",
                column: "school_type_id",
                principalTable: "school_type",
                principalColumn: "school_type_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
