using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b2c16f3a-7531-4229-94ac-c89f5833c87f"), "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Name", "RoleId" },
                values: new object[] { new Guid("a560c6f1-c54b-4a8b-a3e6-312215bce364"), 20, "Ostap", new Guid("b2c16f3a-7531-4229-94ac-c89f5833c87f") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a560c6f1-c54b-4a8b-a3e6-312215bce364"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("b2c16f3a-7531-4229-94ac-c89f5833c87f"));
        }
    }
}
