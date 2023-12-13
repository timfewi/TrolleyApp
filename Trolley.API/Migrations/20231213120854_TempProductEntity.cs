using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trolley.API.Migrations
{
    /// <inheritdoc />
    public partial class TempProductEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TempProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarketName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOrganic = table.Column<bool>(type: "bit", nullable: false),
                    IsDiscountProduct = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempProducts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d6d60c8-ae2b-47c5-a7e8-50535cf5bfb8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18594e19-4ada-4696-a181-b17b57fcd4f5", "AQAAAAIAAYagAAAAEFnX8o++5S42PmN5KuYvuk87IzviFr2PnxRvm+M3Wi0B1iiHDm3VnaSsPY5eU2hctw==", "9cd9e0ed-a870-48f3-87a9-3641a0f37fe6" });

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                column: "Price",
                value: 1.5900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 2 },
                column: "Price",
                value: 2.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 3 },
                column: "Price",
                value: 1.3900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 4 },
                column: "Price",
                value: 5.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 5 },
                column: "Price",
                value: 6.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 6 },
                column: "Price",
                value: 4.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 7 },
                column: "Price",
                value: 6.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 8 },
                column: "Price",
                value: 7.9900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 9 },
                column: "Price",
                value: 5.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 10 },
                column: "Price",
                value: 6.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 11 },
                column: "Price",
                value: 9.4900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 12 },
                column: "Price",
                value: 5.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 14 },
                column: "Price",
                value: 8.2899999999999991);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 15 },
                column: "Price",
                value: 6.9900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 16 },
                column: "Price",
                value: 2.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 17 },
                column: "Price",
                value: 3.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 18 },
                column: "Price",
                value: 1.99);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 19 },
                column: "Price",
                value: 2.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 20 },
                column: "Price",
                value: 3.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 21 },
                column: "Price",
                value: 1.1900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 22 },
                column: "Price",
                value: 2.1899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 23 },
                column: "Price",
                value: 3.1899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 24 },
                column: "Price",
                value: 1.8900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 25 },
                column: "Price",
                value: 1.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 26 },
                column: "Price",
                value: 2.9899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 27 },
                column: "Price",
                value: 0.98999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 28 },
                column: "Price",
                value: 2.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 29 },
                column: "Price",
                value: 3.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 30 },
                column: "Price",
                value: 1.8900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 31 },
                column: "Price",
                value: 2.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 32 },
                column: "Price",
                value: 3.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 33 },
                column: "Price",
                value: 1.1900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 37 },
                column: "Price",
                value: 2.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 38 },
                column: "Price",
                value: 3.9899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 40 },
                column: "Price",
                value: 3.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 41 },
                column: "Price",
                value: 4.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 42 },
                column: "Price",
                value: 2.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 43 },
                column: "Price",
                value: 0.58999999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 44 },
                column: "Price",
                value: 1.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 47 },
                column: "Price",
                value: 6.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 48 },
                column: "Price",
                value: 4.6899999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 49 },
                column: "Price",
                value: 5.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 50 },
                column: "Price",
                value: 6.6899999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 51 },
                column: "Price",
                value: 4.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 52 },
                column: "Price",
                value: 1.1900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 54 },
                column: "Price",
                value: 0.98999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 55 },
                column: "Price",
                value: 2.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 57 },
                column: "Price",
                value: 1.0900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 58 },
                column: "Price",
                value: 0.89000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 60 },
                column: "Price",
                value: 0.29000000000000004);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 61 },
                column: "Price",
                value: 0.89000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 62 },
                column: "Price",
                value: 1.8900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 63 },
                column: "Price",
                value: 0.39000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 64 },
                column: "Price",
                value: 1.49);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 65 },
                column: "Price",
                value: 2.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 67 },
                column: "Price",
                value: 2.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 68 },
                column: "Price",
                value: 3.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 69 },
                column: "Price",
                value: 1.1900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 70 },
                column: "Price",
                value: 2.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 71 },
                column: "Price",
                value: 3.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 72 },
                column: "Price",
                value: 1.1900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 76 },
                column: "Price",
                value: 2.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 78 },
                column: "Price",
                value: 1.8900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 80 },
                column: "Price",
                value: 1.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 81 },
                column: "Price",
                value: 0.39000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 82 },
                column: "Price",
                value: 0.58999999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 83 },
                column: "Price",
                value: 1.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 84 },
                column: "Price",
                value: 0.48999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 85 },
                column: "Price",
                value: 0.68999999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 86 },
                column: "Price",
                value: 1.99);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 88 },
                column: "Price",
                value: 1.0900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 89 },
                column: "Price",
                value: 2.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 90 },
                column: "Price",
                value: 0.98999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 91 },
                column: "Price",
                value: 0.78999999999999992);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 92 },
                column: "Price",
                value: 1.49);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 93 },
                column: "Price",
                value: 0.29000000000000004);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 94 },
                column: "Price",
                value: 0.78999999999999992);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 95 },
                column: "Price",
                value: 1.1900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 98 },
                column: "Price",
                value: 1.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 99 },
                column: "Price",
                value: 0.48999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 100 },
                column: "Price",
                value: 2.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 101 },
                column: "Price",
                value: 3.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 102 },
                column: "Price",
                value: 1.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 1 },
                column: "Price",
                value: 1.8900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 2 },
                column: "Price",
                value: 2.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 3 },
                column: "Price",
                value: 1.1900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 4 },
                column: "Price",
                value: 5.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 5 },
                column: "Price",
                value: 6.1899999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 6 },
                column: "Price",
                value: 4.6899999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 7 },
                column: "Price",
                value: 6.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 8 },
                column: "Price",
                value: 7.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 9 },
                column: "Price",
                value: 5.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 10 },
                column: "Price",
                value: 6.1899999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 11 },
                column: "Price",
                value: 8.8900000000000006);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 12 },
                column: "Price",
                value: 5.9900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 13 },
                column: "Price",
                value: 6.6899999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 14 },
                column: "Price",
                value: 9.8900000000000006);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 15 },
                column: "Price",
                value: 6.9900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 16 },
                column: "Price",
                value: 2.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 17 },
                column: "Price",
                value: 3.1899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 18 },
                column: "Price",
                value: 1.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 19 },
                column: "Price",
                value: 2.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 21 },
                column: "Price",
                value: 1.3900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 22 },
                column: "Price",
                value: 2.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 23 },
                column: "Price",
                value: 3.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 24 },
                column: "Price",
                value: 1.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 25 },
                column: "Price",
                value: 1.0900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 26 },
                column: "Price",
                value: 2.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 27 },
                column: "Price",
                value: 0.89000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 28 },
                column: "Price",
                value: 2.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 29 },
                column: "Price",
                value: 3.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 30 },
                column: "Price",
                value: 1.0900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 31 },
                column: "Price",
                value: 2.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 33 },
                column: "Price",
                value: 1.49);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 37 },
                column: "Price",
                value: 2.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 38 },
                column: "Price",
                value: 3.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 39 },
                column: "Price",
                value: 1.1900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 40 },
                column: "Price",
                value: 3.9899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 41 },
                column: "Price",
                value: 4.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 42 },
                column: "Price",
                value: 2.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 43 },
                column: "Price",
                value: 0.98999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 44 },
                column: "Price",
                value: 1.49);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 45 },
                column: "Price",
                value: 0.39000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 46 },
                column: "Price",
                value: 5.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 47 },
                column: "Price",
                value: 6.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 48 },
                column: "Price",
                value: 4.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 49 },
                column: "Price",
                value: 5.1899999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 50 },
                column: "Price",
                value: 6.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 51 },
                column: "Price",
                value: 4.6899999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 52 },
                column: "Price",
                value: 1.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 53 },
                column: "Price",
                value: 2.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 54 },
                column: "Price",
                value: 0.78999999999999992);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 55 },
                column: "Price",
                value: 2.1899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 56 },
                column: "Price",
                value: 3.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 57 },
                column: "Price",
                value: 1.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 58 },
                column: "Price",
                value: 0.58999999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 59 },
                column: "Price",
                value: 1.3900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 60 },
                column: "Price",
                value: 0.48999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 61 },
                column: "Price",
                value: 0.98999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 62 },
                column: "Price",
                value: 1.1900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 63 },
                column: "Price",
                value: 0.39000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 64 },
                column: "Price",
                value: 1.8900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 65 },
                column: "Price",
                value: 2.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 66 },
                column: "Price",
                value: 0.98999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 67 },
                column: "Price",
                value: 2.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 68 },
                column: "Price",
                value: 3.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 69 },
                column: "Price",
                value: 1.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 71 },
                column: "Price",
                value: 3.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 72 },
                column: "Price",
                value: 1.99);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 76 },
                column: "Price",
                value: 2.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 77 },
                column: "Price",
                value: 3.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 78 },
                column: "Price",
                value: 1.99);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 79 },
                column: "Price",
                value: 0.68999999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 81 },
                column: "Price",
                value: 0.39000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 82 },
                column: "Price",
                value: 0.58999999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 84 },
                column: "Price",
                value: 0.39000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 85 },
                column: "Price",
                value: 0.78999999999999992);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 86 },
                column: "Price",
                value: 1.99);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 88 },
                column: "Price",
                value: 1.5900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 89 },
                column: "Price",
                value: 2.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 91 },
                column: "Price",
                value: 0.58999999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 92 },
                column: "Price",
                value: 1.0900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 94 },
                column: "Price",
                value: 0.78999999999999992);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 95 },
                column: "Price",
                value: 1.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 97 },
                column: "Price",
                value: 0.89000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 98 },
                column: "Price",
                value: 1.1900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 99 },
                column: "Price",
                value: 0.48999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 100 },
                column: "Price",
                value: 2.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 101 },
                column: "Price",
                value: 3.9899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 1 },
                column: "Price",
                value: 1.6900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 2 },
                column: "Price",
                value: 2.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 3 },
                column: "Price",
                value: 1.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 4 },
                column: "Price",
                value: 5.9900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 5 },
                column: "Price",
                value: 6.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 6 },
                column: "Price",
                value: 4.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 7 },
                column: "Price",
                value: 6.1899999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 8 },
                column: "Price",
                value: 7.9900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 9 },
                column: "Price",
                value: 4.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 10 },
                column: "Price",
                value: 6.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 11 },
                column: "Price",
                value: 8.3900000000000006);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 12 },
                column: "Price",
                value: 6.6899999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 13 },
                column: "Price",
                value: 7.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 14 },
                column: "Price",
                value: 8.4900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 15 },
                column: "Price",
                value: 6.6899999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 16 },
                column: "Price",
                value: 2.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 17 },
                column: "Price",
                value: 3.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 18 },
                column: "Price",
                value: 1.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 20 },
                column: "Price",
                value: 3.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 21 },
                column: "Price",
                value: 1.3900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 22 },
                column: "Price",
                value: 2.9899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 23 },
                column: "Price",
                value: 3.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 24 },
                column: "Price",
                value: 1.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 25 },
                column: "Price",
                value: 1.6900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 26 },
                column: "Price",
                value: 2.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 27 },
                column: "Price",
                value: 0.68999999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 28 },
                column: "Price",
                value: 2.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 29 },
                column: "Price",
                value: 3.9899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 30 },
                column: "Price",
                value: 1.6900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 31 },
                column: "Price",
                value: 2.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 32 },
                column: "Price",
                value: 3.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 37 },
                column: "Price",
                value: 2.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 38 },
                column: "Price",
                value: 3.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 39 },
                column: "Price",
                value: 1.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 40 },
                column: "Price",
                value: 3.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 41 },
                column: "Price",
                value: 4.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 42 },
                column: "Price",
                value: 2.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 43 },
                column: "Price",
                value: 0.98999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 44 },
                column: "Price",
                value: 1.8900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 45 },
                column: "Price",
                value: 0.29000000000000004);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 46 },
                column: "Price",
                value: 5.1899999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 47 },
                column: "Price",
                value: 6.4900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 48 },
                column: "Price",
                value: 4.9900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 50 },
                column: "Price",
                value: 6.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 51 },
                column: "Price",
                value: 4.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 52 },
                column: "Price",
                value: 1.99);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 53 },
                column: "Price",
                value: 2.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 54 },
                column: "Price",
                value: 0.98999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 55 },
                column: "Price",
                value: 2.1899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 56 },
                column: "Price",
                value: 3.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 57 },
                column: "Price",
                value: 1.0900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 58 },
                column: "Price",
                value: 0.89000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 59 },
                column: "Price",
                value: 1.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 61 },
                column: "Price",
                value: 0.68999999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 62 },
                column: "Price",
                value: 1.6900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 63 },
                column: "Price",
                value: 0.39000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 64 },
                column: "Price",
                value: 1.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 65 },
                column: "Price",
                value: 2.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 66 },
                column: "Price",
                value: 0.98999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 67 },
                column: "Price",
                value: 2.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 68 },
                column: "Price",
                value: 3.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 69 },
                column: "Price",
                value: 1.5900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 70 },
                column: "Price",
                value: 2.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 72 },
                column: "Price",
                value: 1.1900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 76 },
                column: "Price",
                value: 2.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 77 },
                column: "Price",
                value: 3.1899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 78 },
                column: "Price",
                value: 1.49);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 79 },
                column: "Price",
                value: 0.98999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 81 },
                column: "Price",
                value: 0.29000000000000004);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 82 },
                column: "Price",
                value: 0.68999999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 83 },
                column: "Price",
                value: 1.6900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 84 },
                column: "Price",
                value: 0.29000000000000004);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 85 },
                column: "Price",
                value: 0.58999999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 86 },
                column: "Price",
                value: 1.0900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 88 },
                column: "Price",
                value: 1.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 89 },
                column: "Price",
                value: 2.1899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 90 },
                column: "Price",
                value: 0.68999999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 91 },
                column: "Price",
                value: 0.58999999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 94 },
                column: "Price",
                value: 0.89000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 95 },
                column: "Price",
                value: 1.1900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 96 },
                column: "Price",
                value: 0.29000000000000004);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 97 },
                column: "Price",
                value: 0.58999999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 98 },
                column: "Price",
                value: 1.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 99 },
                column: "Price",
                value: 0.48999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 100 },
                column: "Price",
                value: 2.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 101 },
                column: "Price",
                value: 3.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 102 },
                column: "Price",
                value: 1.79);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TempProducts");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d6d60c8-ae2b-47c5-a7e8-50535cf5bfb8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "754ce608-1dad-4dd0-8f42-6bca05099ad0", "AQAAAAIAAYagAAAAEOXE3wGL2Oxyj+8qkdiyKKtdiyXL51v7jytkdqFN9UGgnmsxBoHDHmsl2NGJr90kpA==", "505e2b9a-503d-48a8-aae8-e772ee46e336" });

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 1 },
                column: "Price",
                value: 1.8900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 2 },
                column: "Price",
                value: 2.1899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 3 },
                column: "Price",
                value: 1.49);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 4 },
                column: "Price",
                value: 5.6899999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 5 },
                column: "Price",
                value: 6.1899999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 6 },
                column: "Price",
                value: 4.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 7 },
                column: "Price",
                value: 6.9900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 8 },
                column: "Price",
                value: 7.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 9 },
                column: "Price",
                value: 4.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 10 },
                column: "Price",
                value: 6.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 11 },
                column: "Price",
                value: 8.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 12 },
                column: "Price",
                value: 6.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 14 },
                column: "Price",
                value: 9.2899999999999991);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 15 },
                column: "Price",
                value: 5.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 16 },
                column: "Price",
                value: 2.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 17 },
                column: "Price",
                value: 3.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 18 },
                column: "Price",
                value: 1.5900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 19 },
                column: "Price",
                value: 2.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 20 },
                column: "Price",
                value: 3.1899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 21 },
                column: "Price",
                value: 1.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 22 },
                column: "Price",
                value: 2.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 23 },
                column: "Price",
                value: 3.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 24 },
                column: "Price",
                value: 1.6900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 25 },
                column: "Price",
                value: 1.49);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 26 },
                column: "Price",
                value: 2.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 27 },
                column: "Price",
                value: 0.78999999999999992);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 28 },
                column: "Price",
                value: 2.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 29 },
                column: "Price",
                value: 3.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 30 },
                column: "Price",
                value: 1.0900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 31 },
                column: "Price",
                value: 2.9899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 32 },
                column: "Price",
                value: 3.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 33 },
                column: "Price",
                value: 1.49);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 37 },
                column: "Price",
                value: 2.9899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 38 },
                column: "Price",
                value: 3.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 40 },
                column: "Price",
                value: 3.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 41 },
                column: "Price",
                value: 4.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 42 },
                column: "Price",
                value: 2.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 43 },
                column: "Price",
                value: 0.89000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 44 },
                column: "Price",
                value: 1.6900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 47 },
                column: "Price",
                value: 6.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 48 },
                column: "Price",
                value: 4.1899999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 49 },
                column: "Price",
                value: 5.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 50 },
                column: "Price",
                value: 6.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 51 },
                column: "Price",
                value: 4.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 52 },
                column: "Price",
                value: 1.49);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 54 },
                column: "Price",
                value: 0.89000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 55 },
                column: "Price",
                value: 2.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 57 },
                column: "Price",
                value: 1.99);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 58 },
                column: "Price",
                value: 0.68999999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 60 },
                column: "Price",
                value: 0.48999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 61 },
                column: "Price",
                value: 0.58999999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 62 },
                column: "Price",
                value: 1.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 63 },
                column: "Price",
                value: 0.48999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 64 },
                column: "Price",
                value: 1.1900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 65 },
                column: "Price",
                value: 2.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 67 },
                column: "Price",
                value: 2.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 68 },
                column: "Price",
                value: 3.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 69 },
                column: "Price",
                value: 1.5900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 70 },
                column: "Price",
                value: 2.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 71 },
                column: "Price",
                value: 3.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 72 },
                column: "Price",
                value: 1.0900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 76 },
                column: "Price",
                value: 2.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 78 },
                column: "Price",
                value: 1.1900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 80 },
                column: "Price",
                value: 1.3900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 81 },
                column: "Price",
                value: 0.48999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 82 },
                column: "Price",
                value: 0.98999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 83 },
                column: "Price",
                value: 1.8900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 84 },
                column: "Price",
                value: 0.29000000000000004);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 85 },
                column: "Price",
                value: 0.89000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 86 },
                column: "Price",
                value: 1.49);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 88 },
                column: "Price",
                value: 1.49);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 89 },
                column: "Price",
                value: 2.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 90 },
                column: "Price",
                value: 0.89000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 91 },
                column: "Price",
                value: 0.89000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 92 },
                column: "Price",
                value: 1.6900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 93 },
                column: "Price",
                value: 0.48999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 94 },
                column: "Price",
                value: 0.89000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 95 },
                column: "Price",
                value: 1.99);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 98 },
                column: "Price",
                value: 1.49);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 99 },
                column: "Price",
                value: 0.39000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 100 },
                column: "Price",
                value: 2.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 101 },
                column: "Price",
                value: 3.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 1, 102 },
                column: "Price",
                value: 1.8900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 1 },
                column: "Price",
                value: 1.5900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 2 },
                column: "Price",
                value: 2.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 3 },
                column: "Price",
                value: 1.3900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 4 },
                column: "Price",
                value: 5.6899999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 5 },
                column: "Price",
                value: 6.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 6 },
                column: "Price",
                value: 4.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 7 },
                column: "Price",
                value: 6.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 8 },
                column: "Price",
                value: 7.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 9 },
                column: "Price",
                value: 4.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 10 },
                column: "Price",
                value: 6.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 11 },
                column: "Price",
                value: 9.8900000000000006);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 12 },
                column: "Price",
                value: 5.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 13 },
                column: "Price",
                value: 6.4900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 14 },
                column: "Price",
                value: 9.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 15 },
                column: "Price",
                value: 5.6899999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 16 },
                column: "Price",
                value: 2.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 17 },
                column: "Price",
                value: 3.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 18 },
                column: "Price",
                value: 1.99);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 19 },
                column: "Price",
                value: 2.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 21 },
                column: "Price",
                value: 1.49);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 22 },
                column: "Price",
                value: 2.1899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 23 },
                column: "Price",
                value: 3.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 24 },
                column: "Price",
                value: 1.6900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 25 },
                column: "Price",
                value: 1.6900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 26 },
                column: "Price",
                value: 2.1899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 27 },
                column: "Price",
                value: 0.98999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 28 },
                column: "Price",
                value: 2.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 29 },
                column: "Price",
                value: 3.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 30 },
                column: "Price",
                value: 1.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 31 },
                column: "Price",
                value: 2.1899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 33 },
                column: "Price",
                value: 1.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 37 },
                column: "Price",
                value: 2.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 38 },
                column: "Price",
                value: 3.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 39 },
                column: "Price",
                value: 1.99);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 40 },
                column: "Price",
                value: 3.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 41 },
                column: "Price",
                value: 4.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 42 },
                column: "Price",
                value: 2.9899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 43 },
                column: "Price",
                value: 0.89000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 44 },
                column: "Price",
                value: 1.6900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 45 },
                column: "Price",
                value: 0.48999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 46 },
                column: "Price",
                value: 5.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 47 },
                column: "Price",
                value: 6.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 48 },
                column: "Price",
                value: 4.9900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 49 },
                column: "Price",
                value: 5.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 50 },
                column: "Price",
                value: 6.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 51 },
                column: "Price",
                value: 4.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 52 },
                column: "Price",
                value: 1.5900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 53 },
                column: "Price",
                value: 2.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 54 },
                column: "Price",
                value: 0.98999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 55 },
                column: "Price",
                value: 2.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 56 },
                column: "Price",
                value: 3.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 57 },
                column: "Price",
                value: 1.8900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 58 },
                column: "Price",
                value: 0.89000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 59 },
                column: "Price",
                value: 1.8900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 60 },
                column: "Price",
                value: 0.39000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 61 },
                column: "Price",
                value: 0.68999999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 62 },
                column: "Price",
                value: 1.99);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 63 },
                column: "Price",
                value: 0.48999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 64 },
                column: "Price",
                value: 1.5900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 65 },
                column: "Price",
                value: 2.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 66 },
                column: "Price",
                value: 0.78999999999999992);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 67 },
                column: "Price",
                value: 2.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 68 },
                column: "Price",
                value: 3.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 69 },
                column: "Price",
                value: 1.5900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 71 },
                column: "Price",
                value: 3.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 72 },
                column: "Price",
                value: 1.5900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 76 },
                column: "Price",
                value: 2.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 77 },
                column: "Price",
                value: 3.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 78 },
                column: "Price",
                value: 1.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 79 },
                column: "Price",
                value: 0.89000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 81 },
                column: "Price",
                value: 0.48999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 82 },
                column: "Price",
                value: 0.89000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 84 },
                column: "Price",
                value: 0.29000000000000004);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 85 },
                column: "Price",
                value: 0.58999999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 86 },
                column: "Price",
                value: 1.49);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 88 },
                column: "Price",
                value: 1.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 89 },
                column: "Price",
                value: 2.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 91 },
                column: "Price",
                value: 0.78999999999999992);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 92 },
                column: "Price",
                value: 1.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 94 },
                column: "Price",
                value: 0.58999999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 95 },
                column: "Price",
                value: 1.49);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 97 },
                column: "Price",
                value: 0.68999999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 98 },
                column: "Price",
                value: 1.6900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 99 },
                column: "Price",
                value: 0.29000000000000004);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 100 },
                column: "Price",
                value: 2.1899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 2, 101 },
                column: "Price",
                value: 3.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 1 },
                column: "Price",
                value: 1.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 2 },
                column: "Price",
                value: 2.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 3 },
                column: "Price",
                value: 1.0900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 4 },
                column: "Price",
                value: 5.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 5 },
                column: "Price",
                value: 6.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 6 },
                column: "Price",
                value: 4.6899999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 7 },
                column: "Price",
                value: 6.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 8 },
                column: "Price",
                value: 7.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 9 },
                column: "Price",
                value: 5.6899999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 10 },
                column: "Price",
                value: 6.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 11 },
                column: "Price",
                value: 9.4900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 12 },
                column: "Price",
                value: 5.4900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 13 },
                column: "Price",
                value: 6.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 14 },
                column: "Price",
                value: 9.7899999999999991);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 15 },
                column: "Price",
                value: 6.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 16 },
                column: "Price",
                value: 2.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 17 },
                column: "Price",
                value: 3.3899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 18 },
                column: "Price",
                value: 1.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 20 },
                column: "Price",
                value: 3.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 21 },
                column: "Price",
                value: 1.5900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 22 },
                column: "Price",
                value: 2.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 23 },
                column: "Price",
                value: 3.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 24 },
                column: "Price",
                value: 1.99);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 25 },
                column: "Price",
                value: 1.49);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 26 },
                column: "Price",
                value: 2.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 27 },
                column: "Price",
                value: 0.89000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 28 },
                column: "Price",
                value: 2.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 29 },
                column: "Price",
                value: 3.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 30 },
                column: "Price",
                value: 1.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 31 },
                column: "Price",
                value: 2.9899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 32 },
                column: "Price",
                value: 3.9899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 37 },
                column: "Price",
                value: 2.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 38 },
                column: "Price",
                value: 3.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 39 },
                column: "Price",
                value: 1.5900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 40 },
                column: "Price",
                value: 3.1899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 41 },
                column: "Price",
                value: 4.8899999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 42 },
                column: "Price",
                value: 2.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 43 },
                column: "Price",
                value: 0.78999999999999992);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 44 },
                column: "Price",
                value: 1.6900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 45 },
                column: "Price",
                value: 0.39000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 46 },
                column: "Price",
                value: 5.5899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 47 },
                column: "Price",
                value: 6.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 48 },
                column: "Price",
                value: 4.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 50 },
                column: "Price",
                value: 6.9900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 51 },
                column: "Price",
                value: 4.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 52 },
                column: "Price",
                value: 1.1900000000000002);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 53 },
                column: "Price",
                value: 2.0899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 54 },
                column: "Price",
                value: 0.68999999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 55 },
                column: "Price",
                value: 2.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 56 },
                column: "Price",
                value: 3.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 57 },
                column: "Price",
                value: 1.99);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 58 },
                column: "Price",
                value: 0.68999999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 59 },
                column: "Price",
                value: 1.5900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 61 },
                column: "Price",
                value: 0.78999999999999992);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 62 },
                column: "Price",
                value: 1.8900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 63 },
                column: "Price",
                value: 0.48999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 64 },
                column: "Price",
                value: 1.8900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 65 },
                column: "Price",
                value: 2.9899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 66 },
                column: "Price",
                value: 0.68999999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 67 },
                column: "Price",
                value: 2.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 68 },
                column: "Price",
                value: 3.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 69 },
                column: "Price",
                value: 1.3900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 70 },
                column: "Price",
                value: 2.1899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 72 },
                column: "Price",
                value: 1.8900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 76 },
                column: "Price",
                value: 2.4899999999999998);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 77 },
                column: "Price",
                value: 3.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 78 },
                column: "Price",
                value: 1.8900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 79 },
                column: "Price",
                value: 0.58999999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 81 },
                column: "Price",
                value: 0.39000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 82 },
                column: "Price",
                value: 0.58999999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 83 },
                column: "Price",
                value: 1.29);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 84 },
                column: "Price",
                value: 0.39000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 85 },
                column: "Price",
                value: 0.98999999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 86 },
                column: "Price",
                value: 1.79);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 88 },
                column: "Price",
                value: 1.49);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 89 },
                column: "Price",
                value: 2.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 90 },
                column: "Price",
                value: 0.78999999999999992);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 91 },
                column: "Price",
                value: 0.68999999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 94 },
                column: "Price",
                value: 0.58999999999999997);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 95 },
                column: "Price",
                value: 1.49);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 96 },
                column: "Price",
                value: 0.39000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 97 },
                column: "Price",
                value: 0.68999999999999995);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 98 },
                column: "Price",
                value: 1.0900000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 99 },
                column: "Price",
                value: 0.39000000000000001);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 100 },
                column: "Price",
                value: 2.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 101 },
                column: "Price",
                value: 3.6899999999999999);

            migrationBuilder.UpdateData(
                table: "MarketProduct",
                keyColumns: new[] { "MarketId", "ProductId" },
                keyValues: new object[] { 3, 102 },
                column: "Price",
                value: 1.8900000000000001);
        }
    }
}
