using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPNet.Migrations
{
    public partial class newMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Person_PersonId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Person_PersonId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Employee_PersonId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Customer_PersonId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "isAdmin",
                table: "Employee",
                newName: "IsAdmin");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Employee",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Customer",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Address",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Address",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LastName", "Name" },
                values: new object[] { "Wilde", "Olivia" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LastName", "Name" },
                values: new object[] { "Carreño", "Teresa" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LastName", "Name" },
                values: new object[] { "Singleton", "Lujan" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "LastName", "Name" },
                values: new object[] { "Jefferson", "Thomas" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LastName", "Name" },
                values: new object[] { "Stark", "Tony" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LastName", "Name" },
                values: new object[] { "Rogers", "Steve" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LastName", "Name" },
                values: new object[] { "Banner", "Bruce" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "LastName", "Name" },
                values: new object[] { "Romanoff", "Natacha" });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "LastName", "Name" },
                values: new object[] { "Son of Odin", "Thor" });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CustomerId",
                table: "Address",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_EmployeeId",
                table: "Address",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Customer_CustomerId",
                table: "Address",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Employee_EmployeeId",
                table: "Address",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Customer_CustomerId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Employee_EmployeeId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_CustomerId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_EmployeeId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "IsAdmin",
                table: "Employee",
                newName: "isAdmin");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Customer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "LastName", "Name" },
                values: new object[,]
                {
                    { 1, "Stark", "Tony" },
                    { 2, "Rogers", "Steve" },
                    { 3, "Banner", "Bruce" },
                    { 4, "Romanoff", "Natacha" },
                    { 5, "Son of Odin", "Thor" },
                    { 6, "Wilde", "Olivia" },
                    { 7, "Carreño", "Teresa" },
                    { 8, "Singleton", "Lujan" },
                    { 9, "Jefferson", "Thomas" }
                });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonId",
                value: 5);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PersonId",
                table: "Employee",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customer_PersonId",
                table: "Customer",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Person_PersonId",
                table: "Customer",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Person_PersonId",
                table: "Employee",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
