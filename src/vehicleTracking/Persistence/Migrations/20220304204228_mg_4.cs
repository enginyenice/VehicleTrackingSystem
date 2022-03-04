using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class mg_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FullName", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { 1, "User One", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "userone" },
                    { 2, "User Two", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", "usertwo" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
