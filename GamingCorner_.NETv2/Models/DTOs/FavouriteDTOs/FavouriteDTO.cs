using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;


public class FavouriteDTO
{
    public int UserId { get; set; }
    public ProductDTOBase Product { get; set; }
    
    public Favourite ToBasket()
    {
        return new Favourite
        {
            UserId = this.UserId,
        };
    }
}