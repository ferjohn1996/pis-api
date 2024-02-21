using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningInfoSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class _23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanningRequestLine1Tbl_PlanningRequest_PlanningRequestId",
                table: "PlanningRequestLine1Tbl");

            migrationBuilder.AddColumn<int>(
                name: "PlanningRequestId",
                table: "PlanningRequestLine3Tbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanningRequestId",
                table: "PlanningRequestLine2Tbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PlanningRequestId",
                table: "PlanningRequestLine1Tbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningRequestLine1Tbl_PlanningRequest_PlanningRequestId",
                table: "PlanningRequestLine1Tbl",
                column: "PlanningRequestId",
                principalTable: "PlanningRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlanningRequestLine1Tbl_PlanningRequest_PlanningRequestId",
                table: "PlanningRequestLine1Tbl");

            migrationBuilder.DropColumn(
                name: "PlanningRequestId",
                table: "PlanningRequestLine3Tbl");

            migrationBuilder.DropColumn(
                name: "PlanningRequestId",
                table: "PlanningRequestLine2Tbl");

            migrationBuilder.AlterColumn<int>(
                name: "PlanningRequestId",
                table: "PlanningRequestLine1Tbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PlanningRequestLine1Tbl_PlanningRequest_PlanningRequestId",
                table: "PlanningRequestLine1Tbl",
                column: "PlanningRequestId",
                principalTable: "PlanningRequest",
                principalColumn: "Id");
        }
    }
}
