using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPNet.Migrations
{
    public partial class addNewOrdersData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "AddressId", "CreationOrder", "CustomerId", "DoneByEmployeeOrder", "EmployeeId", "OrderCompleted", "OrderNumber", "OrderPriority", "OrderState", "PriceItem", "PriceItemIva", "ProductId", "ProductQuantity", "TotalPrice" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XXX909090", 0, 0, 0.0, 0.0, 1, 350, 0.0 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "OrderId", "AddressId", "CreationOrder", "CustomerId", "DoneByEmployeeOrder", "EmployeeId", "OrderCompleted", "OrderNumber", "OrderPriority", "OrderState", "PriceItem", "PriceItemIva", "ProductId", "ProductQuantity", "TotalPrice" },
                values: new object[] { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "XXX909091", 0, 0, 0.0, 0.0, 2, 450, 0.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "OrderId",
                keyValue: 2);
        }
    }
}
