using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "IntexNumber",
                table: "Students",
                newName: "IndexNumber");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "RoleName" },
                values: new object[,]
                {
                    { new Guid("1ff22749-771e-4d22-8b5b-ea65a0ac07f4"), "administrator" },
                    { new Guid("a9237276-b6fc-4dc9-bfdd-524c0a09fa63"), "teacher" },
                    { new Guid("c6a0f2c2-1b99-4ad9-9b5a-b4af5c017f46"), "staff" },
                    { new Guid("d2d76e11-dbb3-4210-b1dd-db5c11579fb0"), "student" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("1ff22749-771e-4d22-8b5b-ea65a0ac07f4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("a9237276-b6fc-4dc9-bfdd-524c0a09fa63"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("c6a0f2c2-1b99-4ad9-9b5a-b4af5c017f46"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("d2d76e11-dbb3-4210-b1dd-db5c11579fb0"));

            migrationBuilder.RenameColumn(
                name: "IndexNumber",
                table: "Students",
                newName: "IntexNumber");

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
    }
}
