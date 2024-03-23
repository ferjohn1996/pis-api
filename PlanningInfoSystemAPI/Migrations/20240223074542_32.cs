using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningInfoSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class _32 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Line1TotalMT",
                table: "PlanningRequest",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line1TotalTP",
                table: "PlanningRequest",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line2TotalMT",
                table: "PlanningRequest",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line2TotalTP",
                table: "PlanningRequest",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line3TotalMT",
                table: "PlanningRequest",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Line3TotalTP",
                table: "PlanningRequest",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalActual",
                table: "PlanningRequest",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TotalVolume",
                table: "PlanningRequest",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Line1TotalMT",
                table: "PlanningRequest");

            migrationBuilder.DropColumn(
                name: "Line1TotalTP",
                table: "PlanningRequest");

            migrationBuilder.DropColumn(
                name: "Line2TotalMT",
                table: "PlanningRequest");

            migrationBuilder.DropColumn(
                name: "Line2TotalTP",
                table: "PlanningRequest");

            migrationBuilder.DropColumn(
                name: "Line3TotalMT",
                table: "PlanningRequest");

            migrationBuilder.DropColumn(
                name: "Line3TotalTP",
                table: "PlanningRequest");

            migrationBuilder.DropColumn(
                name: "TotalActual",
                table: "PlanningRequest");

            migrationBuilder.DropColumn(
                name: "TotalVolume",
                table: "PlanningRequest");
        }
    }
}
