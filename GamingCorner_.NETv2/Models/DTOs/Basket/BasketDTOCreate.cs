using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;


public class BasketCreateDTO
{    
    public int UserId { get; set; }
    public int ProductId { get; set; }
}