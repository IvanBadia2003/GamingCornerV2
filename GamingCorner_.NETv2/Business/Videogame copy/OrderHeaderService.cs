namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using GamingCorner.Models.DTOs.ProductDTOs;

public class OrderHeaderService : IOrderHeaderService
{

    private readonly IOrderHeaderRepository _orderHeaderRepository;


    public OrderHeaderService(IOrderHeaderRepository orderHeaderRepository)
    {
        _orderHeaderRepository = orderHeaderRepository;

    }

    /// <summary>
    /// Obtener lista de todos los videojuegos
    /// </summary>
    /// <returns></returns>
    public List<OrderHeaderDTO> GetAll()
    {
        var orderHeaders = _orderHeaderRepository.GetAll();
 
        return orderHeaders;
    }

    /// <summary>
    /// Obtener videojuego por su ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public OrderHeaderDTO Get(int id)
    {
        var orderHeader = _orderHeaderRepository.Get(id);
        if (orderHeader == null)
        {
            throw new KeyNotFoundException($"Order Header con Id {id} no encontrada.");
        }
        return orderHeader;
    }

    /// <summary>
    /// A�adir videojuego
    /// </summary>
    /// <param name="videogameCreateDTO"></param>
    public void Add(OrderHeaderCreateDTO orderHeaderCreateDTO)
    {
        var orderHeader = new OrderHeader();
        var mappedOrderHeader = orderHeader.mapFromCreateDto(orderHeaderCreateDTO);
        _orderHeaderRepository.Add(mappedOrderHeader);
    }

    /// <summary>
    /// Actualizar videojuego
    /// </summary>
    /// <param name="id"></param>
    /// <param name="videogameUpdateDTO"></param>
    /// <exception cref="KeyNotFoundException"></exception>
    public void Update(int id, OrderHeaderUpdateDTO orderHeaderUpdateDTO)
    {
        var orderHeaderDTO = _orderHeaderRepository.Get(id);
        if(orderHeaderDTO == null)
        {
            throw new KeyNotFoundException($"Order Header con Id {id} no encontrada.");
        }
    }

    /// <summary>
    /// Borrar videojuego
    /// </summary>
    /// <param name="id"></param>
    public void Delete(int id)
    {
        _orderHeaderRepository.Delete(id);
    }
}


    
    

