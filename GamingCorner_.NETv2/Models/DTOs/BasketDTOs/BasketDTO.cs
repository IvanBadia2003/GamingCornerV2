using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;


public class BasketDTO
{
    public int UserId { get; set; }
    public ProductDTOBase Product { get; set; }
    
    public Basket ToBasket()
    {
        return new Basket
        {
            UserId = this.UserId,

        };
    }
}