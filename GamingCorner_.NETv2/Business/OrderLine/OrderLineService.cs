namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using GamingCorner.Models.DTOs.ProductDTOs;

public class OrderLineService : IOrderLineService
{

    private readonly IOrderLineEFRepository _orderLineRepository;


    public OrderLineService(IOrderLineEFRepository orderLineRepository)
    {
        _orderLineRepository = orderLineRepository;

    }

    /// <summary>
    /// Obtener lista de todos los videojuegos
    /// </summary>
    /// <returns></returns>
    public List<OrderLineDTO> GetAll()
    {
        var orderHeaders = _orderLineRepository.GetAll();
 
        return orderHeaders;
    }

    /// <summary>
    /// Obtener lista de todos los videojuegos
    /// </summary>
    /// <returns></returns>
    public List<OrderLineDTO> GetByHeaderId(int userId)
    {
        var orderHeaders = _orderLineRepository.GetByHeaderId(userId);

        return orderHeaders;
    }



    /// <summary>
    /// A�adir videojuego
    /// </summary>
    /// <param name="videogameCreateDTO"></param>
    public void Add(CreateOrderLineDTO orderLineCreateDTO)
    {
        if (orderLineCreateDTO == null)
            throw new ArgumentNullException(nameof(orderLineCreateDTO));

        var entitieOrderLine = CreateOrderLineDTO.ToOrderLineEntite(orderLineCreateDTO);
        _orderLineRepository.Add(entitieOrderLine);
    }

    /// <summary>
    /// Actualizar videojuego
    /// </summary>
    /// <param name="id"></param>
    /// <param name="videogameUpdateDTO"></param>
    /// <exception cref="KeyNotFoundException"></exception>
    public void Update(int id, OrderLine orderHeaderUpdateDTO)
    {
        var orderHeaderDTO = _orderLineRepository.GetById(id);
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
        _orderLineRepository.Delete(id);
    }

    public OrderLineDTO GetById(int id)
    {
        var orderHeader = _orderLineRepository.GetById(id);
        if (orderHeader == null)
        {
            throw new KeyNotFoundException($"Order Header con Id {id} no encontrada.");
        }
        return orderHeader;
    }

}


    
    

