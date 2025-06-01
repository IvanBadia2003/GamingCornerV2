namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;
using GamingCorner.Models.Enums.OrderDirectionEnum;

public class VideogameEFRepository : IVideogameRepository
{


    private readonly GamingCornerContext _context;

    public VideogameEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    /// <summary>
    /// Obtenemos lista con todos los videojuegos
    /// </summary>
    /// <returns></returns>
    public List<VideogameDTO> GetAll()
    {
        // Obtenemos todos los videojuegos incluyendo su producto
        var videogames = _context.Videogames.Include(v => v.Product).ThenInclude(p => p.Platform).Include(v => v.VideogameGenders).ThenInclude(vg => vg.Gender).ToList();

        // si existe
        if (videogames != null)
        {
            // Mapeamos la entidad al DTO
            var videogameDto = videogames.Select(v => new VideogameDTO
            {
                Id = v.Id,
                Name = v.Name,
                Pegi = v.Pegi,
                Description = v.Description,
                Requisitos1 = v.Requisitos1,
                Requisitos2 = v.Requisitos2,
                Stock = v.Stock,
                Distributor = v.Distributor,
                ReleaseDate = v.ReleaseDate,
                Developer = v.Developer,
                Discount = v.Discount,
                ProductId = v.ProductId,
                PlatformId =v.Product.Platform.PlatformId,
                GenderId = v.VideogameGenders.Select(vg => vg.GenderId).ToList(),
                Price = v.Price,
                PrincipalImageURL = v.PrincipalImageURL,
                Sales = v.Product.Sales

            }).ToList();

            // Devolvemos la lista con los DTO
            return videogameDto;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Obtenemos lista con todos los videojuegos
    /// </summary>
    /// <returns></returns>
    public List<VideogameDTO> GetFiltered(VideogameFilterDto filters)
    {
        var query = _context.Videogames
            .Include(v => v.Product)
                .ThenInclude(p => p.Platform)
            .Include(v => v.VideogameGenders)
                .ThenInclude(vg => vg.Gender)
            .AsQueryable();

        // Filtrar por plataforma
        if (filters.Platform.HasValue)
            query = query.Where(v => v.Product.Platform.PlatformId == filters.Platform.Value);

        // Filtrar por genero
        if (filters.Genre.HasValue)
            query = query.Where(v => v.VideogameGenders.Any(vg => vg.GenderId == filters.Genre.Value));

        // Filtrar por precio minimo
        if (filters.MinPrice.HasValue)
            query = query.Where(v => v.Price >= filters.MinPrice.Value);

        // Filtrar por precio máximo
        if (filters.MaxPrice.HasValue)
            query = query.Where(v => v.Price <= filters.MaxPrice.Value);

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
                query = filters.OrderDirection == OrderDirectionEnum.DESC ? query.OrderByDescending(v => v.Price) : query.OrderBy(v => v.Price);
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
                query = query.OrderBy(v => v.Name); // por defecto
                break;
        }

        var videogameDto = query.Select(v => new VideogameDTO
        {
            Id = v.Id,
            Name = v.Name,
            Pegi = v.Pegi,
            Description = v.Description,
            Requisitos1 = v.Requisitos1,
            Requisitos2 = v.Requisitos2,
            Stock = v.Stock,
            Distributor = v.Distributor,
            ReleaseDate = v.ReleaseDate,
            Developer = v.Developer,
            Discount = v.Discount,
            ProductId = v.ProductId,
            PlatformId = v.Product.Platform.PlatformId,
            GenderId = v.VideogameGenders.Select(vg => vg.GenderId).ToList(),
            Price = v.Price,
            PrincipalImageURL = v.PrincipalImageURL,
            Sales = v.Product.Sales
        }).ToList();

        return videogameDto;
    }



    /// <summary>
    /// Añadimos un videojuego
    /// </summary>
    /// <param name="videogame"></param>
    public Videogame Add(Videogame videogame)
    {

        _context.Videogames.Add(videogame);
        SaveChanges();

        return videogame;
    }


    /// <summary>
    /// Obtenemos un videojuego por su ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public VideogameDTO Get(int id)
    {

        // Obtenemos el videojuego incluyendo su producto
        var videogame = _context.Videogames
            .Where(videogame => videogame.Id == id)
            .Include(v => v.Product)
            .FirstOrDefault();

        // si existe el juego
        if (videogame != null)
        {

            // Mapeamos la entidad al DTO
            var videogameDto = new VideogameDTO
            {
                Id = videogame.Id,
                Name = videogame.Name,
                Pegi = videogame.Pegi,
                Description = videogame.Description,
                Requisitos1 = videogame.Requisitos1,
                Requisitos2 = videogame.Requisitos2,
                Stock = videogame.Stock,
                Distributor = videogame.Distributor,
                ReleaseDate = videogame.ReleaseDate,
                Developer = videogame.Developer,
                Discount = videogame.Discount,
                ProductId = videogame.ProductId,
                //PlatformId =v.PlatformId,
                //GenderId =v.GenderId,
                Price = videogame.Price,
                PrincipalImageURL = videogame.PrincipalImageURL,
                Sales = videogame.Product.Sales
            };

            // Devolvemos el DTO
            return videogameDto;
        }
        else
        {
            return null;
        }
    }


    /// <summary>
    /// Actualizamos el videojuego
    /// </summary>
    /// <param name="videogame"></param>
    /// <exception cref="KeyNotFoundException"></exception>
    public void Update(Videogame videogame)
    {
        // Buscamos el videojuego por su ID
        var existingVideogame = _context.Videogames.Find(videogame.Id);

        // Si existe
        if (existingVideogame != null)
        {
            // Verifica si el nuevo PlatformId existe en la tabla Platforms
            //if (!_context.Platforms.Any(p => p.PlatformId == videogame.PlatformId))
            //{
            //    throw new Exception("El PlatformId proporcionado no existe.");
            //}

            // Asegúrate de que el PlatformId no sea NULL
            //if (videogame.PlatformId == null)
            //{
            //    throw new Exception("El PlatformId no puede ser nulo.");
            //}

            _context.Entry(existingVideogame).CurrentValues.SetValues(videogame);
            _context.SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException("Videogame not found.");
        }
    }

    /// <summary>
    /// Borramos un juego
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="KeyNotFoundException"></exception>
    public void Delete(int id)
    {
        var videogameDto = Get(id);
        if (videogameDto == null)
        {
            throw new KeyNotFoundException("Videogame not found.");
        }
        var videogame = _context.Videogames.FirstOrDefault(v => v.Id == id);
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
