namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;

public class VideogameGenderEFRepository : IVideogameGenderRepository
{


    private readonly GamingCornerContext _context;

    public VideogameGenderEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<VideogameGenderDTO> GetAll()
    {
        var videogameGenders = _context.VideogameGenders
            .ToList();

        if (videogameGenders != null)
        {
            var videogameGenderDto = videogameGenders.Select(g => new VideogameGenderDTO
            {
                GenderId = g.GenderId,
                VideogameId = g.VideogameId,
            }).ToList();
            return videogameGenderDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(VideogameGender videogameGender)
    {
        _context.VideogameGenders.Add(videogameGender);
        SaveChanges();
    }

    public VideogameGenderDTO Get(int idGender, int idVideogame)
    {
        var videogameGender = _context.VideogameGenders
            .Where(vg => vg.GenderId == idGender && vg.VideogameId == idVideogame)
            .FirstOrDefault();

        if (videogameGender != null)
        {
            var videogameGenderDto = new VideogameGenderDTO
            {
                GenderId = videogameGender.GenderId,
                VideogameId = videogameGender.VideogameId
            };
            return videogameGenderDto;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Obtener los generos de un juego
    /// </summary>
    /// <param name="idVideogame"></param>
    /// <returns></returns>
    public List<VideogameGender> GetGendersByVideogameId(int idVideogame)
    {
        var videogameGenders = _context.VideogameGenders
            .Where(vg => vg.VideogameId == idVideogame)
            .ToList();

        return videogameGenders;
    }


    // public void Update(Gender gender)
    // {
    //     var existingGender = _context.Genders.Find(gender.GenderId);

    //     if (existingGender != null)
    //     {
    //         _context.Entry(existingGender).CurrentValues.SetValues(gender);
    //         _context.SaveChanges();
    //     }
    // }

    public void Delete(int idGender, int idVideogame)
    {
        var videogameGenderDto = Get(idGender, idVideogame);
        if (videogameGenderDto == null)
        {
            throw new KeyNotFoundException("Gender not found.");
        }
        var videogameGender = _context.VideogameGenders.FirstOrDefault(g => g.GenderId == idGender && g.VideogameId == idVideogame) ;
        if (videogameGender != null)
        {
            _context.VideogameGenders.Remove(videogameGender);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}