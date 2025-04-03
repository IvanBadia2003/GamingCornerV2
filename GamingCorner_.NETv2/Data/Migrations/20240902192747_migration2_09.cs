using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class migration2_09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    PlatformId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.PlatformId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Consoles",
                columns: table => new
                {
                    ConsoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    Specifications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consoles", x => x.ConsoleId);
                    table.ForeignKey(
                        name: "FK_Consoles_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "PlatformId");
                });

            migrationBuilder.CreateTable(
                name: "Videogames",
                columns: table => new
                {
                    VideogameId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pegi = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Requisitos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlatformId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videogames", x => x.VideogameId);
                    table.ForeignKey(
                        name: "FK_Videogames_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Videogames_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "PlatformId");
                    table.ForeignKey(
                        name: "FK_Videogames_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    VideogameId = table.Column<int>(type: "int", nullable: true),
                    ConsoleId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Consoles_ConsoleId",
                        column: x => x.ConsoleId,
                        principalTable: "Consoles",
                        principalColumn: "ConsoleId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Transactions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Videogames_VideogameId",
                        column: x => x.VideogameId,
                        principalTable: "Videogames",
                        principalColumn: "VideogameId",
                        onDelete: ReferentialAction.SetNull);
                });

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
                columns: new[] { "PlatformId", "Name" },
                values: new object[,]
                {
                    { 1, "Steam" },
                    { 2, "Play Station" },
                    { 3, "Xbox" },
                    { 4, "Switch" },
                    { 5, "Ubisoft" },
                    { 6, "Epic Games" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Available", "Description", "ImageURL", "Name", "Price" },
                values: new object[,]
                {
                    { 1, true, "COD BO4 nuevo en perfectas condiciones", "", "COD nuevo", 15m },
                    { 2, true, "Juego casi nuevo", "", "Uncharted", 10m },
                    { 3, true, "Practicamente nuevo", "", "Dark Souls", 7m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "Admin", "Email", "ImageURL", "Name", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "C/ La Lectura", true, "diego@gmail.com", "", "Diego", "12345", "601112734" },
                    { 2, "Avda. San Juan de la Peña", true, "ivan@gmail.com", "", "Ivan", "12345", "123456789" },
                    { 3, "El Actur", false, "adrian@gmail.com", "", "Adrian", "00000", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "Consoles",
                columns: new[] { "ConsoleId", "Available", "ImageURL", "Name", "PlatformId", "Price", "Specifications", "Stock" },
                values: new object[,]
                {
                    { 1, true, "", "Play Station 4", 1, 300m, "Ta bien", 16 },
                    { 2, true, "", "Xbox 360", 3, 265m, "Ta bien pero no tanto", 5 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "ConsoleId", "Date", "ProductId", "Type", "UserId", "VideogameId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 9, 2, 21, 27, 47, 730, DateTimeKind.Local).AddTicks(293), 1, "Compra", 1, null },
                    { 2, null, new DateTime(2024, 9, 2, 21, 27, 47, 730, DateTimeKind.Local).AddTicks(328), 2, "Compra", 2, null },
                    { 3, null, new DateTime(2024, 9, 2, 21, 27, 47, 730, DateTimeKind.Local).AddTicks(330), 3, "Compra", 3, null }
                });

            migrationBuilder.InsertData(
                table: "Videogames",
                columns: new[] { "VideogameId", "Available", "Description", "GenderId", "ImageURL", "Name", "Pegi", "PlatformId", "Price", "Requisitos", "Stock", "UserId" },
                values: new object[,]
                {
                    { 1, true, "Altos carros voladores", 1, "https://images.igdb.com/igdb/image/upload/t_cover_big/co5w0w.webp", "Rocket League", 12, 1, 15m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 3, 1 },
                    { 2, true, "Gran Robo de Autos", 2, "https://images.igdb.com/igdb/image/upload/t_cover_big/co1twh.webp", "GTA 5", 18, 2, 13m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 7, 1 },
                    { 3, true, "Aventura épica en un mundo de fantasía", 3, "https://images.igdb.com/igdb/image/upload/t_cover_big/co2lgo.webp", "The Witcher 3", 18, 3, 20m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 5, 2 },
                    { 4, true, "Juego de construcción y aventuras", 4, "https://images.igdb.com/igdb/image/upload/t_cover_big/co2b4k.webp", "Minecraft", 7, 1, 25m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 10, 3 },
                    { 5, true, "Juego de supervivencia y construcción", 5, "https://images.igdb.com/igdb/image/upload/t_cover_big/co2ekt.webp", "Fortnite", 12, 2, 0m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 8, 2 },
                    { 6, true, "Juego de disparos en equipo", 1, "https://images.igdb.com/igdb/image/upload/t_cover_big/co7v86.webp", "Overwatch", 12, 3, 30m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 6, 1 },
                    { 7, true, "Simulación de fútbol", 2, "https://images.igdb.com/igdb/image/upload/t_cover_big/co3wm2.webp", "FIFA 21", 3, 1, 50m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 12, 2 },
                    { 8, true, "Aventura en un mundo futurista", 3, "https://images.igdb.com/igdb/image/upload/t_cover_big/co64re.webp", "Cyberpunk 2077", 18, 2, 60m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 4, 3 },
                    { 9, true, "Aventura en el Viejo Oeste", 4, "https://images.igdb.com/igdb/image/upload/t_cover_big/co1q1f.webp", "Red Dead Redemption 2", 18, 3, 40m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 9, 3 },
                    { 10, true, "Aventura de vikingos", 5, "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rrw.webp", "Assassin's Creed Valhalla", 18, 4, 55m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 7, 1 },
                    { 11, true, "Juego de disparos en primera persona", 1, "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rsg.webp", "Call of Duty: Modern Warfare", 18, 4, 50m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 11, 1 },
                    { 12, true, "Aventura en un mundo postapocalíptico", 2, "https://images.igdb.com/igdb/image/upload/t_cover_big/co2una.webp", "Horizon Zero Dawn", 16, 4, 35m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 5, 2 },
                    { 13, true, "Simulación de granja", 3, "https://images.igdb.com/igdb/image/upload/t_cover_big/xrpmydnu9rpxvxfjkiu7.webp", "Stardew Valley", 7, 4, 20m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 8, 2 },
                    { 14, true, "Juego de deducción social", 4, "https://images.igdb.com/igdb/image/upload/t_cover_big/co6kqt.webp", "Among Us", 10, 1, 5m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 15, 2 },
                    { 15, true, "Aventura en el mundo de Hyrule", 5, "https://images.igdb.com/igdb/image/upload/t_cover_small/co4n26.png", "The Legend of Zelda: Breath of the Wild", 12, 2, 60m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 6, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consoles_PlatformId",
                table: "Consoles",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ConsoleId",
                table: "Transactions",
                column: "ConsoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ProductId",
                table: "Transactions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_VideogameId",
                table: "Transactions",
                column: "VideogameId");

            migrationBuilder.CreateIndex(
                name: "IX_Videogames_GenderId",
                table: "Videogames",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Videogames_PlatformId",
                table: "Videogames",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Videogames_UserId",
                table: "Videogames",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Consoles");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Videogames");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
