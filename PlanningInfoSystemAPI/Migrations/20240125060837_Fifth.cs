using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningInfoSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class Fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanningRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanningRequestLine1Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Form = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MT = table.Column<int>(type: "int", nullable: true),
                    ActualHours = table.Column<int>(type: "int", nullable: true),
                    EffectiveCapacity = table.Column<int>(type: "int", nullable: true),
                    DieSizeThickness = table.Column<int>(type: "int", nullable: true),
                    ChangeOver = table.Column<int>(type: "int", nullable: true),
                    DowntimeGuide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accountability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DelayStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeProduce = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanningRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningRequestLine1Tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningRequestLine1Tbl_PlanningRequest_PlanningRequestId",
                        column: x => x.PlanningRequestId,
                        principalTable: "PlanningRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlanningRequestLine2Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Form = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MT = table.Column<int>(type: "int", nullable: true),
                    ActualHours = table.Column<int>(type: "int", nullable: true),
                    EffectiveCapacity = table.Column<int>(type: "int", nullable: true),
                    DieSizeThickness = table.Column<int>(type: "int", nullable: true),
                    ChangeOver = table.Column<int>(type: "int", nullable: true),
                    DowntimeGuide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accountability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DelayStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeProduce = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanningRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningRequestLine2Tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningRequestLine2Tbl_PlanningRequest_PlanningRequestId",
                        column: x => x.PlanningRequestId,
                        principalTable: "PlanningRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlanningRequestLine3Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Form = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MT = table.Column<int>(type: "int", nullable: true),
                    ActualHours = table.Column<int>(type: "int", nullable: true),
                    EffectiveCapacity = table.Column<int>(type: "int", nullable: true),
                    DieSizeThickness = table.Column<int>(type: "int", nullable: true),
                    ChangeOver = table.Column<int>(type: "int", nullable: true),
                    DowntimeGuide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accountability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DelayStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeProduce = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanningRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningRequestLine3Tbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningRequestLine3Tbl_PlanningRequest_PlanningRequestId",
                        column: x => x.PlanningRequestId,
                        principalTable: "PlanningRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanningRequestLine1Tbl_PlanningRequestId",
                table: "PlanningRequestLine1Tbl",
                column: "PlanningRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningRequestLine2Tbl_PlanningRequestId",
                table: "PlanningRequestLine2Tbl",
                column: "PlanningRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningRequestLine3Tbl_PlanningRequestId",
                table: "PlanningRequestLine3Tbl",
                column: "PlanningRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanningRequestLine1Tbl");

            migrationBuilder.DropTable(
                name: "PlanningRequestLine2Tbl");

            migrationBuilder.DropTable(
                name: "PlanningRequestLine3Tbl");

            migrationBuilder.DropTable(
                name: "PlanningRequest");
        }
    }
}
