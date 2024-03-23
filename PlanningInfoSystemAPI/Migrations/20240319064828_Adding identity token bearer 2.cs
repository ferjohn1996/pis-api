using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlanningInfoSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class Addingidentitytokenbearer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastLinkedByUserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastLinkedModifiedDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastLogIn",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastModifiedByUserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "LastModifiedDateTime",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RequireChangePassword",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastLinkedByUserId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLinkedModifiedDate",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogIn",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedByUserId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDateTime",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RequireChangePassword",
                table: "User",
                type: "bit",
                nullable: true);
        }
    }
}
