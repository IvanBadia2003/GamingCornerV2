using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class InitialCreate05_09_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 9, 5, 10, 45, 36, 765, DateTimeKind.Local).AddTicks(1047));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 5, 10, 45, 36, 765, DateTimeKind.Local).AddTicks(1080));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 9, 5, 10, 45, 36, 765, DateTimeKind.Local).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 16,
                column: "ImageURL",
                value: "https://image.api.playstation.com/vulcan/img/rnd/202010/2217/p3pYq0QxntZQREXRVdAzmn1w.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 9, 5, 10, 43, 44, 645, DateTimeKind.Local).AddTicks(8451));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 5, 10, 43, 44, 645, DateTimeKind.Local).AddTicks(8497));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 9, 5, 10, 43, 44, 645, DateTimeKind.Local).AddTicks(8501));

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 16,
                column: "ImageURL",
                value: "https://images.igdb.com/igdb/image/upload/t_cover_small/co4n26.png");
        }
    }
}
