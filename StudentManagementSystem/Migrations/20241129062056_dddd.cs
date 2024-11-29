using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class dddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "RoleName" },
                values: new object[,]
                {
                    { new Guid("26c23944-9901-43ed-8cb4-564713bfe421"), "administrator" },
                    { new Guid("5e2c0373-bbd6-4842-a32b-4ce2c9026a6d"), "staff" },
                    { new Guid("6c44fb1d-97ec-486a-95dc-e952677f6216"), "student" },
                    { new Guid("ed4a1f7c-43dd-4171-b432-c1897f8881db"), "teacher" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserID",
                table: "Students",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserID",
                table: "Students",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserID",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("26c23944-9901-43ed-8cb4-564713bfe421"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("5e2c0373-bbd6-4842-a32b-4ce2c9026a6d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("6c44fb1d-97ec-486a-95dc-e952677f6216"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("ed4a1f7c-43dd-4171-b432-c1897f8881db"));

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Students");

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
    }
}
