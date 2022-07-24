using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreProjesi.Migrations
{
    public partial class oneToManyWithNavigationFA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleHistory_Products_ProductId",
                table: "SaleHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleHistory",
                table: "SaleHistory");

            migrationBuilder.RenameTable(
                name: "SaleHistory",
                newName: "SaleHistories");

            migrationBuilder.RenameIndex(
                name: "IX_SaleHistory_ProductId",
                table: "SaleHistories",
                newName: "IX_SaleHistories_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleHistories",
                table: "SaleHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleHistories_Products_ProductId",
                table: "SaleHistories",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleHistories_Products_ProductId",
                table: "SaleHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleHistories",
                table: "SaleHistories");

            migrationBuilder.RenameTable(
                name: "SaleHistories",
                newName: "SaleHistory");

            migrationBuilder.RenameIndex(
                name: "IX_SaleHistories_ProductId",
                table: "SaleHistory",
                newName: "IX_SaleHistory_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleHistory",
                table: "SaleHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleHistory_Products_ProductId",
                table: "SaleHistory",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
