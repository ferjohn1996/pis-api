using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningInfoSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class _29 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SKUCode",
                table: "PlanningRequestLine3Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SKUCode",
                table: "PlanningRequestLine2Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SKUCode",
                table: "PlanningRequestLine1Tbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SKUCode",
                table: "PlanningRequestLine3Tbl");

            migrationBuilder.DropColumn(
                name: "SKUCode",
                table: "PlanningRequestLine2Tbl");

            migrationBuilder.DropColumn(
                name: "SKUCode",
                table: "PlanningRequestLine1Tbl");
        }
    }
}
