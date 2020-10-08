using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPNet.Migrations
{
    public partial class AddNewDataWare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Warehouse",
                columns: new[] { "Id", "AddressId", "Name" },
                values: new object[] { 1, 1, "New York C" });

            migrationBuilder.InsertData(
                table: "Warehouse",
                columns: new[] { "Id", "AddressId", "Name" },
                values: new object[] { 2, 2, "Barcelona C" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Warehouse",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
