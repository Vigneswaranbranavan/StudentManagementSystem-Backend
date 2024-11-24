using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Staff_StaffId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Staff_StaffId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_StaffId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_StaffId",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("1edbefd4-957e-4fdf-846b-9bbb4603cd92"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("4834b05e-964e-4ddf-a1c7-7371e440e212"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("90c222b4-a8ec-46fc-9207-ea23b85cc97d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("c1772143-f855-4cd3-92d4-1f1d04c9cb75"));

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Students");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "RoleName" },
                values: new object[,]
                {
                    { new Guid("4c3590e9-b91e-4327-ad8d-f93ba233a60a"), "staff" },
                    { new Guid("aff470dd-a0c2-48d6-a627-dc824e9858c3"), "administrator" },
                    { new Guid("d8a99dd9-b732-4237-a9b7-59af1134c1c2"), "teacher" },
                    { new Guid("dce7976d-1275-434b-b645-6b6f5c670339"), "student" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("4c3590e9-b91e-4327-ad8d-f93ba233a60a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("aff470dd-a0c2-48d6-a627-dc824e9858c3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("d8a99dd9-b732-4237-a9b7-59af1134c1c2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("dce7976d-1275-434b-b645-6b6f5c670339"));

            migrationBuilder.AddColumn<Guid>(
                name: "StaffId",
                table: "Teachers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StaffId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "RoleName" },
                values: new object[,]
                {
                    { new Guid("1edbefd4-957e-4fdf-846b-9bbb4603cd92"), "administrator" },
                    { new Guid("4834b05e-964e-4ddf-a1c7-7371e440e212"), "teacher" },
                    { new Guid("90c222b4-a8ec-46fc-9207-ea23b85cc97d"), "student" },
                    { new Guid("c1772143-f855-4cd3-92d4-1f1d04c9cb75"), "staff" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_StaffId",
                table: "Teachers",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StaffId",
                table: "Students",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Staff_StaffId",
                table: "Students",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Staff_StaffId",
                table: "Teachers",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "Id");
        }
    }
}
