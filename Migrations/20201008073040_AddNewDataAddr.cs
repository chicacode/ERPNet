using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPNet.Migrations
{
    public partial class AddNewDataAddr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "AddressCity", "AddressContactName", "AddressCountry", "AddressNumber", "AddressStreet", "AddressZipCode" },
                values: new object[] { 1, null, null, null, 7676, "8 street / 23", null });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "AddressCity", "AddressContactName", "AddressCountry", "AddressNumber", "AddressStreet", "AddressZipCode" },
                values: new object[] { 2, null, null, null, 6376, "Zona Franca", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
