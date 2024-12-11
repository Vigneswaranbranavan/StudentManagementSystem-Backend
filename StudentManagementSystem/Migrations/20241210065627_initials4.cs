using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class initials4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "RoleName" },
                values: new object[,]
                {
                    { new Guid("22766b52-d007-4240-95b5-b7dfbbfaef79"), "staff" },
                    { new Guid("47f7fae0-6c78-453c-b8de-ff00255cda83"), "teacher" },
                    { new Guid("f10cac5c-7d6d-40fd-adbd-27a613210034"), "administrator" },
                    { new Guid("f88c5d49-fc29-45b1-915f-2b070c9a3ec2"), "student" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("22766b52-d007-4240-95b5-b7dfbbfaef79"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("47f7fae0-6c78-453c-b8de-ff00255cda83"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("f10cac5c-7d6d-40fd-adbd-27a613210034"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("f88c5d49-fc29-45b1-915f-2b070c9a3ec2"));
        }
    }
}
