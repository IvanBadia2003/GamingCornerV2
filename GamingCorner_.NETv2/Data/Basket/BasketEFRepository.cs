namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;

public class BasketEFRepository : IBasketRepository
{


    private readonly GamingCornerContext _context;

    public BasketEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<BasketDTO> GetAll()
    {
        var baskets = _context.Baskets
            .ToList();

        if (baskets != null)
        {
            var basketDto = baskets.Select(g => new BasketDTO
            {
                UserId = g.UserId,
            }).ToList();
            return basketDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(Basket basket)
    {
        try
        {
            _context.Baskets.Add(basket);
            SaveChanges();
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException?.Message.Contains("duplicate key") == true ||
                ex.InnerException?.Message.Contains("clave duplicada") == true)
            {
                // Aquí puedes lanzar una excepción más clara o simplemente ignorarlo
                throw new InvalidOperationException("Este producto ya está en el carrito del usuario.");
            }

            // Si no es por clave duplicada, relanzamos la excepción original
            throw;
        }
    }


    public List<BasketDTO> Get(int idUser)
    {
        var baskets = _context.Baskets
            .Where(b => b.UserId == idUser)
            .Include(b => b.Product)
            .Include(b => b.Product)
                .ThenInclude(p => p.Videogame)
            .Include(b => b.Product)
                .ThenInclude(p => p.Console)
            .Include(p => p.Product)
                .ThenInclude(pp => pp.Platform)
            .ToList();

        if (baskets == null || !baskets.Any())
            return new List<BasketDTO>();


        var basketDtos = baskets.Select(b => new BasketDTO
        {
            UserId = b.UserId,
            Product = new ProductDTOBase
            {
                Id = b.Product.Id,
                Sales = b.Product.Sales,
                PlatformId = b.Product.Platform.PlatformId,
                Name = b.Product.Videogame?.Name ?? b.Product.Console?.Name,
                Price = b.Product.Videogame?.Price ?? b.Product.Console.Price,
                Discount = b.Product.Videogame?.Discount ?? b.Product.Console.Discount,
                PrincipalImageURL = b.Product.Videogame?.PrincipalImageURL ?? b.Product.Console?.PrincipalImageURL,
                Videogame = b.Product.Videogame != null ? b.Product.Videogame.mapToReadDto() : null,
                Console = b.Product.Console != null ? b.Product.Console.mapToReadDto() : null
            }
        }).ToList();

        return basketDtos;
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
        var basketDto = Get(idUser);
        if (basketDto == null)
        {
            throw new KeyNotFoundException("Basket not found.");
        }
        var basket = _context.Baskets.FirstOrDefault(g => g.UserId == idUser && g.ProductId == idProduct);
        if (basket != null)
        {
            _context.Baskets.Remove(basket);
            SaveChanges();
        }

    }

    public void DeleteByUser(int idUser)
    {
        var baskets = _context.Baskets.Where(b => b.UserId == idUser).ToList();

        if (baskets == null || baskets.Count == 0)
        {
            throw new KeyNotFoundException("No se encontraron productos en el carrito para este usuario.");
        }

        _context.Baskets.RemoveRange(baskets);
        SaveChanges();
    }


    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}