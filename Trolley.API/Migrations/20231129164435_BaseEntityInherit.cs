using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trolley.API.Migrations
{
    /// <inheritdoc />
    public partial class BaseEntityInherit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ShoppingListUser",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductShoppingList",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MarketProduct",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "MarketProduct",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BrandProduct",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShoppingListUser");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductShoppingList");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MarketProduct");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "MarketProduct");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BrandProduct");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Product",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
