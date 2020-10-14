using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPNet.Migrations
{
    public partial class newDataPr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "TotalQuantity" },
                values: new object[,]
                {
                    { 1, 1, "Shop high-quality unique T-Shirts designed and sold by artist. 100% cotton", "T-Shirts", 0.0, 2 },
                    { 2, 1, "Shop high-quality unique Hoodies designed and sold by artist. 100% cotton", "Hoodies", 0.0, 2 },
                    { 3, 2, "Coffee, Tea Mugs", "Mugs", 0.0, 12 },
                    { 4, 2, "Code Stickers", "Stickers", 0.0, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
