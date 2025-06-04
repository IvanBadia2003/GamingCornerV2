namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;
using GamingCorner.Models.DTOs.ProductDTOs;

public class OrderLineEFRepository : IOrderLineEFRepository
{


    private readonly GamingCornerContext _context;

    public OrderLineEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    /// <summary>
    /// Obtenemos lista con todos los videojuegos
    /// </summary>
    /// <returns></returns>
    public List<OrderLineDTO> GetAll()
    {
        // Obtenemos todos los videojuegos incluyendo su producto
        var orderLines = _context.OrderLines.ToList();//.Include(v => v.Product).ToList();

        // si existe
        if (orderLines != null)
        {

            return orderLines.Select(r => r.ToOrderLineDTO()).ToList();

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
    public void Add(OrderLine orderLine)
    {
        _context.OrderLines.Add(orderLine);
        SaveChanges();
    }


    /// <summary>
    /// Obtenemos la lista de pedidos por id del usuario
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<OrderLineDTO> GetByHeaderId(int headerId)
    {

        // Obtenemos el videojuego incluyendo su producto
        var orderLines = _context.OrderLines
            .Where(ol => ol.OrderHeaderId== headerId)
            .Include(o => o.Product)
            .ToList();

        // si existe el juego
        if (orderLines != null)
        {
            // Devolvemos el DTO
            return orderLines.Select(r => r.ToOrderLineDTO()).ToList();

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
    public OrderLineDTO GetById(int Id)
    {

        // Obtenemos el videojuego incluyendo su producto
        var orderLine = _context.OrderLines
            .Where(orderHeader => orderHeader.Id == Id)
            .Include(o => o.Product)
            .FirstOrDefault();

        // si existe el juego
        if (orderLine != null)
        {
            // Devolvemos el DTO
            return orderLine.ToOrderLineDTO();

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
    public void Update(OrderLine orderLine)
    {
        // Buscamos el videojuego por su ID
        var existingOrderLine = _context.OrderLines.Find(orderLine.Id);

        // Si existe
        if (existingOrderLine != null)
        {

            _context.Entry(existingOrderLine).CurrentValues.SetValues(orderLine);
            _context.SaveChanges();
        }
        else
        {
            throw new KeyNotFoundException("Order Line not found.");
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
            throw new KeyNotFoundException("Order Line not found.");
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
