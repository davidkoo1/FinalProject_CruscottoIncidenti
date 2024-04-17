using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IncidentTypeOriginToAmbitInitialSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "IncidentTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Configuration" },
                    { 2, "Software Malfunction" },
                    { 3, "Third Parts" },
                    { 4, "Incorrect Change" },
                    { 5, "Code" },
                    { 6, "Resource Saturation" },
                    { 7, "Insufficient Resources" },
                    { 8, "Hardware Malfunction" },
                    { 9, "Degradation" },
                    { 10, "Block" },
                    { 11, "Accesses" },
                    { 12, "Cyber Attacks" },
                    { 13, "Certificates" },
                    { 14, "Firewall" },
                    { 15, "IDM" },
                    { 16, "Patching" }
                });

            migrationBuilder.InsertData(
                table: "OriginsToAmbit",
                columns: new[] { "AmbitId", "OriginId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 5, 2 },
                    { 1, 3 },
                    { 3, 3 },
                    { 6, 3 },
                    { 7, 3 },
                    { 8, 3 },
                    { 9, 3 },
                    { 10, 3 },
                    { 11, 3 },
                    { 12, 3 },
                    { 13, 3 },
                    { 14, 3 },
                    { 15, 3 },
                    { 16, 3 },
                    { 17, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "IncidentTypes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 14, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 16, 3 });

            migrationBuilder.DeleteData(
                table: "OriginsToAmbit",
                keyColumns: new[] { "AmbitId", "OriginId" },
                keyValues: new object[] { 17, 3 });
        }
    }
}
