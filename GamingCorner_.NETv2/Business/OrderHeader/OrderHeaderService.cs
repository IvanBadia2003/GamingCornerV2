namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using GamingCorner.Models.DTOs.ProductDTOs;
using GamingCorner.Models.DTOs.VideogameDTOs;

public class OrderHeaderService : IOrderHeaderService
{

    private readonly IOrderHeaderRepository _orderHeaderRepository;
    private readonly IBasketRepository _basketRepository;
    private readonly IOrderLineEFRepository _orderLineRepository;
    private readonly IProductEFRepository _productRepository;



    public OrderHeaderService(IOrderHeaderRepository orderHeaderRepository, IBasketRepository basketRepository, IOrderLineEFRepository orderLineRepository, IProductEFRepository productRepository)
    {
        _orderHeaderRepository = orderHeaderRepository;
        _basketRepository = basketRepository;
        _orderLineRepository = orderLineRepository;
        _productRepository = productRepository;


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
    /// Obtener lista de todos los videojuegos
    /// </summary>
    /// <returns></returns>
    public List<OrderHeaderDTO> GetByUserId(int userId)
    {
        var orderHeaders = _orderHeaderRepository.GetByUserId(userId);



        return orderHeaders;
    }



    /// <summary>
    /// A�adir videojuego
    /// </summary>
    /// <param name="videogameCreateDTO"></param>
    public List<VideogamePurchaseDTO> Add(OrderHeaderCreateDTO orderHeaderCreateDTO)
    {
        var userBasket = _basketRepository.Get(orderHeaderCreateDTO.UserId);
        var orderHeader = _orderHeaderRepository.Add(orderHeaderCreateDTO.ToOrderHeaderEntite());

        foreach (var item in userBasket)
        {

            OrderLine orderLine = new OrderLine()
            {
                CreatedAt =  orderHeader.CreatedAt,
                DigitalCode = item.Product.Videogame != null ? OrderLine.GenerateAlphanumericCode(12) : null,
                OrderHeaderId = orderHeader.Id,
                ProductId = item.Product.Id,
                Price = Math.Round(item.Product.Price * (1 - (item.Product.Discount / 100m)), 2),
                ProductType = item.Product.Videogame != null ? "Juego" : item.Product.Console != null ? "Consola" : "Segunda mano"
            };
            _orderLineRepository.Add(orderLine);

            _productRepository.IncreaseSales(item.Product.Id);
            _productRepository.DecreaseStock(item.Product.Id);
            
        }

        _basketRepository.DeleteByUser(orderHeaderCreateDTO.UserId);

        return orderHeader.OrderLines.Where(ol => ol.Product.Videogame != null).Select(ol => new VideogamePurchaseDTO
        {
            DigitalCode = ol.DigitalCode,
            Name = ol.Product.Videogame.Name
        }).ToList();

    }

    /// <summary>
    /// Actualizar videojuego
    /// </summary>
    /// <param name="id"></param>
    /// <param name="videogameUpdateDTO"></param>
    /// <exception cref="KeyNotFoundException"></exception>
    public void Update(int id, OrderHeaderUpdateDTO orderHeaderUpdateDTO)
    {
        var orderHeaderDTO = _orderHeaderRepository.GetById(id);
        if (orderHeaderDTO == null)
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

    public OrderHeaderDTO GetBtId(int id)
    {
        var orderHeader = _orderHeaderRepository.GetById(id);
        if (orderHeader == null)
        {
            throw new KeyNotFoundException($"Order Header con Id {id} no encontrada.");
        }
        return orderHeader;
    }

    public List<VideogameDTO> GetPurchasedVideogamesByUser(int userId)
    {
        List<Videogame> videogamsEntitie = _orderHeaderRepository.GetPurchasedVideogamesByUser(userId);
        return videogamsEntitie.Select(v => v.mapToReadDto()).ToList();
    }

    public UserPurchaseStatsDTO GetUserPurchaseStats(int userId)
    {
        return _orderHeaderRepository.GetUserPurchaseStats(userId);
    }

}





