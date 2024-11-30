using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class initialls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("03ca4c85-3e60-483d-b64e-1063c01d3307"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("07794888-6726-4c45-a77e-754686176706"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("17694eb4-cbc7-4d8c-8e1a-dc8cdf2ad7b3"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("b43e77d6-b867-4ee2-85d1-302d10d8ea12"));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Attendances",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "RoleName" },
                values: new object[,]
                {
                    { new Guid("138ccdc5-aebb-48e8-9f48-fe97a487660d"), "student" },
                    { new Guid("1d96d68c-c66f-4601-98ad-dda5de89119e"), "teacher" },
                    { new Guid("a405a5b0-beb6-4720-ad64-1d09c34ba109"), "staff" },
                    { new Guid("d23ec7ba-7b99-4058-8e0e-0f741075bfa9"), "administrator" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("138ccdc5-aebb-48e8-9f48-fe97a487660d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("1d96d68c-c66f-4601-98ad-dda5de89119e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("a405a5b0-beb6-4720-ad64-1d09c34ba109"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("d23ec7ba-7b99-4058-8e0e-0f741075bfa9"));

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Attendances",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "RoleName" },
                values: new object[,]
                {
                    { new Guid("03ca4c85-3e60-483d-b64e-1063c01d3307"), "administrator" },
                    { new Guid("07794888-6726-4c45-a77e-754686176706"), "teacher" },
                    { new Guid("17694eb4-cbc7-4d8c-8e1a-dc8cdf2ad7b3"), "student" },
                    { new Guid("b43e77d6-b867-4ee2-85d1-302d10d8ea12"), "staff" }
                });
        }
    }
}
