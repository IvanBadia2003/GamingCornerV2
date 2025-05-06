using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class ConsoleDTO
{
    [Key]
    public int ConsoleId { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Specifications { get; set; }

    [Required]
    public int Stock { get; set; }
    
    [Required]
    public int PlatformId { get; set; }

    [Required]
    public bool Available { get; set; }
  
    [Required]
    public decimal Price { get; set; }
        
    [Required]
    public string? ImageURL { get; set; }

    // public List<ConsoleDTO> Consoles { get; set; }Ç
 

     public Console_ ToConsole()
    {
        return new Console_
        {
            ConsoleId = this.ConsoleId,
            Name = this.Name,
            Specifications = this.Specifications,
            PlatformId = this.PlatformId,
            Stock = this.Stock,
            Available = this.Available,
            Price = this.Price,
            ImageURL = this.ImageURL
        };
    }
}