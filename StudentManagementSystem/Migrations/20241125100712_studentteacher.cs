using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class studentteacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("05f8fb35-a973-4688-af87-a3d86f3c6194"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("8f7abcc7-ab97-4289-9452-a900a1417837"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("bc4aa3bc-354c-4fa8-aec5-22564a004e0e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("f0c7f896-835a-4fa5-abc0-fef804f86730"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "RoleName" },
                values: new object[,]
                {
                    { new Guid("291b10f5-8753-4845-aae1-aa7dc8d2284e"), "teacher" },
                    { new Guid("6ce635bf-8b10-4a2c-8a84-2c81e1860e6a"), "student" },
                    { new Guid("75fdb3a8-d7bc-4100-9e8f-32a7052b9952"), "administrator" },
                    { new Guid("7922e485-dbf5-42cb-8e57-7ffce90080dd"), "staff" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("291b10f5-8753-4845-aae1-aa7dc8d2284e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("6ce635bf-8b10-4a2c-8a84-2c81e1860e6a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("75fdb3a8-d7bc-4100-9e8f-32a7052b9952"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("7922e485-dbf5-42cb-8e57-7ffce90080dd"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "RoleName" },
                values: new object[,]
                {
                    { new Guid("05f8fb35-a973-4688-af87-a3d86f3c6194"), "teacher" },
                    { new Guid("8f7abcc7-ab97-4289-9452-a900a1417837"), "student" },
                    { new Guid("bc4aa3bc-354c-4fa8-aec5-22564a004e0e"), "staff" },
                    { new Guid("f0c7f896-835a-4fa5-abc0-fef804f86730"), "administrator" }
                });
        }
    }
}
