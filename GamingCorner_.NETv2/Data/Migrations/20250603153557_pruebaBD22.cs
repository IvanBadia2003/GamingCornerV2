using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamingCorner.Data.Migrations
{
    public partial class pruebaBD22 : Migration
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
                    System = table.Column<int>(type: "int", nullable: false)
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
                    Admin = table.Column<bool>(type: "bit", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "OrderHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHeaders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => new { x.UserId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Baskets_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Baskets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
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
                    Generation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Services = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colors = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Favourites",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    DateAdd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => new { x.UserId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Favourites_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favourites_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
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
                    ProductId = table.Column<int>(type: "int", nullable: false)
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
                    { 1, "C/ La Lectura", true, "", new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), "diego@gmail.com", "Diego", "12345", "601112734", 1, 1 },
                    { 2, "Avda. San Juan de la Peña", true, "", new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), "ivan@gmail.com", "Ivan", "12345", "123456789", 1, 1 },
                    { 3, "El Actur", false, "", new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Local), "adrian@gmail.com", "Adrian", "00000", "987654321", 1, 1 }
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

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_ProductId",
                table: "Baskets",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Consoles_ProductId",
                table: "Consoles",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_ProductId",
                table: "Favourites",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHeaders_UserId",
                table: "OrderHeaders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PlatformId",
                table: "Products",
                column: "PlatformId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Consoles");

            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.DropTable(
                name: "OrderHeaders");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "SecondHandProducts");

            migrationBuilder.DropTable(
                name: "VideogameGenders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Videogames");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
