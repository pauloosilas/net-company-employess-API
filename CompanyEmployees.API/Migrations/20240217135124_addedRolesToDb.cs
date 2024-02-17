using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.API.Migrations
{
    /// <inheritdoc />
    public partial class addedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3986f33e-a602-456f-a0a8-dfffcc05e6c5", null, "Manager", "MANAGER" },
                    { "6922011f-43af-48e0-9299-f22ac8a58f63", null, "Administrator", "ADMINISTRADOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3986f33e-a602-456f-a0a8-dfffcc05e6c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6922011f-43af-48e0-9299-f22ac8a58f63");
        }
    }
}
