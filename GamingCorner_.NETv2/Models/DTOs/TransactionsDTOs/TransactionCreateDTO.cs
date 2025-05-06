using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class TransactionCreateDTO
{
    [ForeignKey("User")]
    public int? UserId { get; set; }

    [ForeignKey("Product")]
    public int? ProductId { get; set; }
    
    [ForeignKey("Videogame")]
    public int? VideogameId { get; set; }
    
    [ForeignKey("Console_")]
    public int? ConsoleId { get; set; }

    public string? Type { get; set; }

}