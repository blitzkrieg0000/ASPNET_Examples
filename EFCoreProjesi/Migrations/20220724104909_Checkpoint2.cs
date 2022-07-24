using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreProjesi.Migrations
{
    public partial class Checkpoint2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categories",
                newSchema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Categories",
                schema: "dbo",
                newName: "Categories");
        }
    }
}
