using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class createDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 60, nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Age = table.Column<int>(maxLength: 125, nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    GroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b2c16f3a-7531-4229-94ac-c89f5833c87f"), "PMP-41" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b2c16f3a-7531-4229-94ac-c89f5833c87f"), "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("9710de87-1ced-400a-8097-04339ef146e0"), "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "GroupId", "Name", "Password", "RoleId" },
                values: new object[] { new Guid("a560c6f1-c54b-4a8b-a3e6-312215bce364"), 20, "stetskivostap@gmail.com", new Guid("b2c16f3a-7531-4229-94ac-c89f5833c87f"), "Ostap", "yI6cZwQadOA1e+/f+T+H3eCQQhQ=", new Guid("b2c16f3a-7531-4229-94ac-c89f5833c87f") });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "GroupId", "Name", "Password", "RoleId" },
                values: new object[] { new Guid("b2c16f3a-7531-4229-94ac-c89f5833c87f"), 20, "stetskiv@gmail.com", new Guid("b2c16f3a-7531-4229-94ac-c89f5833c87f"), "Ostap", "yI6cZwQadOA1e+/f+T+H3eCQQhQ=", new Guid("9710de87-1ced-400a-8097-04339ef146e0") });

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId",
                table: "Users",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
