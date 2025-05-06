using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class ProductCreateDTO
{


    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Description { get; set; }
    
    [Required]
    public bool Available { get; set; } = true;
    
    [Required]
    public decimal Price { get; set; }
    
    [Required]
    public string? ImageURL { get; set; }
 

}