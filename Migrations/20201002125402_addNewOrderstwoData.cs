using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPNet.Migrations
{
    public partial class addNewOrderstwoData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "AddressId", "CreationOrder", "CustomerId", "DoneByEmployeeOrder", "EmployeeId", "OrderCompleted", "OrderNumber", "OrderPriority", "OrderState", "PriceItem", "PriceItemIva", "ProductId", "ProductQuantity", "TotalPrice" },
                values: new object[] { 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XXX909092", 0, 0, 0.0, 0.0, 1, 50, 0.0 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "AddressId", "CreationOrder", "CustomerId", "DoneByEmployeeOrder", "EmployeeId", "OrderCompleted", "OrderNumber", "OrderPriority", "OrderState", "PriceItem", "PriceItemIva", "ProductId", "ProductQuantity", "TotalPrice" },
                values: new object[] { 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XXX909093", 0, 0, 0.0, 0.0, 2, 760, 0.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 5);
        }
    }
}
