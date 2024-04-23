using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class incidenttestseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "Id", "AmbitId", "ApplicationType", "CloseDate", "Created", "CreatedBy", "IncidentTypeId", "IsDeleted", "LastModified", "LastModifiedBy", "OpenDate", "OriginId", "ProblemDescription", "ProblemSummary", "RequestNr", "ScenaryId", "Solution", "SubCause", "Subsystem", "ThirdParty", "ThreatId", "Type", "Urgency" },
                values: new object[] { 1, 1, "str", null, new DateTime(2024, 4, 18, 9, 58, 51, 990, DateTimeKind.Utc).AddTicks(4345), 1, 1, false, null, null, new DateTime(2024, 4, 18, 9, 58, 51, 990, DateTimeKind.Utc).AddTicks(4879), 1, "Descr", "Summ", "1", 1, "str", "tmp", "Te", "tmps", 1, "Configuration", "No" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Incidents",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
