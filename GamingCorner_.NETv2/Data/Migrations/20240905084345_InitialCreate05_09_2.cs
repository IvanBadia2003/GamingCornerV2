using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class InitialCreate05_09_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Videogames",
                columns: new[] { "VideogameId", "Available", "Code", "Description", "GenderId", "ImageURL", "Name", "Pegi", "PlatformId", "Price", "Requisitos1", "Requisitos2", "Stock", "UserId" },
                values: new object[] { 16, true, "code15", "God of War es un juego de acción y aventura desarrollado por Santa Monica Studio y publicado por Sony Interactive Entertainment. Lanzado en 2018, es una reinvención de la serie y sigue a Kratos, el dios de la guerra, en una nueva etapa de su vida en la mitología nórdica. Acompañado por su hijo Atreus, Kratos debe enfrentarse a poderosos enemigos y criaturas míticas mientras lidia con sus propios demonios internos y enseña a su hijo a sobrevivir en un mundo hostil. El juego combina combates intensos con una narrativa emocional, explorando temas de paternidad, redención y autodescubrimiento. Con su innovador sistema de combate, impresionantes gráficos y un mundo abierto lleno de secretos, God of War ha sido aclamado como uno de los mejores videojuegos de la historia.", 5, "https://images.igdb.com/igdb/image/upload/t_cover_small/co4n26.png", "God of War", 12, 2, 60m, "OS: Windows 10 (64 bits); Procesador: Intel i5-2500K (3.3 GHz) o AMD Ryzen 3 1200; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 960 (4 GB) o AMD R9 290X (4 GB); Almacenamiento: 70 GB disponibles; DirectX: 11", "OS: Windows 10 (64 bits); Procesador: Intel i7-4770K (3.5 GHz) o AMD Ryzen 7 2700X; Memoria: 16 GB RAM; Gráfica: NVIDIA RTX 2060 (6 GB) o AMD RX 5700 XT (8 GB); Almacenamiento: 70 GB disponibles; DirectX: 12", 6, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Videogames",
                keyColumn: "VideogameId",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 9, 5, 10, 24, 28, 892, DateTimeKind.Local).AddTicks(6221));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 9, 5, 10, 24, 28, 892, DateTimeKind.Local).AddTicks(6258));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "TransactionId",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 9, 5, 10, 24, 28, 892, DateTimeKind.Local).AddTicks(6260));
        }
    }
}
