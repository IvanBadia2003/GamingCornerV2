namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using GamingCorner.Models.Enums.SystemEnum;

public class PlatformEFRepository : IPlatformRepository
{


    private readonly GamingCornerContext _context;

    public PlatformEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<PlatformDTO> GetAll()
    {
        var platforms = _context.Platforms
            .ToList();

        if (platforms != null)
        {
            var platformDto = platforms.Select(p => new PlatformDTO
            {
                PlatformId = p.PlatformId,
                Name = p.Name,
                System = p.System,

            }).ToList();
            return platformDto;
        }
        else
        {
            return null;
        }
    }


    /// <summary>
    /// Obtener plataformas por sistema
    /// </summary>
    /// <param name="system"></param>
    /// <returns></returns>
    public List<PlatformDTO> GetplatformsBySystem(int system)
    {
        var platforms = _context.Platforms.Where(p => p.System == (SystemEnum)system)
            .ToList();

        if (platforms != null)
        {
            var platformDto = platforms.Select(p => new PlatformDTO
            {
                PlatformId = p.PlatformId,
                Name = p.Name,
                System = p.System,

            }).ToList();
            return platformDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(Platform platform)
    {
        _context.Platforms.Add(platform);
        SaveChanges();
    }

    public PlatformDTO Get(int id)
    {
        var platform = _context.Platforms
            .Where(platform => platform.PlatformId == id)
            .FirstOrDefault();

        if (platform != null)
        {
            var platformDto = new PlatformDTO
            {
                PlatformId = platform.PlatformId,
                Name = platform.Name,
                System = platform.System,
            };
            return platformDto;
        }
        else
        {
            return null;
        }
    }

    // public List<Videogame> GetVideogamesByPlatform (int id)
    // {
    //     return _context.Videogames
    //                    //.Where(v => v.PlatformId == id)
    //                    .ToList();    
    // }
    // public List<Console> GetConsolesByPlatform (int id)
    // {
    //     return _context.Consoles
    //                    //.Where(v => v.ConsoleId == id)
    //                    .ToList();    
    // }

    public void Update(Platform platform)
    {
        var existingPlatform = _context.Platforms.Find(platform.PlatformId);

        if (existingPlatform != null)
        {
            _context.Entry(existingPlatform).CurrentValues.SetValues(platform);
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var platformDto = Get(id);
        if (platformDto == null)
        {
            throw new KeyNotFoundException("Platform not found.");
        }
        var platform = _context.Platforms.FirstOrDefault(p => p.PlatformId == id);
        if (platform != null)
        {
            _context.Platforms.Remove(platform);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
