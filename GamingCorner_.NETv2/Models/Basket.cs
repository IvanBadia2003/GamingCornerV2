using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Basket
{
    public User User { get; set; }
    public int UserId { get; set; }

    public Product Product { get; set; }
    public int ProductId { get; set; }
    public Basket() { }

    public Basket(int userId, int productId)
    {
        UserId = userId;
        ProductId = productId;
    }

    public Basket mapFromCreateDto(BasketCreateDTO basketCreateDTO)
    {
        if (basketCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(basketCreateDTO));
        }

        var basket = new Basket
        {
            UserId = basketCreateDTO.UserId,
            ProductId = basketCreateDTO.ProductId,
        };

        return basket;
    }
    public BasketDTO MapToBasketDTO()
    {
        return new BasketDTO
        {
            UserId = this.UserId,
        };
    }
}