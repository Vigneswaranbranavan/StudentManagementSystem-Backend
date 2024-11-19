using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class staffadd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("ae1d56c4-3a2a-435d-9b4e-644a6a490eae"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("f8ff2329-8724-47fc-9f8f-f4dbd1858514"));

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

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "RoleName" },
                values: new object[,]
                {
                    { new Guid("1d403fc1-0017-4dfa-a3e0-165bcd912ee1"), "staff" },
                    { new Guid("263d88d5-e6d8-44d2-bdc0-81bd1e806f17"), "student" },
                    { new Guid("6ed92513-2398-4e52-a167-317a967359b7"), "administrator" },
                    { new Guid("a74158be-4015-4886-ad7d-9b57ee49e676"), "teacher" }
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Staff_StaffId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Staff_StaffId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_StaffId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_StaffId",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("1d403fc1-0017-4dfa-a3e0-165bcd912ee1"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("263d88d5-e6d8-44d2-bdc0-81bd1e806f17"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("6ed92513-2398-4e52-a167-317a967359b7"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("a74158be-4015-4886-ad7d-9b57ee49e676"));

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
                    { new Guid("ae1d56c4-3a2a-435d-9b4e-644a6a490eae"), "student" },
                    { new Guid("f8ff2329-8724-47fc-9f8f-f4dbd1858514"), "teacher" }
                });
        }
    }
}
