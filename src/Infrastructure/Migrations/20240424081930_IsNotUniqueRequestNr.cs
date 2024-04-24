using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IsNotUniqueRequestNr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Incidents_RequestNr",
                table: "Incidents");

            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "OpenDate" },
                values: new object[] { new DateTime(2024, 4, 24, 8, 19, 29, 654, DateTimeKind.Utc).AddTicks(5032), new DateTime(2024, 4, 24, 8, 19, 29, 654, DateTimeKind.Utc).AddTicks(5582) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "OpenDate" },
                values: new object[] { new DateTime(2024, 4, 23, 9, 51, 27, 866, DateTimeKind.Utc).AddTicks(4726), new DateTime(2024, 4, 23, 9, 51, 27, 866, DateTimeKind.Utc).AddTicks(5280) });

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_RequestNr",
                table: "Incidents",
                column: "RequestNr",
                unique: true);
        }
    }
}
