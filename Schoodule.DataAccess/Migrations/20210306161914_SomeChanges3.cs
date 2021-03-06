using Microsoft.EntityFrameworkCore.Migrations;

namespace Schoodule.DataAccess.Migrations
{
    public partial class SomeChanges3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_groups_id_name",
                table: "groups");

            migrationBuilder.DropIndex(
                name: "IX_groups_school_id",
                table: "groups");

            migrationBuilder.CreateIndex(
                name: "IX_groups_school_id_name",
                table: "groups",
                columns: new[] { "school_id", "name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_groups_school_id_name",
                table: "groups");

            migrationBuilder.CreateIndex(
                name: "IX_groups_id_name",
                table: "groups",
                columns: new[] { "id", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_groups_school_id",
                table: "groups",
                column: "school_id");
        }
    }
}
