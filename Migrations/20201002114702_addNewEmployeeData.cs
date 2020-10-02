using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPNet.Migrations
{
    public partial class addNewEmployeeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "Password", "PersonId", "PositionJob", "Salary", "UserName" },
                values: new object[,]
                {
                    { 1, "test", 1, "Boss", 300, "Ironman" },
                    { 2, "test", 2, "Soldier", 200, "Capitan America" },
                    { 3, "test", 3, "BioTech", 200, "Hulk" },
                    { 4, "test", 4, "Secret Agent", 200, "Black Widow" },
                    { 5, "test", 5, "God of Thunder", 200, "Thor" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: 5);
        }
    }
}
