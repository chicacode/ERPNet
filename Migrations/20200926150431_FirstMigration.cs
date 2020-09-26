using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPNet.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressNumber = table.Column<int>(nullable: false),
                    AddressStreet = table.Column<string>(nullable: true),
                    AddressContactName = table.Column<string>(nullable: true),
                    AddressZipCode = table.Column<string>(nullable: true),
                    AddressCity = table.Column<string>(nullable: true),
                    AddressCountry = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PositionJob = table.Column<string>(nullable: true),
                    Salary = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(nullable: true),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.WarehouseId);
                    table.ForeignKey(
                        name: "FK_Warehouse_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<string>(nullable: true),
                    AddressDeliveryId = table.Column<int>(nullable: false),
                    OrderAddressAddressId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    OrderPriority = table.Column<int>(nullable: false),
                    OrderState = table.Column<int>(nullable: false),
                    CreationOrder = table.Column<DateTime>(nullable: false),
                    DoneByEmployeeOrder = table.Column<DateTime>(nullable: false),
                    OrderCompleted = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ProductQuantity = table.Column<int>(nullable: false),
                    PriceItem = table.Column<double>(nullable: false),
                    PriceItemIva = table.Column<double>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Address_OrderAddressAddressId",
                        column: x => x.OrderAddressAddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    AddressId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    TotalQuantity = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    StorageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    PartialQuantity = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.StorageId);
                    table.ForeignKey(
                        name: "FK_Storage_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Storage_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouse",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movements",
                columns: table => new
                {
                    MovementsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InOutDate = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    IsInput = table.Column<bool>(nullable: false),
                    StorageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.MovementsId);
                    table.ForeignKey(
                        name: "FK_Movements_Storage_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storage",
                        principalColumn: "StorageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Clothing" },
                    { 2, "Merchandising" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "LastName", "Name" },
                values: new object[,]
                {
                    { 1, "Richardson", "Liam" },
                    { 2, "Wilde", "Olivia" },
                    { 3, "Pollock", "Noah" },
                    { 4, "Watson", "Emma" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "LastName", "Name", "Password", "PositionJob", "Salary", "UserName" },
                values: new object[,]
                {
                    { 1, "Stark", "Tony", "test", "Boss", 300, "Ironman" },
                    { 2, "Rogers", "Steve", "test", "Soldier", 200, "Capitan America" },
                    { 3, "Banner", "Bruce", "test", "BioTech", 200, "Hulk" },
                    { 4, "Romanoff", "Natacha", "test", "Secret Agent", 200, "Black Widow" },
                    { 5, "Son of Odin", "Thor", "test", "God of Thunder", 200, "Thor" }
                });

            migrationBuilder.InsertData(
                table: "Warehouse",
                columns: new[] { "WarehouseId", "Address", "AddressId", "Name" },
                values: new object[,]
                {
                    { 1, "8 street / 23", null, "New York C" },
                    { 2, "Zona Franca", null, "Barcelona C" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Movements_StorageId",
                table: "Movements",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmployeeId",
                table: "Order",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderAddressAddressId",
                table: "Order",
                column: "OrderAddressAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressId",
                table: "Person",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CustomerId",
                table: "Person",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_EmployeeId",
                table: "Person",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderId",
                table: "Product",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_ProductId",
                table: "Storage",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_WarehouseId",
                table: "Storage",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_AddressId",
                table: "Warehouse",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movements");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Warehouse");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
