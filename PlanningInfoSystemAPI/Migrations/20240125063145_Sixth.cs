using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningInfoSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class Sixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanningRequestLine1Tbl");

            migrationBuilder.DropTable(
                name: "PlanningRequestLine2Tbl");

            migrationBuilder.DropTable(
                name: "PlanningRequestLine3Tbl");

            migrationBuilder.CreateTable(
                name: "PlanningRequestLineTbl",
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
                    PlanningRequestId = table.Column<int>(type: "int", nullable: true),
                    PlanningRequestId1 = table.Column<int>(type: "int", nullable: true),
                    PlanningRequestId2 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningRequestLineTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningRequestLineTbl_PlanningRequest_PlanningRequestId",
                        column: x => x.PlanningRequestId,
                        principalTable: "PlanningRequest",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanningRequestLineTbl_PlanningRequest_PlanningRequestId1",
                        column: x => x.PlanningRequestId1,
                        principalTable: "PlanningRequest",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlanningRequestLineTbl_PlanningRequest_PlanningRequestId2",
                        column: x => x.PlanningRequestId2,
                        principalTable: "PlanningRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanningRequestLineTbl_PlanningRequestId",
                table: "PlanningRequestLineTbl",
                column: "PlanningRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningRequestLineTbl_PlanningRequestId1",
                table: "PlanningRequestLineTbl",
                column: "PlanningRequestId1");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningRequestLineTbl_PlanningRequestId2",
                table: "PlanningRequestLineTbl",
                column: "PlanningRequestId2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanningRequestLineTbl");

            migrationBuilder.CreateTable(
                name: "PlanningRequestLine1Tbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Accountability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActualHours = table.Column<int>(type: "int", nullable: true),
                    ChangeOver = table.Column<int>(type: "int", nullable: true),
                    DelayStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DieSizeThickness = table.Column<int>(type: "int", nullable: true),
                    DowntimeGuide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectiveCapacity = table.Column<int>(type: "int", nullable: true),
                    Form = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MT = table.Column<int>(type: "int", nullable: true),
                    PlanningRequestId = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeProduce = table.Column<int>(type: "int", nullable: true)
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
                    Accountability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActualHours = table.Column<int>(type: "int", nullable: true),
                    ChangeOver = table.Column<int>(type: "int", nullable: true),
                    DelayStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DieSizeThickness = table.Column<int>(type: "int", nullable: true),
                    DowntimeGuide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectiveCapacity = table.Column<int>(type: "int", nullable: true),
                    Form = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MT = table.Column<int>(type: "int", nullable: true),
                    PlanningRequestId = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeProduce = table.Column<int>(type: "int", nullable: true)
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
                    Accountability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActualHours = table.Column<int>(type: "int", nullable: true),
                    ChangeOver = table.Column<int>(type: "int", nullable: true),
                    DelayStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DieSizeThickness = table.Column<int>(type: "int", nullable: true),
                    DowntimeGuide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffectiveCapacity = table.Column<int>(type: "int", nullable: true),
                    Form = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MT = table.Column<int>(type: "int", nullable: true),
                    PlanningRequestId = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeProduce = table.Column<int>(type: "int", nullable: true)
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
    }
}
