using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace testDemo.Migrations
{
    public partial class modelsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("6c71c08c-57a2-454c-b8c3-270271228d2f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("18eb5eeb-affb-4e39-b75e-c2655a800707"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Code" },
                values: new object[] { new Guid("836f0eae-e563-436f-92e6-42d77a1d9580"), "Moderator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("ec9fc0e9-6796-4ca6-9586-681efacebf21"), "admin123", new Guid("836f0eae-e563-436f-92e6-42d77a1d9580"), "admin@com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("ec9fc0e9-6796-4ca6-9586-681efacebf21"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("836f0eae-e563-436f-92e6-42d77a1d9580"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "Code" },
                values: new object[] { new Guid("18eb5eeb-affb-4e39-b75e-c2655a800707"), "Moderator" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Password", "RoleId", "UserName" },
                values: new object[] { new Guid("6c71c08c-57a2-454c-b8c3-270271228d2f"), "admin123", new Guid("18eb5eeb-affb-4e39-b75e-c2655a800707"), "admin@com" });
        }
    }
}
