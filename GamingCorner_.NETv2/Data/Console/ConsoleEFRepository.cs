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
            .Include(c => c.Product)
            .ToList();

        if (consoles != null)
        {
            var consoleDto = consoles.Select(c => new ConsoleDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Specifications = c.Specifications,
                Price = c.Price,
                Stock = c.Stock,
                Brand = c.Brand,
                Discount = c.Discount,
                PrincipalImageURL = c.PrincipalImageURL,
                ProductId = c.Product.Id,
                ReleaseDate = c.ReleaseDate,
                Sales = c.Product.Sales

            }).ToList();
            return consoleDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(Console console)
    {        //Primero se crea el producto
        var producto = new Product();
        _context.Products.Add(producto);
        SaveChanges();

        //Segundo se crea la consola con el id del producto
        console.ProductId = producto.Id;
        _context.Consoles.Add(console);
        SaveChanges();
    }

    public ConsoleDTO Get(int id)
    {
        var console = _context.Consoles
            // .Include(p => p.Platform)
            .Where(console => console.Id == id)
            .Include(c => c.Product)
            .FirstOrDefault();

        if (console != null)
        {
            var consoleDto = new ConsoleDTO
            {
                Id = console.Id,
                Name = console.Name,
                Description = console.Description,
                Specifications = console.Specifications,
                Price = console.Price,
                Stock = console.Stock,
                Brand = console.Brand,
                Discount = console.Discount,
                PrincipalImageURL = console.PrincipalImageURL,
                ProductId = console.Product.Id,
                ReleaseDate = console.ReleaseDate,
                Sales = console.Product.Sales

            };
            return consoleDto;
        }
        else
        {
            return null;
        }
    }

    public void Update(Console console)
    {
        var existingConsole = _context.Consoles.Find(console.Id);
        if (existingConsole != null)
        {

            //if (!_context.Platforms.Any(p => p.PlatformId == console.PlatformId))
            //{
            //    throw new Exception("El PlatformId proporcionado no existe.");
            //}

            // Asegúrate de que el PlatformId no sea NULL
            //if (console.PlatformId == null)
            //{
            //    throw new Exception("El PlatformId no puede ser nulo.");
            //}

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
        var console = _context.Consoles.FirstOrDefault(c => c.Id == id);
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
