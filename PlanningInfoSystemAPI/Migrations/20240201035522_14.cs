using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningInfoSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class _14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanningRequestLine1Tbl_PlanningRequest_PlanningRequestId",
                table: "PlanningRequestLine1Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanningRequestLine2Tbl_PlanningRequest_PlanningRequestId",
                table: "PlanningRequestLine2Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanningRequestLine3Tbl_PlanningRequest_PlanningRequestId",
                table: "PlanningRequestLine3Tbl");

            migrationBuilder.DropIndex(
                name: "IX_PlanningRequestLine3Tbl_PlanningRequestId",
                table: "PlanningRequestLine3Tbl");

            migrationBuilder.DropIndex(
                name: "IX_PlanningRequestLine2Tbl_PlanningRequestId",
                table: "PlanningRequestLine2Tbl");

            migrationBuilder.DropIndex(
                name: "IX_PlanningRequestLine1Tbl_PlanningRequestId",
                table: "PlanningRequestLine1Tbl");

            migrationBuilder.DropColumn(
                name: "PlanningRequestId",
                table: "PlanningRequestLine3Tbl");

            migrationBuilder.DropColumn(
                name: "PlanningRequestId",
                table: "PlanningRequestLine2Tbl");

            migrationBuilder.DropColumn(
                name: "PlanningRequestId",
                table: "PlanningRequestLine1Tbl");

            migrationBuilder.CreateTable(
                name: "Batching",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProdSchedule = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Run_No = table.Column<int>(type: "int", nullable: true),
                    Sub_Batch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Formula_Ver = table.Column<int>(type: "int", nullable: true),
                    Formula_Date = table.Column<int>(type: "int", nullable: true),
                    FeedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualTons = table.Column<int>(type: "int", nullable: true),
                    Forms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Setup_NoBatches = table.Column<double>(type: "float", nullable: true),
                    Setup_BTC_Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Setup_Feedrate_min = table.Column<int>(type: "int", nullable: false),
                    Setup_Feedrate_max = table.Column<int>(type: "int", nullable: false),
                    Setup_Motor_load = table.Column<int>(type: "int", nullable: false),
                    Setup_H2O = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Setup_RPM = table.Column<int>(type: "int", nullable: false),
                    HammerMill_screen1 = table.Column<double>(type: "float", nullable: true),
                    HammerMill_screen2 = table.Column<double>(type: "float", nullable: true),
                    MixProd_TimeStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    MixProd_TimeStop = table.Column<TimeSpan>(type: "time", nullable: false),
                    MixProd_TotalHours = table.Column<double>(type: "float", nullable: true),
                    MixProd_TonsHours = table.Column<double>(type: "float", nullable: true),
                    MixProd_STD = table.Column<double>(type: "float", nullable: true),
                    ReworkAdd_LotId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReworkAdd_Kilos = table.Column<double>(type: "float", nullable: true),
                    Bin_To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdTeam_Optr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdTeam_ShiftVisor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdTeam_Dump1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdTeam_Dump2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdTeam_Dump3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Downtime_Hours = table.Column<double>(type: "float", nullable: true),
                    Downtime_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Downtime_Accountability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Downtime_Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batching", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanningRequestLine3Tbl_PlanningId",
                table: "PlanningRequestLine3Tbl",
                column: "PlanningId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningRequestLine2Tbl_PlanningId",
                table: "PlanningRequestLine2Tbl",
                column: "PlanningId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningRequestLine1Tbl_PlanningId",
                table: "PlanningRequestLine1Tbl",
                column: "PlanningId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningRequestLine1Tbl_PlanningRequest_PlanningId",
                table: "PlanningRequestLine1Tbl",
                column: "PlanningId",
                principalTable: "PlanningRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningRequestLine2Tbl_PlanningRequest_PlanningId",
                table: "PlanningRequestLine2Tbl",
                column: "PlanningId",
                principalTable: "PlanningRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningRequestLine3Tbl_PlanningRequest_PlanningId",
                table: "PlanningRequestLine3Tbl",
                column: "PlanningId",
                principalTable: "PlanningRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanningRequestLine1Tbl_PlanningRequest_PlanningId",
                table: "PlanningRequestLine1Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanningRequestLine2Tbl_PlanningRequest_PlanningId",
                table: "PlanningRequestLine2Tbl");

            migrationBuilder.DropForeignKey(
                name: "FK_PlanningRequestLine3Tbl_PlanningRequest_PlanningId",
                table: "PlanningRequestLine3Tbl");

            migrationBuilder.DropTable(
                name: "Batching");

            migrationBuilder.DropIndex(
                name: "IX_PlanningRequestLine3Tbl_PlanningId",
                table: "PlanningRequestLine3Tbl");

            migrationBuilder.DropIndex(
                name: "IX_PlanningRequestLine2Tbl_PlanningId",
                table: "PlanningRequestLine2Tbl");

            migrationBuilder.DropIndex(
                name: "IX_PlanningRequestLine1Tbl_PlanningId",
                table: "PlanningRequestLine1Tbl");

            migrationBuilder.AddColumn<int>(
                name: "PlanningRequestId",
                table: "PlanningRequestLine3Tbl",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanningRequestId",
                table: "PlanningRequestLine2Tbl",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlanningRequestId",
                table: "PlanningRequestLine1Tbl",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanningRequestLine3Tbl_PlanningRequestId",
                table: "PlanningRequestLine3Tbl",
                column: "PlanningRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningRequestLine2Tbl_PlanningRequestId",
                table: "PlanningRequestLine2Tbl",
                column: "PlanningRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningRequestLine1Tbl_PlanningRequestId",
                table: "PlanningRequestLine1Tbl",
                column: "PlanningRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningRequestLine1Tbl_PlanningRequest_PlanningRequestId",
                table: "PlanningRequestLine1Tbl",
                column: "PlanningRequestId",
                principalTable: "PlanningRequest",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningRequestLine2Tbl_PlanningRequest_PlanningRequestId",
                table: "PlanningRequestLine2Tbl",
                column: "PlanningRequestId",
                principalTable: "PlanningRequest",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningRequestLine3Tbl_PlanningRequest_PlanningRequestId",
                table: "PlanningRequestLine3Tbl",
                column: "PlanningRequestId",
                principalTable: "PlanningRequest",
                principalColumn: "Id");
        }
    }
}
