using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class initiallss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("946350d4-8c53-4581-bbc0-fadd2e9a4eec"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("cd8971d0-1649-4a40-a126-c507c0308b09"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("d1e0b20a-ecf4-48da-a67e-3df5b92d6043"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("d386cf23-8f0e-4388-a700-968f0d692618"));

            migrationBuilder.AddColumn<string>(
                name: "IntexNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "gender",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "RoleName" },
                values: new object[,]
                {
                    { new Guid("7c19b075-df7f-4dfb-a507-f260e77f9fe3"), "student" },
                    { new Guid("b1a783a8-cafe-4195-a131-d51655fb2157"), "administrator" },
                    { new Guid("f438115a-0345-4cbb-a756-dbf6da347e15"), "teacher" },
                    { new Guid("f56eafdb-8a81-43b3-a530-fa40abc532dd"), "staff" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("7c19b075-df7f-4dfb-a507-f260e77f9fe3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("b1a783a8-cafe-4195-a131-d51655fb2157"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("f438115a-0345-4cbb-a756-dbf6da347e15"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("f56eafdb-8a81-43b3-a530-fa40abc532dd"));

            migrationBuilder.DropColumn(
                name: "IntexNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "Students");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "RoleName" },
                values: new object[,]
                {
                    { new Guid("946350d4-8c53-4581-bbc0-fadd2e9a4eec"), "student" },
                    { new Guid("cd8971d0-1649-4a40-a126-c507c0308b09"), "teacher" },
                    { new Guid("d1e0b20a-ecf4-48da-a67e-3df5b92d6043"), "staff" },
                    { new Guid("d386cf23-8f0e-4388-a700-968f0d692618"), "administrator" }
                });
        }
    }
}
