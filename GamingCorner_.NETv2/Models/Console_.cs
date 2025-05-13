using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Console_
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ConsoleId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int PlatformId { get; set; }

    public Platform Platform { get; set; }

    // [Required]
    // public int? UserId { get; set; }

    // public User User { get; set; }


    [Required]
    public string Specifications { get; set; }

    [Required]
    public int Stock { get; set; }

    [Required]
    public bool Available { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public string ImageURL { get; set; }

    //public List<Transaction> Transactions { get; set; }


    public Console_() { }

    public Console_(string name, string specifications, int stock, bool available, decimal price, string imageURL, int platformId)
    {
        Name = name;
        Specifications = specifications;
        PlatformId = platformId;
        Stock = stock;
        Available = available;
        Price = price;
        ImageURL = imageURL;
    }

    public Console_ mapFromCreateDto(ConsoleCreateDTO consoleCreateDTO)
    {
        if (consoleCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(consoleCreateDTO));
        }

        var console = new Console_
        {
            Name = consoleCreateDTO.Name,
            Specifications = consoleCreateDTO.Specifications,
            PlatformId = consoleCreateDTO.PlatformId,
            Stock = consoleCreateDTO.Stock,
            Available = consoleCreateDTO.Available,
            Price = consoleCreateDTO.Price,
            ImageURL = consoleCreateDTO.ImageURL
        };

        return console;
    }
}