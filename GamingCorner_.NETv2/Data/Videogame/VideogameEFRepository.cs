namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;

public class VideogameEFRepository : IVideogameRepository
{


    private readonly GamingCornerContext _context;

    public VideogameEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<VideogameDTO> GetAll()
    {
        var videogames = _context.Videogames
            .ToList();

        if (videogames != null)
        {
            var videogameDto = videogames.Select(v => new VideogameDTO
            {
                VideogameId = v.VideogameId,
                Name = v.Name,
                Pegi = v.Pegi,
                Code = v.Code,
                Description = v.Description,
                Requisitos1 = v.Requisitos1,
                Requisitos2 = v.Requisitos2,
                Stock = v.Stock,
                PlatformId =v.PlatformId,
                Available = v.Available,
                GenderId =v.GenderId,
                Price = v.Price,
                ImageURL = v.ImageURL,
            }).ToList();
            return videogameDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(Videogame videogame)
    {
        _context.Videogames.Add(videogame);
        SaveChanges();
    }

    public VideogameDTO Get(int id)
    {
        var videogame = _context.Videogames
            .Where(videogame => videogame.VideogameId == id)
            .FirstOrDefault();

        if (videogame != null)
        {
            var videogameDto = new VideogameDTO
            {
                VideogameId = videogame.VideogameId,
                Name = videogame.Name,
                Pegi = videogame.Pegi,
                Code = videogame.Code,
                Description = videogame.Description,
                Requisitos1 = videogame.Requisitos1,
                Requisitos2 = videogame.Requisitos2,
                Stock = videogame.Stock,
                Available =videogame.Available,
                GenderId =videogame.GenderId,
                PlatformId =videogame.PlatformId,
                Price = videogame.Price,
                ImageURL = videogame.ImageURL,
            };
            return videogameDto;
        }
        else
        {
            return null;
        }
    }

    public void Update(Videogame videogame)
{
    var existingVideogame = _context.Videogames.Find(videogame.VideogameId);

    if (existingVideogame != null)
    {
        // Verifica si el nuevo PlatformId existe en la tabla Platforms
        if (!_context.Platforms.Any(p => p.PlatformId == videogame.PlatformId))
        {
            throw new Exception("El PlatformId proporcionado no existe.");
        }

        // Asegúrate de que el PlatformId no sea NULL
        if (videogame.PlatformId == null)
        {
            throw new Exception("El PlatformId no puede ser nulo.");
        }

        _context.Entry(existingVideogame).CurrentValues.SetValues(videogame);
        _context.SaveChanges();
    }
    else
    {
        throw new KeyNotFoundException("Videogame not found.");
    }
}


    public void Delete(int id)
    {
        var videogameDto = Get(id);
        if (videogameDto == null)
        {
            throw new KeyNotFoundException("Videogame not found.");
        }
        var videogame = _context.Videogames.FirstOrDefault(v => v.VideogameId == id);
        if (videogame != null)
        {
            _context.Videogames.Remove(videogame);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
