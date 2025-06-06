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
    public SecondHandProduct(string name, string description, bool isChecked, decimal price, DateTime releaseDate, int userId)
    {
        Name = name;
        Description = description;
        ReleaseDate = releaseDate;
        Price = price;
        IsChecked = isChecked;
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
            Name = Name,
            Price = Price,
            ProductId = ProductId,
            IsChecked = IsChecked,
            User = User.ToUserDTO(),
            ProductImages = new DTOs.ProductDTOs.ProductsImagesDto
            {
                Content1 = this.Product.ContentImages1,
                Content3 = this.Product.ContentImages3,
                Content2 = this.Product.ContentImages2,
                Content4 = this.Product.ContentImages4,
                Main = this.Product.MainImage,
            }
            
        };
    }

}