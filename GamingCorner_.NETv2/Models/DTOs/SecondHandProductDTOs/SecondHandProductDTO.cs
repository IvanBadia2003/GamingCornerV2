using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class SecondHandProductDTO
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Description { get; set; }
  
    [Required]
    public bool Available { get; set; }
    
    [Required]
    public decimal Price { get; set; }
        
    [Required]
    public string? ImageURL { get; set; }
 
    // public List<TransactionDTO> Transactions { get; set; } 

     public SecondHandProduct ToProduct()
    {
        return new SecondHandProduct
        {
            Id = this.ProductId,
            Name = this.Name,
            Price = this.Price,
            Description = this.Description,
            //Available = this.Available,
            //ImageURL = this.ImageURL
        };
    }

    
}