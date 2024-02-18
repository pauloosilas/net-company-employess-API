using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyEmployees.API.Migrations
{
    /// <inheritdoc />
    public partial class databaseRefreshtoken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "168735d8-d16d-4d26-acf8-511bbe911ae6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe7ac7d9-38ab-4b69-9c05-0ad296c2a8a5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0cc3ef36-574f-4682-84a1-7fa69bf30f8f", null, "Manager", "MANAGER" },
                    { "6616ef07-1a9a-472c-b945-d37cffeb79c4", null, "Administrator", "ADMINISTRADOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cc3ef36-574f-4682-84a1-7fa69bf30f8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6616ef07-1a9a-472c-b945-d37cffeb79c4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "168735d8-d16d-4d26-acf8-511bbe911ae6", null, "Administrator", "ADMINISTRADOR" },
                    { "fe7ac7d9-38ab-4b69-9c05-0ad296c2a8a5", null, "Manager", "MANAGER" }
                });
        }
    }
}
