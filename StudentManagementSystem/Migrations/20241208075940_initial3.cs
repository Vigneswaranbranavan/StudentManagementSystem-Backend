using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmailType = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailTemplates");

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
    }
}
