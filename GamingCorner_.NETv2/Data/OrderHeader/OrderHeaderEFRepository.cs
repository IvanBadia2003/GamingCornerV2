namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;
using GamingCorner.Models.DTOs.ProductDTOs;

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
                User = v.User,
                Fecha = v.Fecha,
                Total = v.Total

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
    public void Add(OrderHeader orderHeader)
    {
        _context.OrderHeaders.Add(orderHeader);
        SaveChanges();
    }


    /// <summary>
    /// Obtenemos un videojuego por su ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public OrderHeaderDTO Get(int id)
    {

        // Obtenemos el videojuego incluyendo su producto
        var orderHeader = _context.OrderHeaders
            .Where(orderHeader => orderHeader.Id == id)
            .FirstOrDefault();

        // si existe el juego
        if (orderHeader != null)
        {

            // Mapeamos la entidad al DTO
            var orderHeaderDto = new OrderHeaderDTO
            {
                Id = orderHeader.Id,
                User = orderHeader.User,
                Total = orderHeader.Total,
                Fecha = orderHeader.Fecha
            };

            // Devolvemos el DTO
            return orderHeaderDto;
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
        var orderHeaderDto = Get(id);
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

}
