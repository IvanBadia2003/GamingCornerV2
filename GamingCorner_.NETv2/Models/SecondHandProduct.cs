using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class SecondHandProduct
{
    //[Key, ForeignKey("Product")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public DateTime ReleaseDate { get; set; }

    [Required]
    public bool IsChecked { get; set; }

    [Required]
    public string? ImageURL { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [ForeignKey("User")]

    public int UserId { get; set; }
    public User User { get; set; }

    // public List<VideogameGender> ListVideogameGender { get; set; }
    //public List<Transaction> Transactions { get; set; }


    public SecondHandProduct() { }

    //public SecondHandProduct(int id, string name, string description, bool isChecked, decimal price, int stock, int discount, DateTime releaseDate)
    public SecondHandProduct(string name, string description, bool isChecked, decimal price, string imageURL, DateTime releaseDate, int userId)
    {
        Name = name;
        Description = description;
        ReleaseDate = releaseDate;
        Price = price;
        IsChecked = isChecked;
        ImageURL = imageURL;
        UserId = userId;
    }

    //public SecondHandProduct mapFromCreateDto(int productId, SecondHandProductCreateDTO productCreateDTO)
    public SecondHandProduct mapFromCreateDto(SecondHandProductCreateDTO productCreateDTO)
    {
        if (productCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(productCreateDTO));
        }

        return new SecondHandProduct(
            productCreateDTO.Name,
            productCreateDTO.Description,
            IsChecked = false,
            productCreateDTO.Price,
            productCreateDTO.ImageURL,
            productCreateDTO.ReleaseDate,
            productCreateDTO.UserId

        );        
    }

    public SecondHandProductDTO ToSecondHandProductDTO()
    {
        return new SecondHandProductDTO
        {
            Description = Description,
            Id = Id,
            ImageURL = ImageURL,
            Name = Name,
            Price = Price,
            ProductId = ProductId,
            User = User.ToUserDTO(),
        };
    }

}