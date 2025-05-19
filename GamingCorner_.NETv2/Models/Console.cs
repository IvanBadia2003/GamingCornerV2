using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Console
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public int Stock { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int Discount { get; set; }
    [Required]
    public DateTime ReleaseDate { get; set; }
    [Required]
    public string Specifications { get; set; }

    [Required]
    public string PrincipalImageURL { get; set; }

    public string Brand { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public Console() { }

    public Console(int id, string name, string description, int discount, DateTime releaseDate, string specifications, int stock, decimal price, string principalImageURL, string brand) 
    {
        Id = id;
        Name = name;
        Description = description;
        Discount = discount;
        ReleaseDate = releaseDate;
        Stock = stock;
        Price = price;
        Specifications = specifications;
        PrincipalImageURL = principalImageURL;
        Brand = brand;

    }

    public Console mapFromCreateDto(int productId, ConsoleCreateDTO consoleCreateDTO)
    {
        if (consoleCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(consoleCreateDTO));
        }

        return new Console(
            productId,
            consoleCreateDTO.Name,
            consoleCreateDTO.Description,
            consoleCreateDTO.Discount,
            consoleCreateDTO.ReleaseDate,
            consoleCreateDTO.Specifications,
            consoleCreateDTO.Stock,
            consoleCreateDTO.Price,
            consoleCreateDTO.PrincipalImageURL,
            consoleCreateDTO.Brand
            );

    }
}