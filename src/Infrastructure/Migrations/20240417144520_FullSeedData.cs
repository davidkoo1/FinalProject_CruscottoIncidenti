using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FullSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AmbitsToTypes",
                columns: new[] { "AmbitId", "TypeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 2 },
                    { 4, 4 },
                    { 5, 3 },
                    { 6, 1 },
                    { 6, 2 },
                    { 6, 7 },
                    { 7, 1 },
                    { 7, 8 },
                    { 8, 2 },
                    { 8, 7 },
                    { 8, 8 },
                    { 8, 9 },
                    { 9, 6 },
                    { 9, 7 },
                    { 10, 4 },
                    { 10, 7 },
                    { 10, 9 },
                    { 10, 10 },
                    { 11, 2 },
                    { 11, 4 },
                    { 11, 6 },
                    { 11, 7 },
                    { 12, 4 },
                    { 13, 1 },
                    { 13, 11 },
                    { 13, 12 },
                    { 13, 13 },
                    { 13, 14 },
                    { 13, 15 },
                    { 13, 16 },
                    { 14, 7 },
                    { 15, 6 },
                    { 15, 7 },
                    { 16, 6 },
                    { 16, 9 },
                    { 16, 10 },
                    { 17, 6 }
                });

            migrationBuilder.InsertData(
                table: "Scenaries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "A1" },
                    { 2, "A2" },
                    { 3, "A3" }
                });

            migrationBuilder.InsertData(
                table: "Threats",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "AA1" },
                    { 2, "AA2" },
                    { 3, "AA3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 6, 7 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 8, 9 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 9, 6 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 9, 7 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 10, 7 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 10, 9 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 11, 6 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 11, 7 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 12, 4 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 13, 11 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 13, 12 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 13, 13 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 13, 14 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 13, 15 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 13, 16 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 14, 7 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 15, 6 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 15, 7 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 16, 6 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 16, 9 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 16, 10 });

            migrationBuilder.DeleteData(
                table: "AmbitsToTypes",
                keyColumns: new[] { "AmbitId", "TypeId" },
                keyValues: new object[] { 17, 6 });

            migrationBuilder.DeleteData(
                table: "Scenaries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Scenaries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Scenaries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Threats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Threats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Threats",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
