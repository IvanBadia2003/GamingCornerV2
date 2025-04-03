using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class TransactionDTO
{
    [Required]
    public int TransactionId { get; set; }

    [Required]
    public int? UserId { get; set; }
    
    [Required]
    public int? ProductId { get; set; }
    
    [Required]
    public int? VideogameId { get; set; }
    
    [Required]
    public int? ConsoleId { get; set; }
    
    [Required]
    public string Type { get; set; }
    
    [Required]
    public DateTime? Date { get; set; }

}