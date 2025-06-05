using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using GamingCorner.Models.DTOs.ProductDTOs;

namespace GamingCorner.Models;

public class SecondHandProductDTO : ProductDTOBase
{
    public int ProductId { get; set; }
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
  
    /*
    public bool Available { get; set; }*/
    
    public decimal Price { get; set; }

    public ProductsImagesDto ProductImages { get; set; }

    public UserDTO User { get; set; }

    public bool IsChecked { get; set; }

    public SecondHandProduct ToProduct()
    {
        return new SecondHandProduct
        {
            Id = this.Id,
            ProductId = this.ProductId,
            Name = this.Name,
            Price = this.Price,
            Description = this.Description,
            //Available = this.Available,
            IsChecked = this.IsChecked,
            
        };
    }

    
}