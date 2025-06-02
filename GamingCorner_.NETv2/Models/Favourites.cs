using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Favourite
{
    public User User { get; set; }
    public int UserId { get; set; }

    public Product Product { get; set; }
    public int ProductId { get; set; }
    public Favourite() { }

    public Favourite(int userId, int productId)
    {
        UserId = userId;
        ProductId = productId;
    }

    public Favourite mapFromCreateDto(FavouriteCreateDTO favouriteCreateDTO)
    {
        if (favouriteCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(favouriteCreateDTO));
        }

        var favourite = new Favourite
        {
            UserId = favouriteCreateDTO.UserId,
            ProductId = favouriteCreateDTO.ProductId,
        };

        return favourite;
    }
    public FavouriteDTO MapToFavouriteDTO()
    {
        return new FavouriteDTO
        {
            UserId = this.UserId,
        };
    }
}