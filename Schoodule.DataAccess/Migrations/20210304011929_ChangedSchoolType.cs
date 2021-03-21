using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Schoodule.DataAccess.Migrations
{
    public partial class ChangedSchoolType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "school_type",
                table: "school");

            migrationBuilder.AddColumn<long>(
                name: "school_type_id",
                table: "school",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "school_type",
                columns: table => new
                {
                    school_type_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_school_type", x => x.school_type_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_school_school_type_id",
                table: "school",
                column: "school_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_school_school_type_school_type_id",
                table: "school",
                column: "school_type_id",
                principalTable: "school_type",
                principalColumn: "school_type_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_school_school_type_school_type_id",
                table: "school");

            migrationBuilder.DropTable(
                name: "school_type");

            migrationBuilder.DropIndex(
                name: "IX_school_school_type_id",
                table: "school");

            migrationBuilder.DropColumn(
                name: "school_type_id",
                table: "school");

            migrationBuilder.AddColumn<int>(
                name: "school_type",
                table: "school",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
