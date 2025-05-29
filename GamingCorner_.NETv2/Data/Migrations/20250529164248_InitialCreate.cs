using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class InitialCreate : Migration
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrincipalImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.PlatformId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sales = table.Column<int>(type: "int", nullable: true),
                    PlatformId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "PlatformId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Specifications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrincipalImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consoles_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SecondHandProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondHandProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecondHandProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Videogames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pegi = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Developer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distributor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrincipalImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Requisitos1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Requisitos2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videogames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videogames_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Videogames_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "VideogameGenders",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    VideogameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideogameGenders", x => new { x.VideogameId, x.GenderId });
                    table.ForeignKey(
                        name: "FK_VideogameGenders_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VideogameGenders_Videogames_VideogameId",
                        column: x => x.VideogameId,
                        principalTable: "Videogames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "PlatformId", "Name", "PrincipalImageURL" },
                values: new object[,]
                {
                    { 1, "Steam", "" },
                    { 2, "Play Station", "" },
                    { 3, "Xbox", "" },
                    { 4, "Switch", "" },
                    { 5, "Ubisoft", "" },
                    { 6, "Epic Games", "" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "PlatformId", "Sales" },
                values: new object[,]
                {
                    { 1, null, 50 },
                    { 2, null, 44 },
                    { 3, null, 22 },
                    { 4, null, 4 },
                    { 5, null, 141 },
                    { 6, null, 967 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "Admin", "Email", "Name", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "C/ La Lectura", true, "diego@gmail.com", "Diego", "12345", "601112734" },
                    { 2, "Avda. San Juan de la Peña", true, "ivan@gmail.com", "Ivan", "12345", "123456789" },
                    { 3, "El Actur", false, "adrian@gmail.com", "Adrian", "00000", "987654321" }
                });

            migrationBuilder.InsertData(
                table: "Consoles",
                columns: new[] { "Id", "Brand", "Description", "Discount", "Name", "Price", "PrincipalImageURL", "ProductId", "ReleaseDate", "Specifications", "Stock" },
                values: new object[,]
                {
                    { 1, "Sony", "Consola muy buena", 50, "Play Station 4", 300m, "https://gmedia.playstation.com/is/image/SIEPDC/ps4-pro-product-thumbnail-01-en-14sep21", 4, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CPU:AMD 'Jaguar' x86-64, 8 núcleos; GPU: motor gráfico AMD de 1,84 TFLOPS basado en Radeon; Memoria:8 GB GDDR5; Almacenamiento:1 TB; Peso: Aprox. 2,1 Kg; Entrada/Salida:2 puertos de altísima velocidad USB (USB 3.1 Gen1) y 1 puerto AUX; Red:1 puerto Ethernet (10BASE-T, 100BASE-TX, 1000BASE-T) / IEEE 802.11 a/b/g/n/ac / Bluetooth® 4.0; Alimentacion:AC de 100-240 V, 50/60 Hz; Consumo de energia: 165W; Salida AV:Salida HDMI™ (compatible con salida HDR)", 16 },
                    { 2, "Sony", "Consola  buena", 10, "Play Station 5", 490m, "https://m.media-amazon.com/images/I/51f6iZlNnvL.jpg", 5, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CPU: AMD Ryzen Zen 2, 8 núcleos a 3.5GHz; GPU: AMD RDNA 2, 10.28 TFLOPs, 36 CUs a 2.23GHz; Memoria: 16 GB GDDR6; Almacenamiento: SSD personalizado de 825 GB; Peso: Aprox. 4.5 Kg; Entrada/Salida: 2 puertos USB de alta velocidad (USB 3.1 Gen2), 1 puerto USB-C; Red: 1 puerto Ethernet (10BASE-T, 100BASE-TX, 1000BASE-T), Wi-Fi 6 (802.11ax), Bluetooth® 5.1; Alimentación: AC 100-240V, 50/60Hz; Consumo de energía: 350W; Salida AV: Salida HDMI™ 2.1 (compatible con 4K a 120Hz, 8K, y HDR)", 16 },
                    { 3, "Microsoft", "Consola casi buena", 22, "Xbox 360", 265m, "https://i.ebayimg.com/images/g/oBUAAOSwVgljSZS8/s-l400.jpg", 6, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "CPU: IBM PowerPC Tri-Core Xenon a 3.2GHz; GPU: ATI Xenos, 240 GFLOPs; Memoria: 512 MB GDDR3 a 700 MHz; Almacenamiento: Disco duro de 20 GB/60 GB/120 GB (según modelo); Peso: Aprox. 3.5 Kg; Entrada/Salida: 3 puertos USB 2.0; Red: 1 puerto Ethernet (10/100), Wi-Fi opcional con adaptador externo (en modelos antiguos); Alimentación: AC 100-240V, 50/60Hz; Consumo de energía: Aprox. 175W; Salida AV: Salida HDMI™, Salida por componentes, Salida por cable AV estándar", 5 }
                });

            migrationBuilder.InsertData(
                table: "Videogames",
                columns: new[] { "Id", "Description", "Developer", "Discount", "Distributor", "Name", "Pegi", "Price", "PrincipalImageURL", "ProductId", "ReleaseDate", "Requisitos1", "Requisitos2", "Stock", "UserId" },
                values: new object[,]
                {
                    { 1, "Juego de rol y acción en mundo abierto", "FromSoftware", 0, "Bandai Namco", "Elden Ring", 18, 59.99m, "https://upload.wikimedia.org/wikipedia/en/9/9c/Elden_Ring_Box_art.jpg", 1, new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i5-8400 / AMD Ryzen 3 3300X", "12 GB RAM, GTX 1060 3GB / Radeon RX 580", 100, null },
                    { 2, "Acción y aventura con mitología nórdica", "Santa Monica Studio", 5, "Sony Interactive Entertainment", "God of War Ragnarök", 18, 69.99m, "https://upload.wikimedia.org/wikipedia/en/9/9e/God_of_War_Ragnar%C3%B6k_cover.jpg", 2, new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 75, null },
                    { 3, "RPG ambientado en el mundo de Harry Potter", "Portkey Games", 10, "Warner Bros. Games", "Hogwarts Legacy", 16, 49.99m, "https://upload.wikimedia.org/wikipedia/en/7/76/Hogwarts_Legacy_cover.jpg", 3, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Core i5-6600 / AMD Ryzen 5 1400", "16 GB RAM, GTX 1070 / RX Vega 56", 80, null }
                });

            migrationBuilder.InsertData(
                table: "VideogameGenders",
                columns: new[] { "GenderId", "VideogameId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 1, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consoles_ProductId",
                table: "Consoles",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_PlatformId",
                table: "Products",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_SecondHandProducts_ProductId",
                table: "SecondHandProducts",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideogameGenders_GenderId",
                table: "VideogameGenders",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Videogames_ProductId",
                table: "Videogames",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videogames_UserId",
                table: "Videogames",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consoles");

            migrationBuilder.DropTable(
                name: "SecondHandProducts");

            migrationBuilder.DropTable(
                name: "VideogameGenders");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Videogames");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
