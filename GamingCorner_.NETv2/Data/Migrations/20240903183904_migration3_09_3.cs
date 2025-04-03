using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class migration3_09_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Requisitos",
                table: "Videogames",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Videogames",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 9, 3, 20, 39, 4, 489, DateTimeKind.Local).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 3, 20, 39, 4, 489, DateTimeKind.Local).AddTicks(5904));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 9, 3, 20, 39, 4, 489, DateTimeKind.Local).AddTicks(5906));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Requisitos",
                table: "Videogames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Videogames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 9, 3, 20, 5, 0, 528, DateTimeKind.Local).AddTicks(6725));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 3, 20, 5, 0, 528, DateTimeKind.Local).AddTicks(6765));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 9, 3, 20, 5, 0, 528, DateTimeKind.Local).AddTicks(6767));
        }
    }
}
