using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningInfoSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class _18 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Packing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackingId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Feed_Run_No = table.Column<int>(type: "int", nullable: true),
                    Feed_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Feed_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Feed_ActualTons = table.Column<int>(type: "int", nullable: true),
                    Feed_Forms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Feed_BagWT = table.Column<int>(type: "int", nullable: true),
                    Product_PackStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    Product_PackStop = table.Column<TimeSpan>(type: "time", nullable: false),
                    Product_TotalHours = table.Column<double>(type: "float", nullable: true),
                    Product_TonsHours = table.Column<double>(type: "float", nullable: true),
                    Product_STD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yield_ExpectedNoBags = table.Column<double>(type: "float", nullable: true),
                    Yield_Completion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yield_RemainingTons = table.Column<double>(type: "float", nullable: true),
                    Yield_ActualBags = table.Column<int>(type: "int", nullable: true),
                    Yield_SOKgs = table.Column<int>(type: "int", nullable: true),
                    Yield_SBKgs = table.Column<int>(type: "int", nullable: true),
                    Yield_RejectedBags = table.Column<int>(type: "int", nullable: true),
                    Yield_ActualYield = table.Column<double>(type: "float", nullable: true),
                    Operator_Int = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Operator_Shift = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Downtime_Hours = table.Column<double>(type: "float", nullable: true),
                    Downtime_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Downtime_Accountability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Downtime_Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packing", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Packing");
        }
    }
}
