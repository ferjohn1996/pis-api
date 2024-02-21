using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningInfoSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class _25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "PlanningRequestLine3Tbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "PlanningRequestLine3Tbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "PlanningRequestLine2Tbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "PlanningRequestLine2Tbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "PlanningRequestLine1Tbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "PlanningRequestLine1Tbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "PlanningRequestLine3Tbl");

            migrationBuilder.DropColumn(
                name: "LastModifiedDateTime",
                table: "PlanningRequestLine3Tbl");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "PlanningRequestLine2Tbl");

            migrationBuilder.DropColumn(
                name: "LastModifiedDateTime",
                table: "PlanningRequestLine2Tbl");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "PlanningRequestLine1Tbl");

            migrationBuilder.DropColumn(
                name: "LastModifiedDateTime",
                table: "PlanningRequestLine1Tbl");
        }
    }
}
