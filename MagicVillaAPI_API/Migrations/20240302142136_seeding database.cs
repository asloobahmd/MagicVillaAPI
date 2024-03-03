using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVillaAPI_API.Migrations
{
    /// <inheritdoc />
    public partial class seedingdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2024, 3, 2, 19, 51, 35, 925, DateTimeKind.Local).AddTicks(2499), "Sample details", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/521880995.jpg?k=1c30caf791925fbd5f47ceee91c6cf24e073f6dbab9c14cbd83f9cc81c31735f&o=&hp=1", "Royal Villa", 4, 200.0, 550, null },
                    { 2, "", new DateTime(2024, 3, 2, 19, 51, 35, 925, DateTimeKind.Local).AddTicks(2514), "Sample details", "https://cf.bstatic.com/xdata/images/hotel/max1024x768/521881899.jpg?k=58328b33c718de90b57afc53016df5c9f8cfdd32cc92736a8fa4e8f493e70d84&o=&hp=1", "Bliss Villa", 5, 180.0, 500, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
