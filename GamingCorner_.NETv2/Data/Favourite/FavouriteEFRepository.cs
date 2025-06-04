namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;

public class FavouriteEFRepository : IFavouriteRepository
{


    private readonly GamingCornerContext _context;

    public FavouriteEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<FavouriteDTO> GetAll()
    {
        var favourites = _context.Favourites
            .ToList();

        if (favourites != null)
        {
            var favouriteDto = favourites.Select(g => new FavouriteDTO
            {
                UserId = g.UserId,
            }).ToList();
            return favouriteDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(Favourite favourite)
    {
        _context.Favourites.Add(favourite);
        SaveChanges();
    }

  public List<FavouriteDTO> Get(int idUser)
{
    var favourites = _context.Favourites
        .Where(b => b.UserId == idUser)
        .Include(b => b.Product)
            .ThenInclude(p => p.Videogame)
        .Include(b => b.Product)
            .ThenInclude(p => p.Console)
        .Include(p => p.Product)
            .ThenInclude(pp => pp.Platform)
        .ToList();

    if (favourites == null || !favourites.Any())
        return new List<FavouriteDTO>();

    var favouritesDtos = favourites.Select(b => new FavouriteDTO
    {
        UserId = b.UserId,
        Product = new ProductDTOBase
        {
            Id = b.Product.Id,
            Sales = b.Product.Sales,
            PlatformId = b.Product.Platform.PlatformId,
            Name = b.Product.Videogame?.Name ?? b.Product.Console?.Name,
            Price = b.Product.Videogame?.Price ?? b.Product.Console?.Price,
            Discount = b.Product.Videogame?.Discount ?? b.Product.Console?.Discount,
            PrincipalImageURL = b.Product.Videogame?.PrincipalImageURL ?? b.Product.Console?.PrincipalImageURL,
            System = b.Product.Platform.System,

        }
    }).ToList();

    return favouritesDtos;
}






    /// <summary>
    /// Obtener los generos de un juego
    /// </summary>
    /// <param name="idVideogame"></param>
    /// <returns></returns>
    // public List<VideogameGender> GetGendersByVideogameId(int idVideogame)
    // {
    //     var videogameGenders = _context.VideogameGenders
    //         .Where(vg => vg.VideogameId == idVideogame)
    //         .ToList();

    //     return videogameGenders;
    // }


    // public void Update(Gender gender)
    // {
    //     var existingGender = _context.Genders.Find(gender.GenderId);

    //     if (existingGender != null)
    //     {
    //         _context.Entry(existingGender).CurrentValues.SetValues(gender);
    //         _context.SaveChanges();
    //     }
    // }

    public void Delete(int idUser, int idProduct)
    {
        var favouriteDto = Get(idUser);
        if (favouriteDto == null)
        {
            throw new KeyNotFoundException("Favourite Product not found.");
        }
        var favourite = _context.Baskets.FirstOrDefault(g => g.UserId == idUser && g.ProductId == idProduct) ;
        if (favourite != null)
        {
            _context.Baskets.Remove(favourite);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}