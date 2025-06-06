namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;
using GamingCorner.Models.DTOs.ProductDTOs;
using System.Threading.Tasks;

public class OrderHeaderEFRepository : IOrderHeaderRepository
{


    private readonly GamingCornerContext _context;

    public OrderHeaderEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    /// <summary>
    /// Obtenemos lista con todos los videojuegos
    /// </summary>
    /// <returns></returns>
    public List<OrderHeaderDTO> GetAll()
    {
        // Obtenemos todos los videojuegos incluyendo su producto
        var orderHeaders = _context.OrderHeaders.ToList();//.Include(v => v.Product).ToList();

        // si existe
        if (orderHeaders != null)
        {
            // Mapeamos la entidad al DTO
            var orderHeaderDto = orderHeaders.Select(v => new OrderHeaderDTO
            {
                Id = v.Id,
                UserId = v.UserId,
                BillingAddress = v.BillingAddress,
                CreatedAt = v.CreatedAt,
                OrderNumber = v.OrderNumber,
                PaymentMethod = v.PaymentMethod

            }).ToList();

            // Devolvemos la lista con los DTO
            return orderHeaderDto;
        }
        else
        {
            return null;
        }
    }


    /// <summary>
    /// Añadimos un videojuego
    /// </summary>
    /// <param name="videogame"></param>
    public OrderHeader Add(OrderHeader orderHeader)
    {
        orderHeader.CreatedAt = DateTime.Now;
        orderHeader.OrderNumber = $"ORD-{Guid.NewGuid().ToString("N")[..12].ToUpper()}";
        _context.OrderHeaders.Add(orderHeader);
        SaveChanges();

        return orderHeader;
    }


    /// <summary>
    /// Obtenemos la lista de pedidos por id del usuario
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<OrderHeaderDTO> GetByUserId(int userId)
    {

        var orderHeader = _context.OrderHeaders
            .Where(orderHeader => orderHeader.UserId == userId)
            .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Product)
                    .ThenInclude(p => p.Videogame)
            .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Product)
                    .ThenInclude(p => p.Console)
            .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Product)
                    .ThenInclude(p => p.SecondHandProduct)
            .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Product)
                    .ThenInclude(p => p.Platform)
            .ToList();


        // si existe el juego
        if (orderHeader != null)
        {
            // Devolvemos el DTO
            return orderHeader.Select(r => r.ToOrderHeaderDTO()).ToList();

        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Obtenemos la una cabecera de pedido por su id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public OrderHeaderDTO GetById(int Id)
    {

        // Obtenemos el videojuego incluyendo su producto
        var orderHeader = _context.OrderHeaders
            .Where(orderHeader => orderHeader.Id == Id)
            .Include(o => o.OrderLines)
            .FirstOrDefault();

        // si existe el juego
        if (orderHeader != null)
        {
            // Devolvemos el DTO
            return orderHeader.ToOrderHeaderDTO();

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
    public void Update(OrderHeader orderHeader)
    {
        // Buscamos el videojuego por su ID
        var existingOrderHeader = _context.OrderHeaders.Find(orderHeader.Id);

        // Si existe
        if (orderHeader != null)
        {

            _context.Entry(existingOrderHeader).CurrentValues.SetValues(orderHeader);
            _context.SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException("Order Header not found.");
        }
    }

    /// <summary>
    /// Borramos un juego
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="KeyNotFoundException"></exception>
    public void Delete(int id)
    {
        var orderHeaderDto = GetById(id);
        if (orderHeaderDto == null)
        {
            throw new KeyNotFoundException("Order Header not found.");
        }
        var orderHeader = _context.OrderHeaders.FirstOrDefault(v => v.Id == id);
        if (orderHeader != null)
        {
            _context.OrderHeaders.Remove(orderHeader);
            SaveChanges();
        }

    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public List<Videogame> GetPurchasedVideogamesByUser(int userId)
    {
        return _context.OrderHeaders
            .Where(o => o.UserId == userId)
            .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Product)
                    .ThenInclude(p => p.Videogame)
                .ThenInclude(vp => vp.Product)
            .SelectMany(o => o.OrderLines)
            .Where(ol => ol.Product != null && ol.Product.Videogame != null)
            .Select(ol => ol.Product.Videogame!)
            .Distinct()
            .ToList();
    }

    public UserPurchaseStatsDTO GetUserPurchaseStats(int userId)
    {
        var orders = _context.OrderHeaders
            .Where(o => o.UserId == userId)
            .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Product)
                    .ThenInclude(p => p.Videogame)
            .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Product)
                    .ThenInclude(p => p.Console)
            .Include(o => o.OrderLines)
                .ThenInclude(ol => ol.Product)
                    .ThenInclude(p => p.SecondHandProduct)
            .ToList();

        var stats = new UserPurchaseStatsDTO();

        foreach (var order in orders)
        {
            foreach (var line in order.OrderLines)
            {
                var product = line.Product;

                if (product.Videogame != null)
                {
                    stats.TotalVideogames++;
                    stats.TotalSavedOnVideogames += Math.Round(product.Videogame.Price - line.Price, 2);
                }
                else if (product.Console != null)
                {
                    stats.TotalConsoles++;
                    stats.TotalSavedOnConsoles += Math.Round(product.Console.Price - line.Price, 2);
                }
                else if (product.SecondHandProduct != null)
                {
                    stats.TotalSecondHandProducts++;
                }
            }
        }

        // ➕ Añadir estadísticas de productos en venta por el usuario
        var secondHandProducts = _context.SecondHandProducts
            .Where(p => p.UserId == userId)
            .ToList();

        stats.TotalProductsOnSale = secondHandProducts.Count;
        stats.CheckedProductsOnSale = secondHandProducts.Count(p => p.IsChecked);
        stats.UncheckedProductsOnSale = secondHandProducts.Count(p => !p.IsChecked);

        return stats;
    }

}

