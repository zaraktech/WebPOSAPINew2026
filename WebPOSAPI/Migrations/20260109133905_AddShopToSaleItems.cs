using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddShopToSaleItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_ShopNames_ShopNamesId",
                table: "SaleItems");

            migrationBuilder.AlterColumn<int>(
                name: "ShopNamesId",
                table: "SaleItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_ShopNames_ShopNamesId",
                table: "SaleItems",
                column: "ShopNamesId",
                principalTable: "ShopNames",
                principalColumn: "ShopNamesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleItems_ShopNames_ShopNamesId",
                table: "SaleItems");

            migrationBuilder.AlterColumn<int>(
                name: "ShopNamesId",
                table: "SaleItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleItems_ShopNames_ShopNamesId",
                table: "SaleItems",
                column: "ShopNamesId",
                principalTable: "ShopNames",
                principalColumn: "ShopNamesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
