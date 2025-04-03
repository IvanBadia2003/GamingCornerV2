using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class migration3_09_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Requisitos",
                table: "Videogames",
                newName: "Requisitos2");

            migrationBuilder.AddColumn<string>(
                name: "Requisitos1",
                table: "Videogames",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 9, 3, 21, 52, 44, 889, DateTimeKind.Local).AddTicks(5806));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 3, 21, 52, 44, 889, DateTimeKind.Local).AddTicks(5848));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 9, 3, 21, 52, 44, 889, DateTimeKind.Local).AddTicks(5850));

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 1,
                column: "Requisitos1",
                value: "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 2,
                column: "Requisitos1",
                value: "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 3,
                column: "Requisitos1",
                value: "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 4,
                column: "Requisitos1",
                value: "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 5,
                column: "Requisitos1",
                value: "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 6,
                column: "Requisitos1",
                value: "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 7,
                column: "Requisitos1",
                value: "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 8,
                column: "Requisitos1",
                value: "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 9,
                column: "Requisitos1",
                value: "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 10,
                column: "Requisitos1",
                value: "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 11,
                column: "Requisitos1",
                value: "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 12,
                column: "Requisitos1",
                value: "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 13,
                column: "Requisitos1",
                value: "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 14,
                column: "Requisitos1",
                value: "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 15,
                column: "Requisitos1",
                value: "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Requisitos1",
                table: "Videogames");

            migrationBuilder.RenameColumn(
                name: "Requisitos2",
                table: "Videogames",
                newName: "Requisitos");

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
    }
}
