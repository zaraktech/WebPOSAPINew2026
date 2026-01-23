using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class shopnameadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopNamesId",
                table: "SaleItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StockReport",
                columns: table => new
                {
                    ShopName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Barcode = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseQty = table.Column<int>(type: "int", nullable: false),
                    SalesQty = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleItems_ShopNamesId",
                table: "SaleItems",
                column: "ShopNamesId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_ShopNames_ShopNamesId",
                table: "SaleItems",
                column: "ShopNamesId",
                principalTable: "ShopNames",
                principalColumn: "ShopNamesId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_ShopNames_ShopNamesId",
                table: "SaleItems");

            migrationBuilder.DropTable(
                name: "StockReport");

            migrationBuilder.DropIndex(
                name: "IX_SaleItems_ShopNamesId",
                table: "SaleItems");

            migrationBuilder.DropColumn(
                name: "ShopNamesId",
                table: "SaleItems");
        }
    }
}
