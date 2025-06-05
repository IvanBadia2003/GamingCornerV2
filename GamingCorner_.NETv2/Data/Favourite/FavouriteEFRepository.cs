namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;
using GamingCorner.Models.DTOs.ProductDTOs;

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
        try
        {
            favourite.DateAdd = DateTime.Now;
            _context.Favourites.Add(favourite);
            SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException?.Message.Contains("duplicate key") == true ||
                ex.InnerException?.Message.Contains("clave duplicada") == true)
            {
                // Aquí puedes lanzar una excepción más clara o simplemente ignorarlo
                throw new InvalidOperationException("Este producto ya lo tienes como favorito.");
            }

            // Si no es por clave duplicada, relanzamos la excepción original
            throw;
        }

    }

    public List<FavouriteDTO> Get(int idUser)
    {
        var favourites = _context.Favourites
    .Where(b => b.UserId == idUser)
    .Include(b => b.Product)
        .ThenInclude(p => p.Videogame)
    .Include(b => b.Product)
        .ThenInclude(p => p.Console)
    .Include(b => b.Product)
        .ThenInclude(pp => pp.Platform)
    .OrderByDescending(b => b.DateAdd) 
    .ToList();


        if (favourites == null || !favourites.Any())
            return new List<FavouriteDTO>();

        var favouritesDtos = favourites.Select(b => new FavouriteDTO
        {
            UserId = b.UserId,
            platformName = b.Product.Platform.Name,
            DateAdd = b.DateAdd,
            Product = new ProductDTOBase
            {
                Id = b.Product.Id,
                Sales = b.Product.Sales,
                PlatformId = b.Product.Platform.PlatformId,
                Name = b.Product.Videogame?.Name ?? b.Product.Console?.Name,
                Price = b.Product.Videogame?.Price ?? b.Product.Console.Price,
                Discount = b.Product.Videogame?.Discount ?? b.Product.Console.Discount,
                System = b.Product.Platform.System,
                ProductImages = new ProductsImagesDto
                {
                    Background = b.Product.BackgroundImage,
                    Content1 = b.Product.ContentImages1,
                    Content3 = b.Product.ContentImages3,
                    Content2 = b.Product.ContentImages2,
                    Content4 = b.Product.ContentImages4,
                    Main = b.Product.MainImage,
                }



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
        var favourite = _context.Favourites.FirstOrDefault(g => g.UserId == idUser && g.ProductId == idProduct);
        if (favourite == null)
        {
            throw new KeyNotFoundException("Favourite Product not found.");
        }
        if (favourite != null)
        {
            _context.Favourites.Remove(favourite);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}