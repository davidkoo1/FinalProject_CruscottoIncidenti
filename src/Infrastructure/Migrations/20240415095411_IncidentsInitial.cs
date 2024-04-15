using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IncidentsInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ambits_Origins_OriginId",
                table: "Ambits");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_IncidentTypes_IncidentTypeId",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_IncidentTypes_Ambits_AmbitId",
                table: "IncidentTypes");

            migrationBuilder.DropIndex(
                name: "IX_IncidentTypes_AmbitId",
                table: "IncidentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Ambits_OriginId",
                table: "Ambits");

            migrationBuilder.DropColumn(
                name: "AmbitId",
                table: "IncidentTypes");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "Ambits");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Origins",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "IncidentTypes",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Urgency",
                table: "Incidents",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Incidents",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "SubCause",
                table: "Incidents",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ProblemSummary",
                table: "Incidents",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "ProblemDescription",
                table: "Incidents",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(350)",
                oldMaxLength: 350);

            migrationBuilder.AlterColumn<int>(
                name: "IncidentTypeId",
                table: "Incidents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationType",
                table: "Incidents",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "AmbitId",
                table: "Incidents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OriginId",
                table: "Incidents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScenaryId",
                table: "Incidents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Solution",
                table: "Incidents",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ThirdParty",
                table: "Incidents",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ThreatId",
                table: "Incidents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ambits",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "AmbitsToTypes",
                columns: table => new
                {
                    AmbitId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmbitsToTypes", x => new { x.AmbitId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_AmbitsToTypes_Ambits_AmbitId",
                        column: x => x.AmbitId,
                        principalTable: "Ambits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AmbitsToTypes_IncidentTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "IncidentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OriginsToAmbit",
                columns: table => new
                {
                    OriginId = table.Column<int>(type: "int", nullable: false),
                    AmbitId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OriginsToAmbit", x => new { x.OriginId, x.AmbitId });
                    table.ForeignKey(
                        name: "FK_OriginsToAmbit_Ambits_AmbitId",
                        column: x => x.AmbitId,
                        principalTable: "Ambits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OriginsToAmbit_Origins_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Origins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Scenaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Threats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threats", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_AmbitId",
                table: "Incidents",
                column: "AmbitId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_OriginId",
                table: "Incidents",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ScenaryId",
                table: "Incidents",
                column: "ScenaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ThreatId",
                table: "Incidents",
                column: "ThreatId");

            migrationBuilder.CreateIndex(
                name: "IX_AmbitsToTypes_TypeId",
                table: "AmbitsToTypes",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OriginsToAmbit_AmbitId",
                table: "OriginsToAmbit",
                column: "AmbitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Ambits_AmbitId",
                table: "Incidents",
                column: "AmbitId",
                principalTable: "Ambits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_IncidentTypes_IncidentTypeId",
                table: "Incidents",
                column: "IncidentTypeId",
                principalTable: "IncidentTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Origins_OriginId",
                table: "Incidents",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Scenaries_ScenaryId",
                table: "Incidents",
                column: "ScenaryId",
                principalTable: "Scenaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_Threats_ThreatId",
                table: "Incidents",
                column: "ThreatId",
                principalTable: "Threats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Ambits_AmbitId",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_IncidentTypes_IncidentTypeId",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Origins_OriginId",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Scenaries_ScenaryId",
                table: "Incidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidents_Threats_ThreatId",
                table: "Incidents");

            migrationBuilder.DropTable(
                name: "AmbitsToTypes");

            migrationBuilder.DropTable(
                name: "OriginsToAmbit");

            migrationBuilder.DropTable(
                name: "Scenaries");

            migrationBuilder.DropTable(
                name: "Threats");

            migrationBuilder.DropIndex(
                name: "IX_Incidents_AmbitId",
                table: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_Incidents_OriginId",
                table: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_Incidents_ScenaryId",
                table: "Incidents");

            migrationBuilder.DropIndex(
                name: "IX_Incidents_ThreatId",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "AmbitId",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "ScenaryId",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "Solution",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "ThirdParty",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "ThreatId",
                table: "Incidents");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Origins",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "IncidentTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35);

            migrationBuilder.AddColumn<int>(
                name: "AmbitId",
                table: "IncidentTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Urgency",
                table: "Incidents",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Incidents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35);

            migrationBuilder.AlterColumn<string>(
                name: "SubCause",
                table: "Incidents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35);

            migrationBuilder.AlterColumn<string>(
                name: "ProblemSummary",
                table: "Incidents",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "ProblemDescription",
                table: "Incidents",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<int>(
                name: "IncidentTypeId",
                table: "Incidents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationType",
                table: "Incidents",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ambits",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(35)",
                oldMaxLength: 35);

            migrationBuilder.AddColumn<int>(
                name: "OriginId",
                table: "Ambits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IncidentTypes_AmbitId",
                table: "IncidentTypes",
                column: "AmbitId");

            migrationBuilder.CreateIndex(
                name: "IX_Ambits_OriginId",
                table: "Ambits",
                column: "OriginId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ambits_Origins_OriginId",
                table: "Ambits",
                column: "OriginId",
                principalTable: "Origins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidents_IncidentTypes_IncidentTypeId",
                table: "Incidents",
                column: "IncidentTypeId",
                principalTable: "IncidentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IncidentTypes_Ambits_AmbitId",
                table: "IncidentTypes",
                column: "AmbitId",
                principalTable: "Ambits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
