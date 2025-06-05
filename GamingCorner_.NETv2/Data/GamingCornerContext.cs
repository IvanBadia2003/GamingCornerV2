using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using GamingCorner.Models;
using System.Security.Cryptography.X509Certificates;
using System.IO.Compression;
using GamingCorner.Models.Enums.UserStateEnum;
using GamingCorner.Models.Enums.RolEnums;

namespace GamingCorner.Data
{
    public class GamingCornerContext : DbContext
    {

        public GamingCornerContext(DbContextOptions<GamingCornerContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Relación 1:1 explícita
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Videogame)
                .WithOne(v => v.Product)
                .HasForeignKey<Videogame>(v => v.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // No se podrá borrar si está el juego creado


            modelBuilder.Entity<Product>()
                .HasOne(p => p.Console)
                .WithOne(c => c.Product)
                .HasForeignKey<Models.Console>(c => c.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // No se podrá borrar si está el juego creado


            modelBuilder.Entity<Product>()
                .HasOne(p => p.SecondHandProduct)
                .WithOne(c => c.Product)
                .HasForeignKey<SecondHandProduct>(c => c.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // No se podrá borrar si está el juego creado

            modelBuilder.Entity<VideogameGender>()
                .HasKey(v => new { v.VideogameId, v.GenderId });

            modelBuilder.Entity<Basket>()
                .HasKey(v => new { v.UserId, v.ProductId });

            modelBuilder.Entity<Basket>()
                .HasOne(v => v.Product)
                .WithMany(vl => vl.Baskets)
                .HasForeignKey(vli => vli.ProductId);

            modelBuilder.Entity<Basket>()
                .HasOne(v => v.User)
                .WithMany(vl => vl.Baskets)
                .HasForeignKey(vli => vli.UserId);

            modelBuilder.Entity<Favourite>()
                .HasKey(v => new { v.UserId, v.ProductId });

            modelBuilder.Entity<Favourite>()
                .HasOne(v => v.Product)
                .WithMany(vl => vl.Favourites)
                .HasForeignKey(vli => vli.ProductId);

            modelBuilder.Entity<Favourite>()
                .HasOne(v => v.User)
                .WithMany(vl => vl.Favourites)
                .HasForeignKey(vli => vli.UserId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // User - OrderHeader (1:N)
            modelBuilder.Entity<OrderHeader>()
                .HasOne(o => o.User)
                .WithMany(u => u.OrderHeaders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.SetNull);

            // OrderHeader - OrderLine (1:N)
            modelBuilder.Entity<OrderLine>()
                .HasOne(ol => ol.OrderHeader)
                .WithMany(oh => oh.OrderLines)
                .HasForeignKey(ol => ol.OrderHeaderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Product - OrderLine (1:N)
            modelBuilder.Entity<OrderLine>()
                .HasOne(ol => ol.Product)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(ol => ol.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SecondHandProduct>()
               .HasOne(s => s.User)
               .WithMany(u => u.SecondHandProducts)
               .HasForeignKey(s => s.UserId)
               .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<VideogameGender>()
            //     .HasOne(g => g.Gender)
            //     .WithMany(vl => vl.ListVideogameGender)
            //     .HasForeignKey(vli => vli.GenderId);


            //modelBuilder.Entity<Product>()
            //.HasOne(p => p.SecondHandProduct)
            //.WithOne(s => s.Product)
            // Habrá que poner el ProductID .HasForeignKey<SecondHandProduct>(s => s.);

            //modelBuilder.Entity<User>()
            //    .HasMany(v => v.Videogames)
            //    .WithOne(u => u.User)
            //    .HasForeignKey(u => u.UserId)
            //    .OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Entity<Videogame>()
            //    .HasOne(v => v.User)
            //    .WithMany(u => u.Videogames)
            //    .HasForeignKey(v => v.UserId)
            //    .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<User>()
                .HasKey(u => new { u.UserId });

            // modelBuilder.Entity<OrderHeader>()
            //    .HasMany(p => p.u)
            //    .WithOne(c => c.Platform)
            //    .HasForeignKey(c => c.PlatformId)
            //    .OnDelete(DeleteBehavior.SetNull); // Mantén o usa Restrict

            modelBuilder.Entity<Videogame>()
                .HasKey(v => new { v.Id });

            modelBuilder.Entity<Models.Console>()
                .HasKey(c => new { c.Id });

            modelBuilder.Entity<SecondHandProduct>()
                .HasKey(p => new { p.Id });

            modelBuilder.Entity<Platform>()
                .HasKey(p => new { p.PlatformId });

            modelBuilder.Entity<OrderHeader>()
                .HasKey(o => new { o.Id });

            modelBuilder.Entity<OrderLine>()
                .HasKey(o => new { o.Id });

            modelBuilder.Entity<Platform>()
               .HasMany(p => p.products)
               .WithOne(c => c.Platform)
               .HasForeignKey(c => c.PlatformId)
               .OnDelete(DeleteBehavior.SetNull); // Mantén o usa Restrict

            //modelBuilder.Entity<Platform>()
            //    .HasMany(p => p.Consoles)
            //    .WithOne(c => c.Platform)
            //    .HasForeignKey(c => c.PlatformId)
            //    .OnDelete(DeleteBehavior.Restrict); // Mantén o usa Restrict

            //modelBuilder.Entity<Platform>()
            //    .HasMany(p => p.videogames)
            //    .WithOne(v => v.Platform)
            //    .HasForeignKey(v => v.PlatformId)
            //    .OnDelete(DeleteBehavior.Restrict); // Mantén o usa Restrict


            //modelBuilder.Entity<Videogame>()
            //    .HasOne(v => v.Platform)
            //    .WithMany(p => p.videogames)
            //    .HasForeignKey(v => v.PlatformId)
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Gender>()
                .HasKey(ge => new { ge.GenderId });





 //           modelBuilder.Entity<User>().HasData(
 //               new User { UserId = 1, Name = "Diego", Address = "C/ La Lectura", Email = "diego@gmail.com", Password = "12345", PhoneNumber = "601112734", Admin = true, Avatar = "", DateCreated = DateTime.Today, Rol = RolEnum.Admin, State = UserStateEnum.Active },
 //               new User { UserId = 2, Name = "Ivan", Address = "Avda. San Juan de la Peña", Email = "ivan@gmail.com", Password = "12345", PhoneNumber = "123456789", Admin = true, Avatar = "", DateCreated = DateTime.Today, Rol = RolEnum.Admin, State = UserStateEnum.Active },
 //               new User { UserId = 3, Name = "Adrian", Address = "El Actur", Email = "adrian@gmail.com", Password = "00000", PhoneNumber = "987654321", Admin = false, Avatar = "", DateCreated = DateTime.Today, Rol = RolEnum.Admin, State = UserStateEnum.Active }
 //);


 //           modelBuilder.Entity<Platform>().HasData(
 //              new Platform { PlatformId = 1, Name = "Steam" },
 //              new Platform { PlatformId = 2, Name = "Play Station" },
 //              new Platform { PlatformId = 3, Name = "Xbox" },
 //              new Platform { PlatformId = 4, Name = "Switch" },
 //              new Platform { PlatformId = 5, Name = "Ubisoft" },
 //              new Platform { PlatformId = 6, Name = "Epic Games" }
 //           );

 //           modelBuilder.Entity<Product>().HasData(
 //             new Product { Id = 1, Sales = 50, PlatformId = 1 },
 //             new Product { Id = 2, Sales = 44, PlatformId = 2 },
 //             new Product { Id = 3, Sales = 22, PlatformId = 4 },
 //             new Product { Id = 4, Sales = 4, PlatformId = 5 },
 //             new Product { Id = 5, Sales = 141, PlatformId = 1 },
 //             new Product { Id = 6, Sales = 967, PlatformId = 6 }
 //           );

 //           modelBuilder.Entity<Videogame>().HasData(
 //              new Videogame { Id = 1, ProductId = 1, Name = "Elden Ring", Description = "Juego de rol y acción en mundo abierto", Price = 59.99m, Stock = 100, Discount = 0, ReleaseDate = new DateTime(2022, 2, 25), Pegi = 18, Developer = "FromSoftware", Distributor = "Bandai Namco", PrincipalImageURL = "https://upload.wikimedia.org/wikipedia/en/9/9c/Elden_Ring_Box_art.jpg", Requisitos1 = "Intel Core i5-8400 / AMD Ryzen 3 3300X", Requisitos2 = "12 GB RAM, GTX 1060 3GB / Radeon RX 580" },
 //              new Videogame { Id = 2, ProductId = 2, Name = "God of War Ragnarök", Description = "Acción y aventura con mitología nórdica", Price = 69.99m, Stock = 75, Discount = 5, ReleaseDate = new DateTime(2022, 11, 9), Pegi = 18, Developer = "Santa Monica Studio", Distributor = "Sony Interactive Entertainment", PrincipalImageURL = "https://upload.wikimedia.org/wikipedia/en/9/9e/God_of_War_Ragnar%C3%B6k_cover.jpg", Requisitos1 = null, Requisitos2 = null },
 //              new Videogame { Id = 3, ProductId = 3, Name = "Hogwarts Legacy", Description = "RPG ambientado en el mundo de Harry Potter", Price = 49.99m, Stock = 80, Discount = 10, ReleaseDate = new DateTime(2023, 2, 10), Pegi = 16, Developer = "Portkey Games", Distributor = "Warner Bros. Games", PrincipalImageURL = "https://upload.wikimedia.org/wikipedia/en/7/76/Hogwarts_Legacy_cover.jpg", Requisitos1 = "Intel Core i5-6600 / AMD Ryzen 5 1400", Requisitos2 = "16 GB RAM, GTX 1070 / RX Vega 56" }
 //           );

            // modelBuilder.Entity<Models.Console>().HasData(
            //    new Models.Console { Id = 1, Name = "Play Station 4", Specifications = "CPU:AMD 'Jaguar' x86-64, 8 núcleos; GPU: motor gráfico AMD de 1,84 TFLOPS basado en Radeon; Memoria:8 GB GDDR5; Almacenamiento:1 TB; Peso: Aprox. 2,1 Kg; Entrada/Salida:2 puertos de altísima velocidad USB (USB 3.1 Gen1) y 1 puerto AUX; Red:1 puerto Ethernet (10BASE-T, 100BASE-TX, 1000BASE-T) / IEEE 802.11 a/b/g/n/ac / Bluetooth® 4.0; Alimentacion:AC de 100-240 V, 50/60 Hz; Consumo de energia: 165W; Salida AV:Salida HDMI™ (compatible con salida HDR)", Price = 300, Stock = 16, PrincipalImageURL = "https://gmedia.playstation.com/is/image/SIEPDC/ps4-pro-product-thumbnail-01-en-14sep21", Brand = "Sony", Description = "Consola muy buena", Discount = 50, ProductId = 4, ReleaseDate = new DateTime(2023, 2, 10) },
            //    new Models.Console { Id = 2, Name = "Play Station 5", Specifications = "CPU: AMD Ryzen Zen 2, 8 núcleos a 3.5GHz; GPU: AMD RDNA 2, 10.28 TFLOPs, 36 CUs a 2.23GHz; Memoria: 16 GB GDDR6; Almacenamiento: SSD personalizado de 825 GB; Peso: Aprox. 4.5 Kg; Entrada/Salida: 2 puertos USB de alta velocidad (USB 3.1 Gen2), 1 puerto USB-C; Red: 1 puerto Ethernet (10BASE-T, 100BASE-TX, 1000BASE-T), Wi-Fi 6 (802.11ax), Bluetooth® 5.1; Alimentación: AC 100-240V, 50/60Hz; Consumo de energía: 350W; Salida AV: Salida HDMI™ 2.1 (compatible con 4K a 120Hz, 8K, y HDR)", Price = 490, Stock = 16, PrincipalImageURL = "https://m.media-amazon.com/images/I/51f6iZlNnvL.jpg", Brand = "Sony", Description = "Consola  buena", Discount = 10, ProductId = 5, ReleaseDate = new DateTime(2023, 2, 10) },
            //    new Models.Console { Id = 3, Name = "Xbox 360", Specifications = "CPU: IBM PowerPC Tri-Core Xenon a 3.2GHz; GPU: ATI Xenos, 240 GFLOPs; Memoria: 512 MB GDDR3 a 700 MHz; Almacenamiento: Disco duro de 20 GB/60 GB/120 GB (según modelo); Peso: Aprox. 3.5 Kg; Entrada/Salida: 3 puertos USB 2.0; Red: 1 puerto Ethernet (10/100), Wi-Fi opcional con adaptador externo (en modelos antiguos); Alimentación: AC 100-240V, 50/60Hz; Consumo de energía: Aprox. 175W; Salida AV: Salida HDMI™, Salida por componentes, Salida por cable AV estándar", Price = 265, Stock = 5, PrincipalImageURL = "https://i.ebayimg.com/images/g/oBUAAOSwVgljSZS8/s-l400.jpg", Brand = "Microsoft", Description = "Consola casi buena", Discount = 22, ProductId = 6, ReleaseDate = new DateTime(2023, 2, 10) }
            // );

            // modelBuilder.Entity<VideogameGender>().HasData(
            //    new VideogameGender { VideogameId = 1, GenderId =1 },
            //    new VideogameGender { VideogameId = 1, GenderId =2 },
            //    new VideogameGender { VideogameId = 2, GenderId =2 },
            //    new VideogameGender { VideogameId = 2, GenderId =3 },
            //    new VideogameGender { VideogameId = 3, GenderId =1 }
            // );


            // modelBuilder.Entity<Videogame>().HasData(
            //    new Videogame { Id = 1, Name = "Rocket League", Description = "Rocket League es un videojuego que combina fútbol con vehículos propulsados por cohetes, desarrollado por Psyonix. Los jugadores controlan autos que pueden saltar y volar brevemente para golpear un balón gigante e intentar marcar goles en la portería del equipo contrario. El juego cuenta con modos tanto en solitario como multijugador, tanto en línea como local, y ofrece partidas competitivas y casuales. Con su jugabilidad rápida, mecánicas simples pero desafiantes, y una comunidad activa, Rocket League se ha convertido en un fenómeno popular en el mundo de los eSports y el gaming casual.", Stock = 3, Pegi = 12, Available = true, Price = 15, PrincipalImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co5w0w.webp", Requisitos1 = "Windows 7; Intel Core 2 Duo E4600; 2 GB RAM; NVIDIA GeForce 8800; 7 GB disponibles; 11", Requisitos2 = "OS: Windows 10; Procesador: Intel Core i5-2550K; Memoria: 4 GB RAM; Gráfica: NVIDIA GeForce GTX 660; Almacenamiento: 7 GB disponibles; DirectX: 11", UserId = 1, PlatformId = 1, GenderId = 1, Code = "code1" },
            //    new Videogame { Id = 2, Name = "GTA 5", Description = "Grand Theft Auto V (GTA 5) es un juego de acción y aventura en mundo abierto desarrollado por Rockstar Games, ambientado en la ciudad ficticia de Los Santos, basada en Los Ángeles. La historia sigue a tres personajes: Michael, un ex ladrón de bancos; Franklin, un joven ambicioso; y Trevor, un ex compañero de Michael con tendencias violentas. Juntos realizan una serie de atracos mientras enfrentan problemas con el gobierno y pandillas. El juego ofrece libertad para explorar, realizar misiones, y participar en actividades variadas, además de contar con un modo en línea multijugador llamado GTA Online.", Stock = 7, Pegi = 18, Available = true, Price = 13, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1twh.webp", Requisitos1 = "Windows 7; Procesador: Intel Core 2 Quad CPU Q6600; Memoria: 4 GB RAM; Gráfica: NVIDIA 9800 GT; Almacenamiento: 72 GB disponibles; DirectX: 11", Requisitos2 = "OS: Windows 10; Procesador: Intel Core i5 3470; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 660 2GB; Almacenamiento: 72 GB disponibles; DirectX: 11",UserId = 1, PlatformId = 2, GenderId = 2, Code = "code2" },
            //    new Videogame { Id = 3, Name = "The Witcher 3", Description = "The Witcher 3: Wild Hunt es un juego de rol de acción desarrollado por CD Projekt Red, basado en las novelas de Andrzej Sapkowski. Los jugadores asumen el papel de Geralt de Rivia, un cazador de monstruos conocido como brujo, mientras recorre un vasto mundo abierto lleno de misiones, criaturas, y personajes complejos. La historia principal sigue a Geralt en su búsqueda por encontrar a su hija adoptiva, Ciri, mientras el continente está envuelto en conflictos políticos y la amenaza de la mítica Cacería Salvaje. Con su narrativa profunda, sistema de combate dinámico, y un mundo detallado lleno de decisiones morales, The Witcher 3 es considerado uno de los mejores videojuegos de todos los tiempos.", Stock = 5, Pegi = 18, Available = true, Price = 20, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2lgo.webp", Requisitos1 = "Windows 7; Procesador: Intel Core i5-2500K; Memoria: 6 GB RAM; Gráfica: NVIDIA GeForce GTX 660; Almacenamiento: 35 GB disponibles; DirectX: 11", Requisitos2 = "OS: Windows 10; Procesador: Intel Core i7 3770; Memoria: 8 GB RAM; Gráfica: NVIDIA GeForce GTX 770; Almacenamiento: 35 GB disponibles; DirectX: 12",UserId = 2, PlatformId = 3, GenderId = 3, Code = "code3" },
            //    new Videogame { Id = 4, Name = "Minecraft", Description = "Minecraft es un videojuego de construcción y supervivencia desarrollado por Mojang Studios. En un mundo abierto y generado de manera procedural, los jugadores pueden recolectar recursos, construir estructuras, explorar cuevas y combatir criaturas mientras gestionan su supervivencia. El juego cuenta con varios modos, como el modo supervivencia, donde los jugadores deben gestionar su salud y hambre, y el modo creativo, que ofrece recursos ilimitados para la construcción libre. Con su estilo gráfico de bloques y su libertad casi infinita para crear, Minecraft se ha convertido en uno de los juegos más influyentes y vendidos de todos los tiempos, con una gran comunidad y mods que amplían su jugabilidad.", Stock = 10, Pegi = 7, Available = true, Price = 25, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2b4k.webp", Requisitos1 = "Windows 7; Procesador: Intel Core i3-3210; Memoria: 4 GB RAM; Gráfica: Intel HD Graphics 4000; Almacenamiento: 1 GB disponibles; DirectX: 11", Requisitos2 = "OS: Windows 10; Procesador: Intel Core i5-4690; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 960; Almacenamiento: 4 GB disponibles; DirectX: 12",UserId = 3, PlatformId = 1, GenderId = 4, Code = "code4" },
            //    new Videogame { Id = 5, Name = "Fortnite", Description = "Fortnite es un videojuego multijugador en línea desarrollado por Epic Games, conocido principalmente por su modo Battle Royale, donde 100 jugadores compiten en una isla para ser el último en pie. Los jugadores deben recolectar armas, materiales para construir estructuras, y sobrevivir a una tormenta que reduce el área jugable. Con su jugabilidad rápida, gráficos coloridos, y la capacidad de construir estructuras defensivas durante los combates, Fortnite ha ganado una enorme popularidad a nivel mundial. El juego también cuenta con otros modos, como Salva el Mundo (un modo cooperativo) y Creativo, donde los jugadores pueden diseñar sus propios mundos.", Stock = 8, Pegi = 12, Available = true, Price = 0, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2ekt.webp", Requisitos1 = "OS: Windows 7; Procesador: Intel Core i3-3225; Memoria: 4 GB RAM; Gráfica: Intel HD 4000; Almacenamiento: 15 GB disponibles; DirectX: 11", Requisitos2 = "OS: Windows 10; Procesador: Intel Core i5-7300U; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 960; Almacenamiento: 15 GB disponibles; DirectX: 12", UserId = 2, PlatformId = 2, GenderId = 5, Code = "code5" },
            //    new Videogame { Id = 6, Name = "Overwatch", Description = "Overwatch es un juego de disparos en primera persona basado en equipos, desarrollado por Blizzard Entertainment. En el juego, los jugadores eligen entre una amplia gama de personajes, conocidos como héroes, cada uno con habilidades únicas y roles específicos dentro del equipo (daño, tanque, o apoyo). Los equipos de seis jugadores compiten en diversos modos de juego que incluyen capturar objetivos o escoltar cargas a lo largo de mapas detallados. Overwatch destaca por su enfoque en el trabajo en equipo, su jugabilidad rápida y accesible, y su elenco diverso de personajes, lo que lo ha convertido en uno de los títulos más populares en el ámbito de los eSports y los juegos multijugador.", Stock = 6, Pegi = 12, Available = true, Price = 30, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co7v86.webp", Requisitos1 = "Windows 7; Procesador: Intel Core i3; Memoria: 4 GB RAM; Gráfica: NVIDIA GeForce GTX 460; Almacenamiento: 30 GB disponibles; DirectX: 11", Requisitos2 = "OS: Windows 10; Procesador: Intel Core i5; Memoria: 6 GB RAM; Gráfica: NVIDIA GeForce GTX 660; Almacenamiento: 30 GB disponibles; DirectX: 12",UserId = 1, PlatformId = 3, GenderId = 1, Code = "code6" },
            //    new Videogame { Id = 7, Name = "FIFA 21", Description = "FIFA 21 es un simulador de fútbol desarrollado por EA Sports, parte de la popular franquicia FIFA. El juego ofrece modos de juego variados, desde partidos rápidos hasta competiciones completas, incluyendo FIFA Ultimate Team (FUT), donde los jugadores pueden crear y gestionar su propio equipo con cartas de futbolistas reales, y el Modo Carrera, que permite dirigir un equipo o un jugador a lo largo de varias temporadas. Con mejoras en la jugabilidad, gráficos realistas y una amplia lista de equipos y ligas con licencias oficiales, FIFA 21 busca ofrecer una experiencia auténtica de fútbol tanto en modos en solitario como en multijugador en línea.", Stock = 12, Pegi = 3, Available = true, Price = 50, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co3wm2.webp", Requisitos1 = "OS: Windows 7; Procesador: Intel Core i3-6100; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 660; Almacenamiento: 50 GB disponibles; DirectX: 11", Requisitos2 = "OS: Windows 10; Procesador: Intel i5-3550; Memoria: 8 GB RAM; Gráfica: NVIDIA GeForce GTX 670; Almacenamiento: 50 GB disponibles; DirectX: 12",UserId = 2, PlatformId = 1, GenderId = 2, Code = "code7" },
            //    new Videogame { Id = 8, Name = "Cyberpunk 2077", Description = "Cyberpunk 2077 es un juego de rol de acción desarrollado por CD Projekt Red, ambientado en un futuro distópico en la metrópolis de Night City. Los jugadores controlan a V, un mercenario personalizable que puede mejorar sus habilidades con implantes cibernéticos, mientras navega por un mundo abierto lleno de corporaciones corruptas, bandas criminales y tecnología avanzada. El juego ofrece una narrativa profunda con decisiones que impactan la historia, un sistema de combate variado que incluye armas de fuego y habilidades cuerpo a cuerpo, y una rica personalización de personajes. A pesar de su lanzamiento inicial con algunos problemas técnicos, Cyberpunk 2077 ha sido elogiado por su inmersivo diseño de mundo, historia y libertad de juego.", Stock = 4, Pegi = 18, Available = true, Price = 60, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co64re.webp", Requisitos1 = "Windows 7; Procesador: Intel Core i5-3570K; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 780; Almacenamiento: 70 GB disponibles; DirectX: 11", Requisitos2 = "OS: Windows 10; Procesador: Intel Core i7-4790; Memoria: 12 GB RAM; Gráfica: NVIDIA RTX 2060; Almacenamiento: 70 GB disponibles; DirectX: 12",UserId = 3, PlatformId = 2, GenderId = 3, Code = "code8" },
            //    new Videogame { Id = 9, Name = "Red Dead Redemption 2", Description = "Red Dead Redemption 2 es un juego de acción y aventura desarrollado por Rockstar Games, ambientado en el salvaje oeste de Estados Unidos a finales del siglo XIX. Los jugadores asumen el papel de Arthur Morgan, un forajido miembro de la banda de Dutch van der Linde, mientras lucha por sobrevivir en un mundo cambiante donde la ley y el orden están comenzando a imponerse. El juego ofrece un vasto mundo abierto con una atención meticulosa a los detalles, permitiendo a los jugadores cazar, pescar, interactuar con personajes y tomar decisiones que afectan la narrativa. Con su trama profunda, personajes complejos y una jugabilidad inmersiva, Red Dead Redemption 2 ha sido aclamado como uno de los mejores videojuegos de todos los tiempos.", Stock = 9, Pegi = 18, Available = true, Price = 40, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1q1f.webp", Requisitos1 = "Windows 7; Procesador: Intel Core i5-2500K; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 770; Almacenamiento: 150 GB disponibles; DirectX: 11", Requisitos2 = "OS: Windows 10; Procesador: Intel Core i7-4770K; Memoria: 12 GB RAM; Gráfica: NVIDIA RTX 2060; Almacenamiento: 150 GB disponibles; DirectX: 12",UserId = 3, PlatformId = 3, GenderId = 4, Code = "code9" },
            //    new Videogame { Id = 10, Name = "Assassin's Creed Valhalla", Description = "Assassin's Creed Valhalla es un juego de acción y rol desarrollado por Ubisoft, ambientado en la época vikinga, específicamente durante la invasión de Inglaterra en el siglo IX. Los jugadores controlan a Eivor, un guerrero vikingo que lidera a su clan en busca de un nuevo hogar en tierras inglesas, mientras lidia con la lucha entre asesinos y templarios. El juego combina exploración en un vasto mundo abierto, combates brutales, y la posibilidad de desarrollar asentamientos. Con un enfoque en la personalización de personajes, combate táctico y narrativas basadas en elecciones, Assassin's Creed Valhalla ofrece una experiencia inmersiva de la vida vikinga y sus incursiones.", Stock = 7, Pegi = 18, Available = true, Price = 55, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rrw.webp", Requisitos1 = "OS: Windows 7; Procesador: Intel Core i5-4460; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 960; Almacenamiento: 50 GB disponibles; DirectX: 11", Requisitos2 = "OS: Windows 10; Procesador: Intel Core i7-6700; Memoria: 12 GB RAM; Gráfica: NVIDIA RTX 2060; Almacenamiento: 50 GB disponibles; DirectX: 12",UserId = 1, PlatformId = 4, GenderId = 5, Code = "code10" },
            //    new Videogame { Id = 11, Name = "Call of Duty: Modern Warfare", Description = "Call of Duty: Modern Warfare es un juego de disparos en primera persona desarrollado por Infinity Ward y publicado por Activision. Lanzado en 2019, es una reinvención del sub-franquicia Modern Warfare, y ofrece una campaña centrada en conflictos militares modernos y operaciones encubiertas en el Medio Oriente y Europa. Los jugadores asumen el rol de personajes como Captain Price y un equipo de soldados de élite que luchan contra grupos terroristas y fuerzas enemigas. Además de su intensa campaña, el juego incluye modos multijugador competitivos y el popular modo Warzone, que introduce el formato battle royale. Con gráficos realistas, jugabilidad táctica y un enfoque en la narrativa cruda y madura, Modern Warfare ha sido aclamado tanto por su campaña como por su multijugador.", Stock = 11, Pegi = 18, Available = true, Price = 50, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1rsg.webp", Requisitos1 = "Windows 7; Procesador: Intel Core i3-4340; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 670; Almacenamiento: 175 GB disponibles; DirectX: 11", Requisitos2 = "OS: Windows 10; Procesador: Intel Core i7-6700; Memoria: 12 GB RAM; Gráfica: NVIDIA RTX 2070; Almacenamiento: 175 GB disponibles; DirectX: 12",UserId = 1, PlatformId = 4, GenderId = 1, Code = "code11" },
            //    new Videogame { Id = 12, Name = "Horizon Zero Dawn", Description = "Horizon Zero Dawn es un juego de rol y acción desarrollado por Guerrilla Games. Ambientado en un futuro postapocalíptico donde las máquinas dominan la Tierra, los jugadores controlan a Aloy, una joven cazadora en busca de respuestas sobre su origen y el mundo que la rodea. La historia sigue a Aloy mientras explora vastos paisajes abiertos, lucha contra criaturas robóticas, y descubre los secretos de una civilización perdida. El juego combina combate estratégico, donde los jugadores deben usar trampas, armas y habilidades para derrotar a las máquinas, con una narrativa profunda y visualmente impresionante. Horizon Zero Dawn ha sido elogiado por su mundo inmersivo, mecánicas de combate innovadoras y la protagonista carismática.", Stock = 5, Pegi = 16, Available = true, Price = 35, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co2una.webp", Requisitos1 = "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO", Requisitos2 = "RTX 3060;MUCHAS COSAS MAS; LAS TERCERA COSA; Y UNA DE REGALO",UserId = 2, PlatformId = 4, GenderId = 2, Code = "code12" },
            //    new Videogame { Id = 13, Name = "Stardew Valley", Description = "Stardew Valley es un juego de simulación de granja desarrollado por ConcernedApe. Los jugadores asumen el papel de un personaje que hereda una granja en mal estado y deben restaurarla plantando cultivos, criando animales, pescando, y explorando minas en busca de recursos. Además de las actividades agrícolas, el juego incluye elementos de interacción social con los habitantes de la cercana Pelican Town, lo que permite a los jugadores formar amistades e incluso casarse. Con su estilo retro pixelado, jugabilidad relajante y libertad para gestionar la granja a su propio ritmo, Stardew Valley se ha convertido en un juego indie muy popular por su encanto, profundidad y capacidad de personalización.", Stock = 8, Pegi = 7, Available = true, Price = 20, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/xrpmydnu9rpxvxfjkiu7.webp", Requisitos1 = "OS: Windows 7; Procesador: Intel Core i5-2500K; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 780; Almacenamiento: 100 GB disponibles; DirectX: 11", Requisitos2 = "OS: Windows 10; Procesador: Intel Core i7-4770K; Memoria: 16 GB RAM; Gráfica: NVIDIA RTX 2060; Almacenamiento: 100 GB disponibles; DirectX: 12",UserId = 2, PlatformId = 4, GenderId = 3, Code = "code13" },
            //    new Videogame { Id = 14, Name = "Among Us", Description = "Among Us es un juego multijugador en línea desarrollado por InnerSloth, en el que los jugadores deben trabajar juntos para completar tareas en una nave espacial, estación o base, mientras un grupo de impostores intenta sabotear la misión y eliminar a los demás jugadores. Los jugadores asumen uno de dos roles: tripulantes, que deben realizar tareas y descubrir a los impostores, o impostores, que deben sabotear y eliminar a los tripulantes sin ser descubiertos. Con su jugabilidad basada en la deducción social y las reuniones donde los jugadores discuten quién puede ser el impostor, Among Us se ha vuelto enormemente popular por su enfoque en la colaboración, traición y estrategia.", Stock = 15, Pegi = 10, Available = true, Price = 5, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co6kqt.webp", Requisitos1 = "OS: Windows 7; Procesador: Intel Pentium 4; Memoria: 1 GB RAM; Gráfica: NVIDIA GeForce 6100; Almacenamiento: 250 MB disponibles; DirectX: 11", Requisitos2 = "OS: Windows 10; Procesador: Intel Core i3-6100; Memoria: 2 GB RAM; Gráfica: NVIDIA GTX 660; Almacenamiento: 250 MB disponibles; DirectX: 12",UserId = 2, PlatformId = 1, GenderId = 4, Code = "code14" },
            //    new Videogame { Id = 15, Name = "The Legend of Zelda: Breath of the Wild", Description = "The Legend of Zelda: Breath of the Wild es un juego de acción y aventura desarrollado por Nintendo, ambientado en el vasto reino abierto de Hyrule. Los jugadores controlan a Link, quien despierta de un largo sueño para derrotar a Ganon, una antigua fuerza maligna que amenaza con destruir el reino. El juego destaca por su enfoque en la exploración, permitiendo a los jugadores escalar montañas, nadar, y planear a través del mundo mientras resuelven puzles, enfrentan enemigos y descubren secretos. Con un sistema de físicas realista, libertad sin precedentes en la serie, y una narrativa ambiental rica, Breath of the Wild es considerado uno de los mejores videojuegos de todos los tiempos por su innovación y profundidad.", Stock = 6, Pegi = 12, Available = true, Price = 60, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_small/co4n26.png", Requisitos1 = "OS: Windows 7; Procesador: Intel Core i5-2400S; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 750; Almacenamiento: 40 GB disponibles; DirectX: 11", Requisitos2 = "OS: Windows 10; Procesador: Intel Core i7-4790; Memoria: 12 GB RAM; Gráfica: NVIDIA RTX 2060; Almacenamiento: 40 GB disponibles; DirectX: 12",UserId = 3, PlatformId = 2, GenderId = 5, Code = "code15" },
            //    new Videogame { Id = 16, Name = "God of War", Description = "God of War es un juego de acción y aventura desarrollado por Santa Monica Studio y publicado por Sony Interactive Entertainment. Lanzado en 2018, es una reinvención de la serie y sigue a Kratos, el dios de la guerra, en una nueva etapa de su vida en la mitología nórdica. Acompañado por su hijo Atreus, Kratos debe enfrentarse a poderosos enemigos y criaturas míticas mientras lidia con sus propios demonios internos y enseña a su hijo a sobrevivir en un mundo hostil. El juego combina combates intensos con una narrativa emocional, explorando temas de paternidad, redención y autodescubrimiento. Con su innovador sistema de combate, impresionantes gráficos y un mundo abierto lleno de secretos, God of War ha sido aclamado como uno de los mejores videojuegos de la historia.", Stock = 6, Pegi = 12, Available = true, Price = 60, ImageURL = "https://images.igdb.com/igdb/image/upload/t_cover_big/co1tmu.webp", Requisitos1 = "OS: Windows 10 (64 bits); Procesador: Intel i5-2500K (3.3 GHz) o AMD Ryzen 3 1200; Memoria: 8 GB RAM; Gráfica: NVIDIA GTX 960 (4 GB) o AMD R9 290X (4 GB); Almacenamiento: 70 GB disponibles; DirectX: 11", Requisitos2 = "OS: Windows 10 (64 bits); Procesador: Intel i7-4770K (3.5 GHz) o AMD Ryzen 7 2700X; Memoria: 16 GB RAM; Gráfica: NVIDIA RTX 2060 (6 GB) o AMD RX 5700 XT (8 GB); Almacenamiento: 70 GB disponibles; DirectX: 12",UserId = 3, PlatformId = 2, GenderId = 5, Code = "code15" }
            // );


            //modelBuilder.Entity<Gender>().HasData(
            //   new Gender { GenderId = 1, Name = "RPG" },
            //   new Gender { GenderId = 2, Name = "Shooter" },
            //   new Gender { GenderId = 3, Name = "Estrategia" },
            //   new Gender { GenderId = 4, Name = "Accion" },
            //   new Gender { GenderId = 5, Name = "Deportes" }
            //);

            // 




        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Videogame> Videogames { get; set; }
        public DbSet<Models.Console> Consoles { get; set; }
        public DbSet<SecondHandProduct> SecondHandProducts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<VideogameGender> VideogameGenders { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }



    }
}
