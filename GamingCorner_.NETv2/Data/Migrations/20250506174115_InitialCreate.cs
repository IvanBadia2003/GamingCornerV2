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
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Requisitos1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Requisitos2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    { 1, true, "COD Infinite Warfare nuevo en perfectas condiciones y con su precinto", "https://cdn.wallapop.com/images/10420/g2/d9/__/c10420p971437424/i4694537666.jpg?pictureSize=W640", "COD nuevo", 15m },
                    { 2, true, "Juego casi nuevo", "https://secondbest.es/wp-content/uploads/2024/08/Photoroom-20240823_175759_1.webp", "Uncharted", 10m },
                    { 3, true, "Practicamente nuevo", "https://images.milanuncios.com/api/v1/ma-ad-media-pro/images/69f02b50-a035-4b00-a96b-184ba7a061d1?rule=hw396_70", "Dark Souls", 7m }
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
                columns: new[] { "ConsoleId", "Available", "ImageURL", "Name", "PlatformId", "Price", "Specifications", "Stock" },
                values: new object[,]
                {
                    { 1, true, "https://gmedia.playstation.com/is/image/SIEPDC/ps4-pro-product-thumbnail-01-en-14sep21", "Play Station 4", 1, 300m, "CPU:AMD 'Jaguar' x86-64, 8 núcleos; GPU: motor gráfico AMD de 1,84 TFLOPS basado en Radeon; Memoria:8 GB GDDR5; Almacenamiento:1 TB; Peso: Aprox. 2,1 Kg; Entrada/Salida:2 puertos de altísima velocidad USB (USB 3.1 Gen1) y 1 puerto AUX; Red:1 puerto Ethernet (10BASE-T, 100BASE-TX, 1000BASE-T) / IEEE 802.11 a/b/g/n/ac / Bluetooth® 4.0; Alimentacion:AC de 100-240 V, 50/60 Hz; Consumo de energia: 165W; Salida AV:Salida HDMI™ (compatible con salida HDR)", 16 },
                    { 2, true, "https://m.media-amazon.com/images/I/51f6iZlNnvL.jpg", "Play Station 5", 1, 490m, "CPU: AMD Ryzen Zen 2, 8 núcleos a 3.5GHz; GPU: AMD RDNA 2, 10.28 TFLOPs, 36 CUs a 2.23GHz; Memoria: 16 GB GDDR6; Almacenamiento: SSD personalizado de 825 GB; Peso: Aprox. 4.5 Kg; Entrada/Salida: 2 puertos USB de alta velocidad (USB 3.1 Gen2), 1 puerto USB-C; Red: 1 puerto Ethernet (10BASE-T, 100BASE-TX, 1000BASE-T), Wi-Fi 6 (802.11ax), Bluetooth® 5.1; Alimentación: AC 100-240V, 50/60Hz; Consumo de energía: 350W; Salida AV: Salida HDMI™ 2.1 (compatible con 4K a 120Hz, 8K, y HDR)", 16 },
                    { 3, true, "https://i.ebayimg.com/images/g/oBUAAOSwVgljSZS8/s-l400.jpg", "Xbox 360", 3, 265m, "CPU: IBM PowerPC Tri-Core Xenon a 3.2GHz; GPU: ATI Xenos, 240 GFLOPs; Memoria: 512 MB GDDR3 a 700 MHz; Almacenamiento: Disco duro de 20 GB/60 GB/120 GB (según modelo); Peso: Aprox. 3.5 Kg; Entrada/Salida: 3 puertos USB 2.0; Red: 1 puerto Ethernet (10/100), Wi-Fi opcional con adaptador externo (en modelos antiguos); Alimentación: AC 100-240V, 50/60Hz; Consumo de energía: Aprox. 175W; Salida AV: Salida HDMI™, Salida por componentes, Salida por cable AV estándar", 5 },
                    { 4, true, "https://m.media-amazon.com/images/I/61nq7mC0tHL._AC_UF894,1000_QL80_.jpg", "Xbox Series X", 3, 500m, "CPU: AMD Ryzen Zen 2, 8 núcleos a 3.8GHz (3.6GHz con SMT); GPU: AMD RDNA 2, 12 TFLOPs, 52 CUs a 1.825GHz; Memoria: 16 GB GDDR6; Almacenamiento: SSD NVMe personalizado de 1 TB; Peso: Aprox. 4.45 Kg; Entrada/Salida: 3 puertos USB 3.1 Gen1; Red: 1 puerto Ethernet (10/100/1000), Wi-Fi 5 (802.11ac), Bluetooth®; Alimentación: AC 100-240V, 50/60Hz; Consumo de energía: Aprox. 315W; Salida AV: Salida HDMI™ 2.1 (compatible con 4K a 120Hz, 8K, y HDR)", 8 },
                    { 5, true, "https://img.pccomponentes.com/articles/23/233482/consola-nintendo-switch-1351124-81-l.jpg", "Nintendo Switch", 4, 280m, "CPU: NVIDIA Custom Tegra Processor; GPU: NVIDIA GPU basada en arquitectura Maxwell; Memoria: 4 GB LPDDR4; Almacenamiento: 32 GB de almacenamiento interno (expandible mediante tarjeta microSD hasta 2 TB); Peso: Aprox. 0.88 Kg (con Joy-Con); Entrada/Salida: 1 puerto USB Type-C (para carga), 1 puerto para cartuchos de juego, ranura para tarjeta microSD; Red: Wi-Fi 802.11 a/b/g/n/ac, Bluetooth® 4.1, Soporte LAN con adaptador (vía base de acoplamiento); Alimentación: Batería interna de ion de litio de 4310mAh, cargador AC 100-240V; Consumo de energía: Aprox. 18W (en modo portátil); Salida AV: Salida HDMI™ (modo TV, hasta 1080p), pantalla de 6.2 pulgadas LCD (1280x720 en modo portátil)", 6 },
                    { 6, true, "https://img.pccomponentes.com/articles/22/224445/1.jpg", "Nintendo Switch Lite", 4, 160m, "CPU: NVIDIA Custom Tegra Processor; GPU: NVIDIA GPU basada en arquitectura Maxwell; Memoria: 4 GB LPDDR4; Almacenamiento: 32 GB de almacenamiento interno (expandible mediante tarjeta microSD hasta 2 TB); Peso: Aprox. 0.275 Kg; Entrada/Salida: 1 puerto USB Type-C (para carga), 1 puerto para cartuchos de juego, ranura para tarjeta microSD; Red: Wi-Fi 802.11 a/b/g/n/ac, Bluetooth® 4.1; Alimentación: Batería interna de ion de litio de 3570mAh, cargador AC 100-240V; Consumo de energía: Aprox. 13.5W (en modo portátil); Salida AV: Pantalla de 5.5 pulgadas LCD (1280x720), sin salida HDMI (solo modo portátil)", 10 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "ConsoleId", "Date", "ProductId", "Type", "UserId", "VideogameId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 5, 6, 19, 41, 14, 860, DateTimeKind.Local).AddTicks(2299), 1, "Compra", 1, null },
                    { 2, null, new DateTime(2025, 5, 6, 19, 41, 14, 860, DateTimeKind.Local).AddTicks(2335), 2, "Compra", 2, null },
                    { 3, null, new DateTime(2025, 5, 6, 19, 41, 14, 860, DateTimeKind.Local).AddTicks(2337), 3, "Compra", 3, null }
                });

            migrationBuilder.InsertData(
                table: "Videogames",
                columns: new[] { "VideogameId", "Available", "Code", "Description", "GenderId", "ImageURL", "Name", "Pegi", "PlatformId", "Price", "Requisitos1", "Requisitos2", "Stock", "UserId" },
                values: new object[,]
                {
                    { 1, true, "code1", "Rocket League es un videojuego que combina fútbol con vehículos propulsados por cohetes, desarrollado por Psyonix. Los jugadores controlan autos que pueden saltar y volar brevemente para golpear un balón gigante e intentar marcar goles en la portería del equipo contrario. El juego cuenta con modos tanto en solitario como multijugador, tanto en línea como local, y ofrece partidas competitivas y casuales. Con su jugabilidad rápida, mecánicas simples pero desafiantes, y una comunidad activa, Rocket League se ha convertido en un fenómeno popular en el mundo de los eSports y el gaming casual.", 1, "https://images.igdb.com/igdb/image/upload/t_cover_big/co5w0w.webp", "Rocket League", 12, 1, 15m, "Windows 7; Intel Core 2 Duo E4600; 2 GB RAM; NVIDIA GeForce 8800; 7 GB disponibles; 11", "OS: Windows 10; Procesador: Intel Core i5-2550K; Memoria: 4 GB RAM; Gráfica: NVIDIA GeForce GTX 660; Almacenamiento: 7 GB disponibles; DirectX: 11", 3, 1 },
                    { 2, true, "code2", "Grand Theft Auto V (GTA 5) es un juego de acción y aventura en mundo abierto desarrollado por Rockstar Games, ambientado en la ciudad ficticia de Los Santos, basada en Los Ángeles. La historia sigue a tres personajes: Michael, un ex ladrón de bancos; Franklin, un joven ambicioso; y Trevor, un ex compañero de Michael con tendencias violentas. Juntos realizan una serie de atracos mientras enfrentan problemas con el gobierno y pandillas. El juego ofrece libertad para explorar, realizar misiones, y participar en actividades variadas, además de contar con un modo en línea multijugador llamado GTA Online.", 2, "https://images.igdb.com/igdb/image/upload/t_cover_big/co1twh.webp", "GTA 5", 18, 2, 13m, "Windows 7; Procesador: Intel Core 2 Quad CPU Q6600; Memoria: 4 GB RAM; Gráfica: NVIDIA 9800 GT; Almacenamiento: 72 GB disponibles; DirectX: 11", "OS: Windows 10; Procesador: Intel Core i5 3470; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 660 2GB; Almacenamiento: 72 GB disponibles; DirectX: 11", 7, 1 },
                    { 3, true, "code3", "The Witcher 3: Wild Hunt es un juego de rol de acción desarrollado por CD Projekt Red, basado en las novelas de Andrzej Sapkowski. Los jugadores asumen el papel de Geralt de Rivia, un cazador de monstruos conocido como brujo, mientras recorre un vasto mundo abierto lleno de misiones, criaturas, y personajes complejos. La historia principal sigue a Geralt en su búsqueda por encontrar a su hija adoptiva, Ciri, mientras el continente está envuelto en conflictos políticos y la amenaza de la mítica Cacería Salvaje. Con su narrativa profunda, sistema de combate dinámico, y un mundo detallado lleno de decisiones morales, The Witcher 3 es considerado uno de los mejores videojuegos de todos los tiempos.", 3, "https://images.igdb.com/igdb/image/upload/t_cover_big/co2lgo.webp", "The Witcher 3", 18, 3, 20m, "Windows 7; Procesador: Intel Core i5-2500K; Memoria: 6 GB RAM; Gráfica: NVIDIA GeForce GTX 660; Almacenamiento: 35 GB disponibles; DirectX: 11", "OS: Windows 10; Procesador: Intel Core i7 3770; Memoria: 8 GB RAM; Gráfica: NVIDIA GeForce GTX 770; Almacenamiento: 35 GB disponibles; DirectX: 12", 5, 2 },
                    { 4, true, "code4", "Minecraft es un videojuego de construcción y supervivencia desarrollado por Mojang Studios. En un mundo abierto y generado de manera procedural, los jugadores pueden recolectar recursos, construir estructuras, explorar cuevas y combatir criaturas mientras gestionan su supervivencia. El juego cuenta con varios modos, como el modo supervivencia, donde los jugadores deben gestionar su salud y hambre, y el modo creativo, que ofrece recursos ilimitados para la construcción libre. Con su estilo gráfico de bloques y su libertad casi infinita para crear, Minecraft se ha convertido en uno de los juegos más influyentes y vendidos de todos los tiempos, con una gran comunidad y mods que amplían su jugabilidad.", 4, "https://images.igdb.com/igdb/image/upload/t_cover_big/co2b4k.webp", "Minecraft", 7, 1, 25m, "Windows 7; Procesador: Intel Core i3-3210; Memoria: 4 GB RAM; Gráfica: Intel HD Graphics 4000; Almacenamiento: 1 GB disponibles; DirectX: 11", "OS: Windows 10; Procesador: Intel Core i5-4690; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 960; Almacenamiento: 4 GB disponibles; DirectX: 12", 10, 3 },
                    { 5, true, "code5", "Fortnite es un videojuego multijugador en línea desarrollado por Epic Games, conocido principalmente por su modo Battle Royale, donde 100 jugadores compiten en una isla para ser el último en pie. Los jugadores deben recolectar armas, materiales para construir estructuras, y sobrevivir a una tormenta que reduce el área jugable. Con su jugabilidad rápida, gráficos coloridos, y la capacidad de construir estructuras defensivas durante los combates, Fortnite ha ganado una enorme popularidad a nivel mundial. El juego también cuenta con otros modos, como Salva el Mundo (un modo cooperativo) y Creativo, donde los jugadores pueden diseñar sus propios mundos.", 5, "https://images.igdb.com/igdb/image/upload/t_cover_big/co2ekt.webp", "Fortnite", 12, 2, 0m, "OS: Windows 7; Procesador: Intel Core i3-3225; Memoria: 4 GB RAM; Gráfica: Intel HD 4000; Almacenamiento: 15 GB disponibles; DirectX: 11", "OS: Windows 10; Procesador: Intel Core i5-7300U; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 960; Almacenamiento: 15 GB disponibles; DirectX: 12", 8, 2 },
                    { 6, true, "code6", "Overwatch es un juego de disparos en primera persona basado en equipos, desarrollado por Blizzard Entertainment. En el juego, los jugadores eligen entre una amplia gama de personajes, conocidos como héroes, cada uno con habilidades únicas y roles específicos dentro del equipo (daño, tanque, o apoyo). Los equipos de seis jugadores compiten en diversos modos de juego que incluyen capturar objetivos o escoltar cargas a lo largo de mapas detallados. Overwatch destaca por su enfoque en el trabajo en equipo, su jugabilidad rápida y accesible, y su elenco diverso de personajes, lo que lo ha convertido en uno de los títulos más populares en el ámbito de los eSports y los juegos multijugador.", 1, "https://images.igdb.com/igdb/image/upload/t_cover_big/co7v86.webp", "Overwatch", 12, 3, 30m, "Windows 7; Procesador: Intel Core i3; Memoria: 4 GB RAM; Gráfica: NVIDIA GeForce GTX 460; Almacenamiento: 30 GB disponibles; DirectX: 11", "OS: Windows 10; Procesador: Intel Core i5; Memoria: 6 GB RAM; Gráfica: NVIDIA GeForce GTX 660; Almacenamiento: 30 GB disponibles; DirectX: 12", 6, 1 },
                    { 7, true, "code7", "FIFA 21 es un simulador de fútbol desarrollado por EA Sports, parte de la popular franquicia FIFA. El juego ofrece modos de juego variados, desde partidos rápidos hasta competiciones completas, incluyendo FIFA Ultimate Team (FUT), donde los jugadores pueden crear y gestionar su propio equipo con cartas de futbolistas reales, y el Modo Carrera, que permite dirigir un equipo o un jugador a lo largo de varias temporadas. Con mejoras en la jugabilidad, gráficos realistas y una amplia lista de equipos y ligas con licencias oficiales, FIFA 21 busca ofrecer una experiencia auténtica de fútbol tanto en modos en solitario como en multijugador en línea.", 2, "https://images.igdb.com/igdb/image/upload/t_cover_big/co3wm2.webp", "FIFA 21", 3, 1, 50m, "OS: Windows 7; Procesador: Intel Core i3-6100; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 660; Almacenamiento: 50 GB disponibles; DirectX: 11", "OS: Windows 10; Procesador: Intel i5-3550; Memoria: 8 GB RAM; Gráfica: NVIDIA GeForce GTX 670; Almacenamiento: 50 GB disponibles; DirectX: 12", 12, 2 },
                    { 8, true, "code8", "Cyberpunk 2077 es un juego de rol de acción desarrollado por CD Projekt Red, ambientado en un futuro distópico en la metrópolis de Night City. Los jugadores controlan a V, un mercenario personalizable que puede mejorar sus habilidades con implantes cibernéticos, mientras navega por un mundo abierto lleno de corporaciones corruptas, bandas criminales y tecnología avanzada. El juego ofrece una narrativa profunda con decisiones que impactan la historia, un sistema de combate variado que incluye armas de fuego y habilidades cuerpo a cuerpo, y una rica personalización de personajes. A pesar de su lanzamiento inicial con algunos problemas técnicos, Cyberpunk 2077 ha sido elogiado por su inmersivo diseño de mundo, historia y libertad de juego.", 3, "https://images.igdb.com/igdb/image/upload/t_cover_big/co64re.webp", "Cyberpunk 2077", 18, 2, 60m, "Windows 7; Procesador: Intel Core i5-3570K; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 780; Almacenamiento: 70 GB disponibles; DirectX: 11", "OS: Windows 10; Procesador: Intel Core i7-4790; Memoria: 12 GB RAM; Gráfica: NVIDIA RTX 2060; Almacenamiento: 70 GB disponibles; DirectX: 12", 4, 3 },
                    { 9, true, "code9", "Red Dead Redemption 2 es un juego de acción y aventura desarrollado por Rockstar Games, ambientado en el salvaje oeste de Estados Unidos a finales del siglo XIX. Los jugadores asumen el papel de Arthur Morgan, un forajido miembro de la banda de Dutch van der Linde, mientras lucha por sobrevivir en un mundo cambiante donde la ley y el orden están comenzando a imponerse. El juego ofrece un vasto mundo abierto con una atención meticulosa a los detalles, permitiendo a los jugadores cazar, pescar, interactuar con personajes y tomar decisiones que afectan la narrativa. Con su trama profunda, personajes complejos y una jugabilidad inmersiva, Red Dead Redemption 2 ha sido aclamado como uno de los mejores videojuegos de todos los tiempos.", 4, "https://images.igdb.com/igdb/image/upload/t_cover_big/co1q1f.webp", "Red Dead Redemption 2", 18, 3, 40m, "Windows 7; Procesador: Intel Core i5-2500K; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 770; Almacenamiento: 150 GB disponibles; DirectX: 11", "OS: Windows 10; Procesador: Intel Core i7-4770K; Memoria: 12 GB RAM; Gráfica: NVIDIA RTX 2060; Almacenamiento: 150 GB disponibles; DirectX: 12", 9, 3 },
                    { 10, true, "code10", "Assassin's Creed Valhalla es un juego de acción y rol desarrollado por Ubisoft, ambientado en la época vikinga, específicamente durante la invasión de Inglaterra en el siglo IX. Los jugadores controlan a Eivor, un guerrero vikingo que lidera a su clan en busca de un nuevo hogar en tierras inglesas, mientras lidia con la lucha entre asesinos y templarios. El juego combina exploración en un vasto mundo abierto, combates brutales, y la posibilidad de desarrollar asentamientos. Con un enfoque en la personalización de personajes, combate táctico y narrativas basadas en elecciones, Assassin's Creed Valhalla ofrece una experiencia inmersiva de la vida vikinga y sus incursiones.", 5, "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rrw.webp", "Assassin's Creed Valhalla", 18, 4, 55m, "OS: Windows 7; Procesador: Intel Core i5-4460; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 960; Almacenamiento: 50 GB disponibles; DirectX: 11", "OS: Windows 10; Procesador: Intel Core i7-6700; Memoria: 12 GB RAM; Gráfica: NVIDIA RTX 2060; Almacenamiento: 50 GB disponibles; DirectX: 12", 7, 1 },
                    { 11, true, "code11", "Call of Duty: Modern Warfare es un juego de disparos en primera persona desarrollado por Infinity Ward y publicado por Activision. Lanzado en 2019, es una reinvención del sub-franquicia Modern Warfare, y ofrece una campaña centrada en conflictos militares modernos y operaciones encubiertas en el Medio Oriente y Europa. Los jugadores asumen el rol de personajes como Captain Price y un equipo de soldados de élite que luchan contra grupos terroristas y fuerzas enemigas. Además de su intensa campaña, el juego incluye modos multijugador competitivos y el popular modo Warzone, que introduce el formato battle royale. Con gráficos realistas, jugabilidad táctica y un enfoque en la narrativa cruda y madura, Modern Warfare ha sido aclamado tanto por su campaña como por su multijugador.", 1, "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rsg.webp", "Call of Duty: Modern Warfare", 18, 4, 50m, "Windows 7; Procesador: Intel Core i3-4340; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 670; Almacenamiento: 175 GB disponibles; DirectX: 11", "OS: Windows 10; Procesador: Intel Core i7-6700; Memoria: 12 GB RAM; Gráfica: NVIDIA RTX 2070; Almacenamiento: 175 GB disponibles; DirectX: 12", 11, 1 },
                    { 12, true, "code12", "Horizon Zero Dawn es un juego de rol y acción desarrollado por Guerrilla Games. Ambientado en un futuro postapocalíptico donde las máquinas dominan la Tierra, los jugadores controlan a Aloy, una joven cazadora en busca de respuestas sobre su origen y el mundo que la rodea. La historia sigue a Aloy mientras explora vastos paisajes abiertos, lucha contra criaturas robóticas, y descubre los secretos de una civilización perdida. El juego combina combate estratégico, donde los jugadores deben usar trampas, armas y habilidades para derrotar a las máquinas, con una narrativa profunda y visualmente impresionante. Horizon Zero Dawn ha sido elogiado por su mundo inmersivo, mecánicas de combate innovadoras y la protagonista carismática.", 2, "https://images.igdb.com/igdb/image/upload/t_cover_big/co2una.webp", "Horizon Zero Dawn", 16, 4, 35m, "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", 5, 2 },
                    { 13, true, "code13", "Stardew Valley es un juego de simulación de granja desarrollado por ConcernedApe. Los jugadores asumen el papel de un personaje que hereda una granja en mal estado y deben restaurarla plantando cultivos, criando animales, pescando, y explorando minas en busca de recursos. Además de las actividades agrícolas, el juego incluye elementos de interacción social con los habitantes de la cercana Pelican Town, lo que permite a los jugadores formar amistades e incluso casarse. Con su estilo retro pixelado, jugabilidad relajante y libertad para gestionar la granja a su propio ritmo, Stardew Valley se ha convertido en un juego indie muy popular por su encanto, profundidad y capacidad de personalización.", 3, "https://images.igdb.com/igdb/image/upload/t_cover_big/xrpmydnu9rpxvxfjkiu7.webp", "Stardew Valley", 7, 4, 20m, "OS: Windows 7; Procesador: Intel Core i5-2500K; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 780; Almacenamiento: 100 GB disponibles; DirectX: 11", "OS: Windows 10; Procesador: Intel Core i7-4770K; Memoria: 16 GB RAM; Gráfica: NVIDIA RTX 2060; Almacenamiento: 100 GB disponibles; DirectX: 12", 8, 2 },
                    { 14, true, "code14", "Among Us es un juego multijugador en línea desarrollado por InnerSloth, en el que los jugadores deben trabajar juntos para completar tareas en una nave espacial, estación o base, mientras un grupo de impostores intenta sabotear la misión y eliminar a los demás jugadores. Los jugadores asumen uno de dos roles: tripulantes, que deben realizar tareas y descubrir a los impostores, o impostores, que deben sabotear y eliminar a los tripulantes sin ser descubiertos. Con su jugabilidad basada en la deducción social y las reuniones donde los jugadores discuten quién puede ser el impostor, Among Us se ha vuelto enormemente popular por su enfoque en la colaboración, traición y estrategia.", 4, "https://images.igdb.com/igdb/image/upload/t_cover_big/co6kqt.webp", "Among Us", 10, 1, 5m, "OS: Windows 7; Procesador: Intel Pentium 4; Memoria: 1 GB RAM; Gráfica: NVIDIA GeForce 6100; Almacenamiento: 250 MB disponibles; DirectX: 11", "OS: Windows 10; Procesador: Intel Core i3-6100; Memoria: 2 GB RAM; Gráfica: NVIDIA GTX 660; Almacenamiento: 250 MB disponibles; DirectX: 12", 15, 2 },
                    { 15, true, "code15", "The Legend of Zelda: Breath of the Wild es un juego de acción y aventura desarrollado por Nintendo, ambientado en el vasto reino abierto de Hyrule. Los jugadores controlan a Link, quien despierta de un largo sueño para derrotar a Ganon, una antigua fuerza maligna que amenaza con destruir el reino. El juego destaca por su enfoque en la exploración, permitiendo a los jugadores escalar montañas, nadar, y planear a través del mundo mientras resuelven puzles, enfrentan enemigos y descubren secretos. Con un sistema de físicas realista, libertad sin precedentes en la serie, y una narrativa ambiental rica, Breath of the Wild es considerado uno de los mejores videojuegos de todos los tiempos por su innovación y profundidad.", 5, "https://images.igdb.com/igdb/image/upload/t_cover_small/co4n26.png", "The Legend of Zelda: Breath of the Wild", 12, 2, 60m, "OS: Windows 7; Procesador: Intel Core i5-2400S; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 750; Almacenamiento: 40 GB disponibles; DirectX: 11", "OS: Windows 10; Procesador: Intel Core i7-4790; Memoria: 12 GB RAM; Gráfica: NVIDIA RTX 2060; Almacenamiento: 40 GB disponibles; DirectX: 12", 6, 3 },
                    { 16, true, "code15", "God of War es un juego de acción y aventura desarrollado por Santa Monica Studio y publicado por Sony Interactive Entertainment. Lanzado en 2018, es una reinvención de la serie y sigue a Kratos, el dios de la guerra, en una nueva etapa de su vida en la mitología nórdica. Acompañado por su hijo Atreus, Kratos debe enfrentarse a poderosos enemigos y criaturas míticas mientras lidia con sus propios demonios internos y enseña a su hijo a sobrevivir en un mundo hostil. El juego combina combates intensos con una narrativa emocional, explorando temas de paternidad, redención y autodescubrimiento. Con su innovador sistema de combate, impresionantes gráficos y un mundo abierto lleno de secretos, God of War ha sido aclamado como uno de los mejores videojuegos de la historia.", 5, "https://images.igdb.com/igdb/image/upload/t_cover_big/co1tmu.webp", "God of War", 12, 2, 60m, "OS: Windows 10 (64 bits); Procesador: Intel i5-2500K (3.3 GHz) o AMD Ryzen 3 1200; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 960 (4 GB) o AMD R9 290X (4 GB); Almacenamiento: 70 GB disponibles; DirectX: 11", "OS: Windows 10 (64 bits); Procesador: Intel i7-4770K (3.5 GHz) o AMD Ryzen 7 2700X; Memoria: 16 GB RAM; Gráfica: NVIDIA RTX 2060 (6 GB) o AMD RX 5700 XT (8 GB); Almacenamiento: 70 GB disponibles; DirectX: 12", 6, 3 }
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
