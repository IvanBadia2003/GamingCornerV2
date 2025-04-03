using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class migration2_09_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Videogames",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 9, 2, 21, 35, 27, 305, DateTimeKind.Local).AddTicks(1155));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 2, 21, 35, 27, 305, DateTimeKind.Local).AddTicks(1194));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 9, 2, 21, 35, 27, 305, DateTimeKind.Local).AddTicks(1196));

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 1,
                column: "Code",
                value: "code1");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 2,
                column: "Code",
                value: "code2");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 3,
                column: "Code",
                value: "code3");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 4,
                column: "Code",
                value: "code4");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 5,
                column: "Code",
                value: "code5");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 6,
                column: "Code",
                value: "code6");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 7,
                column: "Code",
                value: "code7");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 8,
                column: "Code",
                value: "code8");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 9,
                column: "Code",
                value: "code9");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 10,
                column: "Code",
                value: "code10");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 11,
                column: "Code",
                value: "code11");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 12,
                column: "Code",
                value: "code12");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 13,
                column: "Code",
                value: "code13");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 14,
                column: "Code",
                value: "code14");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 15,
                column: "Code",
                value: "code15");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Videogames");

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 9, 2, 21, 27, 47, 730, DateTimeKind.Local).AddTicks(293));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 2, 21, 27, 47, 730, DateTimeKind.Local).AddTicks(328));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 9, 2, 21, 27, 47, 730, DateTimeKind.Local).AddTicks(330));
        }
    }
}
