using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class hhhh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("6d0399b2-81ce-4300-89f0-317e60a05288"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("c043e6d5-a4a3-4468-91de-f3ac4855fa5e"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("d17b721e-1aca-403c-bfd9-49e3a8a61e72"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("fe348af4-47f9-4f31-8f83-b04792944183"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "RoleName" },
                values: new object[,]
                {
                    { new Guid("6d0399b2-81ce-4300-89f0-317e60a05288"), "administrator" },
                    { new Guid("c043e6d5-a4a3-4468-91de-f3ac4855fa5e"), "student" },
                    { new Guid("d17b721e-1aca-403c-bfd9-49e3a8a61e72"), "teacher" },
                    { new Guid("fe348af4-47f9-4f31-8f83-b04792944183"), "staff" }
                });
        }
    }
}
