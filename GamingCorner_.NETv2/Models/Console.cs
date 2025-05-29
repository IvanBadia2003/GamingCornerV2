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
    
    [Required]
    public string Generation { get; set; }
    
    [Required]
    public string Services{ get; set; }
    
    [Required]
    public string Colors{ get; set; }

    public string Brand { get; set; }


    [ForeignKey("Product")]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public Console() { }

    public Console(string name, string description, int discount, DateTime releaseDate, string specifications, int stock, decimal price, string? principalImageURL, string brand, string generation, string services, string colors)
    {
        Name = name;
        Description = description;
        Discount = discount;
        ReleaseDate = releaseDate;
        Stock = stock;
        Price = price;
        Specifications = specifications;
        PrincipalImageURL = principalImageURL;
        Brand = brand;
        Generation = generation;
        Services = services;
        Colors = colors;
    }

    public Console mapFromCreateDto(ConsoleCreateDTO dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        return new Console
        {
            Name = dto.Name,
            Description = dto.Description,
            Stock = dto.Stock,
            Price = dto.Price,
            Discount = dto.Discount,
            ReleaseDate = dto.ReleaseDate,
            Specifications = dto.Specifications,
            PrincipalImageURL = dto.PrincipalImageURL,
            Brand = dto.Brand,
            Colors = dto.Colors,
            Generation = dto.Generation,
            Services = dto.Services
        };
    }

    public ConsoleDTO mapToReadDto()
    {
        return new ConsoleDTO
        {
            Id = this.Id,
            Name = this.Name,
            Description = this.Description,
            Stock = this.Stock,
            Price = this.Price,
            Discount = this.Discount,
            ReleaseDate = this.ReleaseDate,
            Specifications = this.Specifications,
            PrincipalImageURL = this.PrincipalImageURL,
            Brand = this.Brand
        };
    }
}