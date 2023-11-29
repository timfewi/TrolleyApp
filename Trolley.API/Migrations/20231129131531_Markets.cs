using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Trolley.API.Migrations
{
    /// <inheritdoc />
    public partial class Markets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Market",
                columns: new[] { "Id", "MarketCategory", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Billa" },
                    { 2, 0, "Spar" },
                    { 3, 0, "Hofer" },
                    { 4, 0, "Lidl" },
                    { 5, 0, "Penny" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Market",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Market",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Market",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Market",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Market",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
