namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using GamingCorner.Models.Enums.OrderDirectionEnum;
using System;

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
            .Include(c => c.Product).ThenInclude(c => c.Platform)
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
                Sales = c.Product.Sales,
                Colors = c.Colors,
                Generation = c.Generation,
                PlatformId = c.Product.Platform.PlatformId,
                Services = c.Services

            }).ToList();
            return consoleDto;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Obtenemos lista con todas las consolas
    /// </summary>
    /// <returns></returns>
    public List<ConsoleDTO> GetFiltered(ConsoleFilterDTO filters)
    {
        var query = _context.Consoles
            .Include(v => v.Product)
                .ThenInclude(p => p.Platform)
            .AsQueryable();

        // Filtrar por plataforma
        if (filters.Platform.HasValue)
            query = query.Where(v => v.Product.Platform.PlatformId == filters.Platform.Value);

        // Filtrar por texto de búsqueda
        if (!string.IsNullOrEmpty(filters.Brand))
        {
            var searchLower = filters.Brand.ToLower();
            query = query.Where(v => v.Brand.ToLower().Contains(searchLower));
        }

        // Filtrar por precio minimo
        if (filters.MinPrice.HasValue)
            query = query.Where(v => (v.Price * (1 - (v.Discount / 100.0m))) >= filters.MinPrice.Value);

        // Filtrar por precio máximo
        if (filters.MaxPrice.HasValue)
            query = query.Where(v => (v.Price * (1 - (v.Discount / 100.0m))) <= filters.MaxPrice.Value);

        // Filtrar por texto de búsqueda
        if (!string.IsNullOrEmpty(filters.Search))
        {
            var searchLower = filters.Search.ToLower();
            query = query.Where(v => v.Name.ToLower().Contains(searchLower));
        }

        // Filtrar por sistema
        if (filters.System.HasValue)
            query = query.Where(v => v.Product.Platform.System == filters.System);

        // Ordenamiento
        var orderBy = filters.OrderBy?.ToLower();

        switch (orderBy)
        {
            case "price":
                query = filters.OrderDirection == OrderDirectionEnum.DESC ? query.OrderByDescending(v => (v.Price * (1 - (v.Discount / 100.0m)))) : query.OrderBy(v => (v.Price * (1 - (v.Discount / 100.0m))));
                break;
            case "name":
                query = filters.OrderDirection == OrderDirectionEnum.DESC ? query.OrderByDescending(v => v.Name) : query.OrderBy(v => v.Name);
                break;
            case "releasedate":
                query = filters.OrderDirection == OrderDirectionEnum.DESC ? query.OrderByDescending(v => v.ReleaseDate) : query.OrderBy(v => v.ReleaseDate);
                break;
            case "discount":
                query = filters.OrderDirection == OrderDirectionEnum.DESC ? query.OrderByDescending(v => v.Discount) : query.OrderBy(v => v.Discount);
                break;
            default:
                break;
        }

        var consoleDto = query.Select(c => new ConsoleDTO
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
            Sales = c.Product.Sales,
            Colors = c.Colors,
            Generation = c.Generation,
            PlatformId = c.Product.Platform.PlatformId,
            Services = c.Services

        }).ToList();

        return consoleDto;
    }

    public Models.Console Add(Models.Console console)
    {        //Primero se crea el producto

        _context.Consoles.Add(console);
        SaveChanges();

        return console;
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

    public void Update(Models.Console console)
    {
        var existingConsole = _context.Consoles.Find(console.Id);

        if (existingConsole != null)
        {
            _context.Entry(existingConsole).CurrentValues.SetValues(console);
            _context.SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException("Product not found.");
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

    /// <summary>
    /// Obtenemos lista con las 3 consolas más vendidas
    /// </summary>
    /// <returns></returns>
    public List<ConsoleDTO> TopSellingConsoles()
    {
        var consoles = _context.Consoles
            .Include(v => v.Product)
                .OrderByDescending(v => v.Product.Sales).Take(3)
            .ToList();



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
            Sales = c.Product.Sales,
            Colors = c.Colors,
            Generation = c.Generation,
            //PlatformId = c.Product.Platform.PlatformId,
            Services = c.Services

        }).ToList();

        return consoleDto;
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

}
