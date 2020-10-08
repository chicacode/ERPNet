using Microsoft.EntityFrameworkCore.Migrations;

namespace ERPNet.Migrations
{
    public partial class AddNewDataEmpl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "Password", "PersonId", "PositionJob", "Salary", "UserName", "isAdmin" },
                values: new object[,]
                {
                    { 1, "test", 1, "Boss", 300, "Ironman", false },
                    { 2, "test", 2, "Soldier", 200, "Capitan America", false },
                    { 3, "test", 3, "BioTech", 200, "Hulk", false },
                    { 4, "test", 4, "Secret Agent", 200, "Black Widow", false },
                    { 5, "test", 5, "God of Thunder", 200, "Thor", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
