using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InternetShop.Migrations
{
    /// <inheritdoc />
    public partial class addseedwithusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedAt", "Email", "Fullname", "Username" },
                values: new object[,]
                {
                    { 22, "test-1", new DateTime(2023, 10, 22, 16, 23, 51, 143, DateTimeKind.Utc).AddTicks(6842), "vasya@gmail.com", "Vasya Pupkin", "Vasya" },
                    { 25, "test-2", new DateTime(2023, 10, 22, 16, 23, 51, 143, DateTimeKind.Utc).AddTicks(6858), "petya@gmail.com", "Petya Pupkin", "Petya" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 25);
        }
    }
}
