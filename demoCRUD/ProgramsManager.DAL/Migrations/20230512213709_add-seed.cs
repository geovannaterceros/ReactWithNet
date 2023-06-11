using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProgramsManager.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Plate",
                columns: new[] { "Id", "DateActivity", "Name", "Offer" },
                values: new object[,]
                {
                    { new Guid("1963818c-3edb-4b6a-b561-a53a827f5b53"), new DateTime(2023, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Black 20", false },
                    { new Guid("4ef9acef-8e8a-41cf-8458-dda3fae62fb0"), new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Orange 20", false },
                    { new Guid("e938b5f2-490e-4530-9e9d-a90c07d66040"), new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blue 20", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plate",
                keyColumn: "Id",
                keyValue: new Guid("1963818c-3edb-4b6a-b561-a53a827f5b53"));

            migrationBuilder.DeleteData(
                table: "Plate",
                keyColumn: "Id",
                keyValue: new Guid("4ef9acef-8e8a-41cf-8458-dda3fae62fb0"));

            migrationBuilder.DeleteData(
                table: "Plate",
                keyColumn: "Id",
                keyValue: new Guid("e938b5f2-490e-4530-9e9d-a90c07d66040"));
        }
    }
}
