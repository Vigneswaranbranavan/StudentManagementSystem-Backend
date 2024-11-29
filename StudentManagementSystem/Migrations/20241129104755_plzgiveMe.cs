using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class plzgiveMe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("22f7734c-2d57-47a0-9e75-a3e4ac5d1051"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("9739e547-e55a-4661-8398-2d4212571532"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("99f6cbd5-c1ca-47f0-b49c-fa24d121b933"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("bd94c611-1a78-48d2-bcec-9acf05aa7a19"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "RoleName" },
                values: new object[,]
                {
                    { new Guid("028cf811-2d74-46b1-abf4-2edf9f71105b"), "staff" },
                    { new Guid("79b9f207-9e54-4b65-9820-b95bf1fbcfec"), "administrator" },
                    { new Guid("897eb3db-52b8-4d25-82d1-beffea29ce34"), "teacher" },
                    { new Guid("d3f16caa-9d8b-42ff-b62a-c7a21c4454af"), "student" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("028cf811-2d74-46b1-abf4-2edf9f71105b"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("79b9f207-9e54-4b65-9820-b95bf1fbcfec"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("897eb3db-52b8-4d25-82d1-beffea29ce34"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: new Guid("d3f16caa-9d8b-42ff-b62a-c7a21c4454af"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "RoleName" },
                values: new object[,]
                {
                    { new Guid("22f7734c-2d57-47a0-9e75-a3e4ac5d1051"), "staff" },
                    { new Guid("9739e547-e55a-4661-8398-2d4212571532"), "administrator" },
                    { new Guid("99f6cbd5-c1ca-47f0-b49c-fa24d121b933"), "student" },
                    { new Guid("bd94c611-1a78-48d2-bcec-9acf05aa7a19"), "teacher" }
                });
        }
    }
}
