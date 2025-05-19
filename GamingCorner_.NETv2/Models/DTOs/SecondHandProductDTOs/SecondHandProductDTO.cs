using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class SecondHandProductDTO
{
    public int ProductId { get; set; }
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
  
    /*
    public bool Available { get; set; }*/
    
    public decimal Price { get; set; }
        
    public string? ImageURL { get; set; }

    // public List<TransactionDTO> Transactions { get; set; } 

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
            ImageURL = this.ImageURL
        };
    }

    
}