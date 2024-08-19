using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IRWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedRegionAndDifficulty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulty",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("95ad1fcd-7876-4b09-be77-859c9e94a9b3"), "Hard" },
                    { new Guid("98a39a48-78fa-41d7-ad97-445ccb84177c"), "Easy" },
                    { new Guid("d817f8e9-5b09-4181-b064-8069b4b8fa61"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0a2c8388-f3cc-4328-9b3e-6f47b92c4a11"), "TBZ", "Tabriz", "region.jpg" },
                    { new Guid("10191792-8707-4768-9e95-7aa628328853"), "TEH", "Tehran", "region.jpg" },
                    { new Guid("5d860541-eb55-4aa7-9fd5-1c525f617788"), "SEM", "Semnan", "region.jpg" },
                    { new Guid("75a93ca7-7b5c-4038-b0c0-140952f70e4f"), "FRS", "Fars", "region.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("95ad1fcd-7876-4b09-be77-859c9e94a9b3"));

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("98a39a48-78fa-41d7-ad97-445ccb84177c"));

            migrationBuilder.DeleteData(
                table: "Difficulty",
                keyColumn: "Id",
                keyValue: new Guid("d817f8e9-5b09-4181-b064-8069b4b8fa61"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0a2c8388-f3cc-4328-9b3e-6f47b92c4a11"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("10191792-8707-4768-9e95-7aa628328853"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5d860541-eb55-4aa7-9fd5-1c525f617788"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("75a93ca7-7b5c-4038-b0c0-140952f70e4f"));
        }
    }
}
