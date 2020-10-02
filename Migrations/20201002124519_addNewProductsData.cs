using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPNet.Migrations
{
    public partial class addNewProductsData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "Description", "Name", "OrderId", "TotalQuantity" },
                values: new object[,]
                {
                    { 1, 1, "Shop high-quality unique T-Shirts designed and sold by artist. 100% cotton", "T-Shirts", null, 2 },
                    { 2, 1, "Shop high-quality unique Hoodies designed and sold by artist. 100% cotton", "Hoodies", null, 2 },
                    { 3, 2, "Coffee, Tea Mugs", "Mugs", null, 12 },
                    { 4, 2, "Code Stickers", "Stickers", null, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4);
        }
    }
}
