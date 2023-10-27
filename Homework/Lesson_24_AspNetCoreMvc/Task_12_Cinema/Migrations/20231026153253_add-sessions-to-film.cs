using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_12_Cinema.Migrations
{
    /// <inheritdoc />
    public partial class addsessionstofilm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EventDateTime",
                table: "Session",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 26, 15, 32, 53, 491, DateTimeKind.Utc).AddTicks(6315),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2023, 10, 26, 11, 38, 50, 338, DateTimeKind.Utc).AddTicks(8241));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EventDateTime",
                table: "Session",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 26, 11, 38, 50, 338, DateTimeKind.Utc).AddTicks(8241),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2023, 10, 26, 15, 32, 53, 491, DateTimeKind.Utc).AddTicks(6315));
        }
    }
}
