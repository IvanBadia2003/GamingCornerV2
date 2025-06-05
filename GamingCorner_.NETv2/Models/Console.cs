using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using GamingCorner.Models.DTOs.ProductDTOs;

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

    public Console(string name, string description, int discount, DateTime releaseDate, string specifications, int stock, decimal price, string brand, string generation, string services, string colors, int productId)
    {
        Name = name;
        Description = description;
        Discount = discount;
        ReleaseDate = releaseDate;
        Stock = stock;
        Price = price;
        Specifications = specifications;
        Brand = brand;
        Generation = generation;
        Services = services;
        Colors = colors;
        ProductId = productId;
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
            Brand = dto.Brand,
            Colors = dto.Colors,
            Generation = dto.Generation,
            Services = dto.Services,
            ProductId = dto.ProductId
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
            Brand = this.Brand,
            Colors = this.Colors,
            Generation = this.Generation,
            Services = this.Services,
            ProductId = this.ProductId,
            ProductImages = new ProductsImagesDto
            {
                Main = this.Product.MainImage,
                Background = this.Product.BackgroundImage,
                Content1 = this.Product.ContentImages1,
                Content2 = this.Product.ContentImages2,
                Content3 = this.Product.ContentImages3,
                Content4 = this.Product.ContentImages4,
            }
        };
    }
}