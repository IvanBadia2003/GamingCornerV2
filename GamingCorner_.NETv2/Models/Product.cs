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

    public int? Sales {  get; set; }
    public int? PlatformId { get; set; }
    public Platform? Platform {  get; set; }
    public Videogame? Videogame { get; set; }
    public Console? Console { get; set; }
    public SecondHandProduct? SecondHandProduct { get; set; }
    public List<Basket> Baskets { get; set; } = new List<Basket>();
    public List<Favourite> Favourites { get; set; } = new List<Favourite>();

    public Product() { }

    public Product(Platform? platform = null, int? sales = 0, Videogame? videogame = null, Console? console = null, SecondHandProduct? secondHandProduct = null)
    {
        Sales = sales;
        Platform = platform;
        Videogame = videogame;
        Console = console;
        SecondHandProduct = secondHandProduct;

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


