using Microsoft.EntityFrameworkCore.Migrations;

namespace Schoodule.DataAccess.Migrations
{
    public partial class SomeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "room",
                table: "rooms",
                newName: "name");

            migrationBuilder.CreateIndex(
                name: "IX_groups_id_name",
                table: "groups",
                columns: new[] { "id", "name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_groups_id_name",
                table: "groups");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "rooms",
                newName: "room");
        }
    }
}
