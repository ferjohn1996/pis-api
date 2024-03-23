using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningInfoSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class _33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualTons",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "Bin_To",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "Downtime_Accountability",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "Downtime_Hours",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "Downtime_Remarks",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "Downtime_Type",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "FeedCode",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "FeedName",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "Forms",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "Formula_Date",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "Formula_Ver",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "HammerMill_screen1",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "HammerMill_screen2",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "MixProd_STD",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "MixProd_TimeStart",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "MixProd_TimeStop",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "MixProd_TonsHours",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "MixProd_TotalHours",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "ProdDate",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "ProdSchedule",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "ProdTeam_Dump1",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "ProdTeam_Dump2",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "ProdTeam_Dump3",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "ProdTeam_Optr",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "ProdTeam_ShiftVisor",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "ReworkAdd_Kilos",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "ReworkAdd_LotId",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "Setup_BTC_Size",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "Setup_Feedrate_max",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "Setup_Feedrate_min",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "Setup_H2O",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "Setup_Motor_load",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "Setup_NoBatches",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "Setup_RPM",
                table: "Batching");

            migrationBuilder.DropColumn(
                name: "Sub_Batch",
                table: "Batching");

            migrationBuilder.RenameColumn(
                name: "Run_No",
                table: "Batching",
                newName: "statusId");

            migrationBuilder.AlterColumn<string>(
                name: "BatchingId",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Batching1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    ProdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    MixProd_STD = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Downtime_Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BatchingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batching1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batching1_Batching_BatchingId",
                        column: x => x.BatchingId,
                        principalTable: "Batching",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Batching2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    ProdDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    MixProd_STD = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Downtime_Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BatchingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batching2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batching2_Batching_BatchingId",
                        column: x => x.BatchingId,
                        principalTable: "Batching",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batching1_BatchingId",
                table: "Batching1",
                column: "BatchingId");

            migrationBuilder.CreateIndex(
                name: "IX_Batching2_BatchingId",
                table: "Batching2",
                column: "BatchingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Batching1");

            migrationBuilder.DropTable(
                name: "Batching2");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Batching");

            migrationBuilder.RenameColumn(
                name: "statusId",
                table: "Batching",
                newName: "Run_No");

            migrationBuilder.AlterColumn<string>(
                name: "BatchingId",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ActualTons",
                table: "Batching",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bin_To",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Downtime_Accountability",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Downtime_Hours",
                table: "Batching",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Downtime_Remarks",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Downtime_Type",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeedCode",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeedName",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Forms",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Formula_Date",
                table: "Batching",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Formula_Ver",
                table: "Batching",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HammerMill_screen1",
                table: "Batching",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "HammerMill_screen2",
                table: "Batching",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MixProd_STD",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "MixProd_TimeStart",
                table: "Batching",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "MixProd_TimeStop",
                table: "Batching",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<double>(
                name: "MixProd_TonsHours",
                table: "Batching",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "MixProd_TotalHours",
                table: "Batching",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProdDate",
                table: "Batching",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ProdSchedule",
                table: "Batching",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProdTeam_Dump1",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProdTeam_Dump2",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProdTeam_Dump3",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProdTeam_Optr",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProdTeam_ShiftVisor",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ReworkAdd_Kilos",
                table: "Batching",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReworkAdd_LotId",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Setup_BTC_Size",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Setup_Feedrate_max",
                table: "Batching",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Setup_Feedrate_min",
                table: "Batching",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Setup_H2O",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Setup_Motor_load",
                table: "Batching",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Setup_NoBatches",
                table: "Batching",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Setup_RPM",
                table: "Batching",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Sub_Batch",
                table: "Batching",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
