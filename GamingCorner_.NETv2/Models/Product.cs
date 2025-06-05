using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int Sales {  get; set; }
    public int? PlatformId { get; set; }
    public Platform? Platform {  get; set; }
    public Videogame? Videogame { get; set; }
    public Console? Console { get; set; }
    public SecondHandProduct? SecondHandProduct { get; set; }

    public string? MainImage  { get; set; }
    public string? BackgroundImage { get; set; }
    public string? ContentImages1 { get; set; }
    public string? ContentImages2 { get; set; }
    public string? ContentImages3 { get; set; }
    public string? ContentImages4 { get; set; }

    public List<Basket> Baskets { get; set; } = new List<Basket>();
    public List<Favourite> Favourites { get; set; } = new List<Favourite>();
    public List<Review> Reviews { get; set; } = new List<Review>();
    public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();


    public Product() { }

    public Product(Platform? platform = null, int sales = 0, Videogame? videogame = null, Console? console = null, SecondHandProduct? secondHandProduct = null, string? mainImage = null, string? backgroundImage = null, string? contentImages1 = null, string? contentImages2 = null, string? contentImages3 = null, string? contentImages4 = null)
    {
        Sales = sales;
        Platform = platform;
        Videogame = videogame;
        Console = console;
        SecondHandProduct = secondHandProduct;
        MainImage = mainImage;
        BackgroundImage = backgroundImage;
        ContentImages1 = contentImages1;
        ContentImages2 = contentImages2;
        ContentImages3 = contentImages3;
        ContentImages4 = contentImages4;
        

    }

    public Product mapFromCreateDto(ProductDTOBase dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        return new Product(
            
            dto.Platform,
            dto.Sales

        );
    }
}


