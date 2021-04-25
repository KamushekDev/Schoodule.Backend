using Microsoft.EntityFrameworkCore.Migrations;

namespace Schoodule.DataAccess.Migrations
{
    public partial class SS_35Fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reference",
                table: "literatures");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "literatures",
                type: "character varying(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AddColumn<string>(
                name: "uri",
                table: "literatures",
                type: "character varying(1024)",
                maxLength: 1024,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "uri",
                table: "literatures");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "literatures",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AddColumn<string>(
                name: "reference",
                table: "literatures",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
