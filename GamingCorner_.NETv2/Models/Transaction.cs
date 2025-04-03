using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Transaction
{
    [Key]
    public int TransactionId { get; set; }
    
    [ForeignKey("User")]
    public int? UserId { get; set; }
    public User? User { get; set; }
    
    [ForeignKey("Product")]
    public int? ProductId { get; set; }
    public Product? Product { get; set; }
    
    [ForeignKey("Videogame")]
    public int? VideogameId { get; set; }
    public Videogame? Videogame { get; set; }
    
    [ForeignKey("Console_")]
    public int? ConsoleId { get; set; }
    public Console_? Console { get; set; }
    
    public string Type { get; set; } // Compra o venta
    public DateTime? Date { get; set; }

    // public List<VideogameGender> ListVideogameGender { get; set; }

    public Transaction() { }

    public Transaction(int? userId, int? productId, int? videogameId, int? consoleId, string? type, DateTime? date)
    {
        UserId = userId;
        ProductId = productId;
        VideogameId = videogameId;
        ConsoleId = consoleId;
        Type = type;
        Date = date;
    }


    public Transaction mapFromCreateDto(TransactionCreateDTO transactionCreateDTO)
    {
        if (transactionCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(transactionCreateDTO));
        }

        var transaction = new Transaction
        {
           UserId = transactionCreateDTO.UserId,
           ProductId = transactionCreateDTO.ProductId,
           VideogameId = transactionCreateDTO.VideogameId,
           ConsoleId = transactionCreateDTO.ConsoleId,
        };

        return transaction;
    }
}