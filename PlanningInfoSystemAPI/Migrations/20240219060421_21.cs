using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningInfoSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class _21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DowntimeGuide",
                table: "PlanningRequestLine3Tbl");

            migrationBuilder.DropColumn(
                name: "DowntimeGuide",
                table: "PlanningRequestLine2Tbl");

            migrationBuilder.DropColumn(
                name: "DowntimeGuide",
                table: "PlanningRequestLine1Tbl");

            migrationBuilder.AddColumn<double>(
                name: "Uncontrollable",
                table: "PlanningRequestLine3Tbl",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Uncontrollable",
                table: "PlanningRequestLine2Tbl",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Uncontrollable",
                table: "PlanningRequestLine1Tbl",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uncontrollable",
                table: "PlanningRequestLine3Tbl");

            migrationBuilder.DropColumn(
                name: "Uncontrollable",
                table: "PlanningRequestLine2Tbl");

            migrationBuilder.DropColumn(
                name: "Uncontrollable",
                table: "PlanningRequestLine1Tbl");

            migrationBuilder.AddColumn<string>(
                name: "DowntimeGuide",
                table: "PlanningRequestLine3Tbl",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DowntimeGuide",
                table: "PlanningRequestLine2Tbl",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DowntimeGuide",
                table: "PlanningRequestLine1Tbl",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
