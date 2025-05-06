namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

public class ConsoleEFRepository : IConsoleRepository
{


    private readonly GamingCornerContext _context;

    public ConsoleEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<ConsoleDTO> GetAll()
    {
        var consoles = _context.Consoles
            .ToList();

        if (consoles != null)
        {
            var consoleDto = consoles.Select(c => new ConsoleDTO
            {
                ConsoleId = c.ConsoleId,
                Name = c.Name,
                Specifications = c.Specifications,
                Price = c.Price,
                Stock = c.Stock,
                Available = c.Available,
                ImageURL = c.ImageURL,
            }).ToList();
            return consoleDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(Console_ console)
    {
        _context.Consoles.Add(console);
        SaveChanges();
    }

    public ConsoleDTO Get(int id)
    {
        var console = _context.Consoles
            // .Include(p => p.Platform)
            .Where(console => console.ConsoleId == id)
            .FirstOrDefault();

        if (console != null)
        {
            var consoleDto = new ConsoleDTO
            {
                ConsoleId = console.ConsoleId,
                Name = console.Name,
                Specifications = console.Specifications,
                PlatformId = console.PlatformId,
                Price = console.Price,
                Stock = console.Stock,
                Available = console.Available,
                ImageURL = console.ImageURL,

            };
            return consoleDto;
        }
        else
        {
            return null;
        }
    }

    public void Update(Console_ console)
    {
        var existingConsole = _context.Consoles.Find(console.ConsoleId);
        if (existingConsole != null)
        {

            if (!_context.Platforms.Any(p => p.PlatformId == console.PlatformId))
            {
                throw new Exception("El PlatformId proporcionado no existe.");
            }

            // Asegúrate de que el PlatformId no sea NULL
            if (console.PlatformId == null)
            {
                throw new Exception("El PlatformId no puede ser nulo.");
            }

            _context.Entry(existingConsole).CurrentValues.SetValues(console);
            _context.SaveChanges();

        }
    }

    public void Delete(int id)
    {
        var consoleDto = Get(id);
        if (consoleDto == null)
        {
            throw new KeyNotFoundException("Console not found.");
        }
        var console = _context.Consoles.FirstOrDefault(c => c.ConsoleId == id);
        if (console != null)
        {
            _context.Consoles.Remove(console);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
