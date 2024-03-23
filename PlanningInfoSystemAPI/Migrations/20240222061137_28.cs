using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningInfoSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class _28 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanningRequestLine1Tbl_PlanningRequest_PlanningId",
                table: "PlanningRequestLine1Tbl");

            migrationBuilder.DropIndex(
                name: "IX_PlanningRequestLine1Tbl_PlanningId",
                table: "PlanningRequestLine1Tbl");

            migrationBuilder.AddColumn<int>(
                name: "PlanningRequestId",
                table: "PlanningRequestLine1Tbl",
                type: "int",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanningRequestLine1Tbl_PlanningRequest_PlanningRequestId",
                table: "PlanningRequestLine1Tbl");

            migrationBuilder.DropIndex(
                name: "IX_PlanningRequestLine1Tbl_PlanningRequestId",
                table: "PlanningRequestLine1Tbl");

            migrationBuilder.DropColumn(
                name: "PlanningRequestId",
                table: "PlanningRequestLine1Tbl");

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
        }
    }
}
