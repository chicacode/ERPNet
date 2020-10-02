using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPNet.Migrations
{
    public partial class addNewStorageData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Storage",
                columns: new[] { "StorageId", "LastUpdate", "PartialQuantity", "ProductId", "WarehouseId" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 900, 1, 1 });

            migrationBuilder.InsertData(
                table: "Storage",
                columns: new[] { "StorageId", "LastUpdate", "PartialQuantity", "ProductId", "WarehouseId" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 700, 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Storage",
                keyColumn: "StorageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Storage",
                keyColumn: "StorageId",
                keyValue: 2);
        }
    }
}
