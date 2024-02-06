using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningInfoSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class _17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pelleting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PelletingId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Feed_Run_No = table.Column<int>(type: "int", nullable: true),
                    Feed_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Feed_Name_Medication = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Feed_Actual_Tons = table.Column<int>(type: "int", nullable: true),
                    Feed_Forms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Feed_Bin_Mash = table.Column<int>(type: "int", nullable: true),
                    Feed_Bin_Ff = table.Column<int>(type: "int", nullable: true),
                    Feed_Optr_Init = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Feed_Optr_Visor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pellet_Start = table.Column<TimeSpan>(type: "time", nullable: false),
                    Pellet_Stop = table.Column<TimeSpan>(type: "time", nullable: false),
                    Pellet_Total_Hours = table.Column<double>(type: "float", nullable: true),
                    Pellet_Tons_TPH = table.Column<double>(type: "float", nullable: true),
                    Pellet_STD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mill_Feeder_Setting = table.Column<double>(type: "float", nullable: true),
                    Mill_Steam_Setpoint = table.Column<double>(type: "float", nullable: true),
                    Mill_Steam_PSI = table.Column<double>(type: "float", nullable: true),
                    Mill_Ret_Team = table.Column<double>(type: "float", nullable: true),
                    Mill_Amps_Load = table.Column<double>(type: "float", nullable: true),
                    Cooler_Bed_Depth = table.Column<double>(type: "float", nullable: true),
                    Cooler_Air_Opening = table.Column<double>(type: "float", nullable: true),
                    Cooler_Cool_Speed = table.Column<double>(type: "float", nullable: true),
                    Downtime_Hours = table.Column<double>(type: "float", nullable: true),
                    Downtime_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Downtime_Accountability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Downtime_Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelleting", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pelleting");
        }
    }
}
