using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Task_12_Cinema.Migrations
{
    /// <inheritdoc />
    public partial class addsessions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EventDateTime",
                table: "Session",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 26, 11, 38, 50, 338, DateTimeKind.Utc).AddTicks(8241),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2023, 10, 26, 11, 36, 40, 347, DateTimeKind.Utc).AddTicks(4781));

            migrationBuilder.InsertData(
                table: "Session",
                columns: new[] { "Id", "EventDateTime", "FilmId" },
                values: new object[,]
                {
                    { 2, new DateTime(2023, 11, 2, 20, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(2023, 11, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, new DateTime(2023, 11, 2, 20, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, new DateTime(2023, 11, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 6, new DateTime(2023, 11, 2, 18, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, new DateTime(2023, 11, 3, 19, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 8, new DateTime(2023, 11, 2, 20, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 9, new DateTime(2023, 11, 2, 17, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 10, new DateTime(2023, 11, 3, 20, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 11, new DateTime(2023, 11, 3, 21, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 12, new DateTime(2023, 11, 4, 18, 0, 0, 0, DateTimeKind.Unspecified), 6 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Session",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EventDateTime",
                table: "Session",
                type: "DATETIME2",
                nullable: false,
                defaultValue: new DateTime(2023, 10, 26, 11, 36, 40, 347, DateTimeKind.Utc).AddTicks(4781),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValue: new DateTime(2023, 10, 26, 11, 38, 50, 338, DateTimeKind.Utc).AddTicks(8241));
        }
    }
}
