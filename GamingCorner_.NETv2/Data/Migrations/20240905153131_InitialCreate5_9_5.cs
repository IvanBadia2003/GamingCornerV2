using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class InitialCreate5_9_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 9, 5, 17, 31, 31, 451, DateTimeKind.Local).AddTicks(1282));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 5, 17, 31, 31, 451, DateTimeKind.Local).AddTicks(1325));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 9, 5, 17, 31, 31, 451, DateTimeKind.Local).AddTicks(1328));

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 1,
                column: "Requisitos1",
                value: "Windows 7; Intel Core 2 Duo E4600; 2 GB RAM; NVIDIA GeForce 8800; 7 GB disponibles; 11");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 2,
                column: "Requisitos1",
                value: "Windows 7; Procesador: Intel Core 2 Quad CPU Q6600; Memoria: 4 GB RAM; Gráfica: NVIDIA 9800 GT; Almacenamiento: 72 GB disponibles; DirectX: 11");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 3,
                column: "Requisitos1",
                value: "Windows 7; Procesador: Intel Core i5-2500K; Memoria: 6 GB RAM; Gráfica: NVIDIA GeForce GTX 660; Almacenamiento: 35 GB disponibles; DirectX: 11");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 4,
                column: "Requisitos1",
                value: "Windows 7; Procesador: Intel Core i3-3210; Memoria: 4 GB RAM; Gráfica: Intel HD Graphics 4000; Almacenamiento: 1 GB disponibles; DirectX: 11");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 6,
                column: "Requisitos1",
                value: "Windows 7; Procesador: Intel Core i3; Memoria: 4 GB RAM; Gráfica: NVIDIA GeForce GTX 460; Almacenamiento: 30 GB disponibles; DirectX: 11");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 8,
                column: "Requisitos1",
                value: "Windows 7; Procesador: Intel Core i5-3570K; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 780; Almacenamiento: 70 GB disponibles; DirectX: 11");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 9,
                column: "Requisitos1",
                value: "Windows 7; Procesador: Intel Core i5-2500K; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 770; Almacenamiento: 150 GB disponibles; DirectX: 11");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 11,
                column: "Requisitos1",
                value: "Windows 7; Procesador: Intel Core i3-4340; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 670; Almacenamiento: 175 GB disponibles; DirectX: 11");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 16,
                column: "ImageURL",
                value: "https://images.igdb.com/igdb/image/upload/t_cover_big/co1tmu.webp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: 1,
                column: "Requisitos1",
                value: "OS: Windows 7; Procesador: Intel Core 2 Duo E4600; Memoria: 2 GB RAM; Gráfica: NVIDIA GeForce 8800; Almacenamiento: 7 GB disponibles; DirectX: 11");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 2,
                column: "Requisitos1",
                value: "OS: Windows 7; Procesador: Intel Core 2 Quad CPU Q6600; Memoria: 4 GB RAM; Gráfica: NVIDIA 9800 GT; Almacenamiento: 72 GB disponibles; DirectX: 11");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 3,
                column: "Requisitos1",
                value: "OS: Windows 7; Procesador: Intel Core i5-2500K; Memoria: 6 GB RAM; Gráfica: NVIDIA GeForce GTX 660; Almacenamiento: 35 GB disponibles; DirectX: 11");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 4,
                column: "Requisitos1",
                value: "OS: Windows 7; Procesador: Intel Core i3-3210; Memoria: 4 GB RAM; Gráfica: Intel HD Graphics 4000; Almacenamiento: 1 GB disponibles; DirectX: 11");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 6,
                column: "Requisitos1",
                value: "OS: Windows 7; Procesador: Intel Core i3; Memoria: 4 GB RAM; Gráfica: NVIDIA GeForce GTX 460; Almacenamiento: 30 GB disponibles; DirectX: 11");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 8,
                column: "Requisitos1",
                value: "OS: Windows 7; Procesador: Intel Core i5-3570K; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 780; Almacenamiento: 70 GB disponibles; DirectX: 11");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 9,
                column: "Requisitos1",
                value: "OS: Windows 7; Procesador: Intel Core i5-2500K; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 770; Almacenamiento: 150 GB disponibles; DirectX: 11");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 11,
                column: "Requisitos1",
                value: "OS: Windows 7; Procesador: Intel Core i3-4340; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 670; Almacenamiento: 175 GB disponibles; DirectX: 11");

            migrationBuilder.UpdateData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 16,
                column: "ImageURL",
                value: "https://image.api.playstation.com/vulcan/img/rnd/202010/2217/p3pYq0QxntZQREXRVdAzmn1w.png");
        }
    }
}
