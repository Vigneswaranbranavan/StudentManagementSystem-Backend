using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class initials3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("02cfd913-81a4-4afd-858e-6a9b0e0dcea3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("10bb8afe-ee25-46f5-8aca-b25c43590b99"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("19f33e65-dea6-4b0c-9b50-b6e1c4e1d945"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("968749e2-051e-4e31-8c02-5c3e959574d3"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "OTPs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "OTPs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "OTPs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "OTPs");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "OTPs");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "OTPs");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "RoleName" },
                values: new object[,]
                {
                    { new Guid("02cfd913-81a4-4afd-858e-6a9b0e0dcea3"), "administrator" },
                    { new Guid("10bb8afe-ee25-46f5-8aca-b25c43590b99"), "teacher" },
                    { new Guid("19f33e65-dea6-4b0c-9b50-b6e1c4e1d945"), "staff" },
                    { new Guid("968749e2-051e-4e31-8c02-5c3e959574d3"), "student" }
                });
        }
    }
}
