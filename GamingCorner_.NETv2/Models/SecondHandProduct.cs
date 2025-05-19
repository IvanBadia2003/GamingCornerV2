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

    // public List<VideogameGender> ListVideogameGender { get; set; }
    //public List<Transaction> Transactions { get; set; }


    public SecondHandProduct() { }

    //public SecondHandProduct(int id, string name, string description, bool isChecked, decimal price, string principalImageURL, int stock, int discount, DateTime releaseDate)
    public SecondHandProduct(string name, string description, bool isChecked, decimal price, string? imageURL, DateTime releaseDate)
    {
        //Id = id;
        Name = name;
        Description = description;
        //Discount = discount;
        ReleaseDate = releaseDate;
        //Stock = stock;
        //Available = available;
        Price = price;
        IsChecked = isChecked;
        ImageURL = imageURL;
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
            //productId,
            productCreateDTO.Name,
            productCreateDTO.Description,
            productCreateDTO.isChecked,
            productCreateDTO.Price,
            //productCreateDTO.Available,
            productCreateDTO.ImageURL,
            //productCreateDTO.Stock,
            //productCreateDTO.Discount,
            productCreateDTO.ReleaseDate
        );        
    }
}