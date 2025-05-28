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
    public Platform? Platform {  get; set; }
    public int? PlatformId {  get; set; }
    public Videogame? Videogame { get; set; }
    public Console? Console { get; set; }
    public SecondHandProduct? SecondHandProduct { get; set; }

    public Product(int? platformId = null, int? sales = 0, Videogame? videogame = null, Console? console = null, SecondHandProduct? secondHandProduct = null)
    {
        Sales = sales;
        PlatformId = platformId;
        Videogame = videogame;
        Console = console;
        SecondHandProduct = secondHandProduct;

    }

    public Product mapFromCreateDto(ProductDTOBase dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        return new Product(
            
            dto.Sales,
            dto.PlatformId

        );
    }
}


