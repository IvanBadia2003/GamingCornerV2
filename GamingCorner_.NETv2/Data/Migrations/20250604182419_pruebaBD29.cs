using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class pruebaBD29 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Videogames",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Videogames",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Videogames",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "PlatformId",
                keyValue: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "Name" },
                values: new object[,]
                {
                    { 1, "RPG" },
                    { 2, "Shooter" },
                    { 3, "Estrategia" },
                    { 4, "Accion" },
                    { 5, "Deportes" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "PlatformId", "Name", "System" },
                values: new object[,]
                {
                    { 1, "Steam", 0 },
                    { 2, "Play Station", 0 },
                    { 3, "Xbox", 0 },
                    { 4, "Switch", 0 },
                    { 5, "Ubisoft", 0 },
                    { 6, "Epic Games", 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "Admin", "Avatar", "DateCreated", "Email", "Name", "Password", "PhoneNumber", "Rol", "State" },
                values: new object[,]
                {
                    { 1, "C/ La Lectura", true, "", new DateTime(2025, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), "diego@gmail.com", "Diego", "12345", "601112734", 1, 1 },
                    { 2, "Avda. San Juan de la Peña", true, "", new DateTime(2025, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), "ivan@gmail.com", "Ivan", "12345", "123456789", 1, 1 },
                    { 3, "El Actur", false, "", new DateTime(2025, 6, 4, 0, 0, 0, 0, DateTimeKind.Local), "adrian@gmail.com", "Adrian", "00000", "987654321", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "PlatformId", "Sales" },
                values: new object[,]
                {
                    { 1, 1, 50 },
                    { 2, 2, 44 },
                    { 3, 4, 22 },
                    { 4, 5, 4 },
                    { 5, 1, 141 },
                    { 6, 6, 967 }
                });

            migrationBuilder.InsertData(
                table: "Videogames",
                columns: new[] { "Id", "Description", "Developer", "Discount", "Distributor", "Name", "Pegi", "Price", "PrincipalImageURL", "ProductId", "ReleaseDate", "Requisitos1", "Requisitos2", "Stock" },
                values: new object[] { 1, "Juego de rol y acción en mundo abierto", "FromSoftware", 0, "Bandai Namco", "Elden Ring", 18, 59.99m, "https://upload.wikimedia.org/wikipedia/en/9/9c/Elden_Ring_Box_art.jpg", 1, new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i5-8400 / AMD Ryzen 3 3300X", "12 GB RAM, GTX 1060 3GB / Radeon RX 580", 100 });

            migrationBuilder.InsertData(
                table: "Videogames",
                columns: new[] { "Id", "Description", "Developer", "Discount", "Distributor", "Name", "Pegi", "Price", "PrincipalImageURL", "ProductId", "ReleaseDate", "Requisitos1", "Requisitos2", "Stock" },
                values: new object[] { 2, "Acción y aventura con mitología nórdica", "Santa Monica Studio", 5, "Sony Interactive Entertainment", "God of War Ragnarök", 18, 69.99m, "https://upload.wikimedia.org/wikipedia/en/9/9e/God_of_War_Ragnar%C3%B6k_cover.jpg", 2, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 75 });

            migrationBuilder.InsertData(
                table: "Videogames",
                columns: new[] { "Id", "Description", "Developer", "Discount", "Distributor", "Name", "Pegi", "Price", "PrincipalImageURL", "ProductId", "ReleaseDate", "Requisitos1", "Requisitos2", "Stock" },
                values: new object[] { 3, "RPG ambientado en el mundo de Harry Potter", "Portkey Games", 10, "Warner Bros. Games", "Hogwarts Legacy", 16, 49.99m, "https://upload.wikimedia.org/wikipedia/en/7/76/Hogwarts_Legacy_cover.jpg", 3, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i5-6600 / AMD Ryzen 5 1400", "16 GB RAM, GTX 1070 / RX Vega 56", 80 });
        }
    }
}
