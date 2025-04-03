using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public bool Available { get; set; }

    [Required]
    public string ImageURL { get; set; }

    // public List<VideogameGender> ListVideogameGender { get; set; }
    public List<Transaction> Transactions { get; set; }


    public Product() { }

    public Product(string name, string description, bool available, decimal price, string imageURL)
    {
        Name = name;
        Description = description;
        Available = available;
        Price = price;
        ImageURL = imageURL;
    }

    public Product mapFromCreateDto(ProductCreateDTO productCreateDTO)
    {
        if (productCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(productCreateDTO));
        }

        var product = new Product
        {
            Name = productCreateDTO.Name,
            Description = productCreateDTO.Description,
            Available = productCreateDTO.Available,
            Price = productCreateDTO.Price,
            ImageURL = productCreateDTO.ImageURL
        };

        return product;
    }

}