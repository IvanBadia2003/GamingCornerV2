namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;
using GamingCorner.Models.DTOs.ProductDTOs;

public interface IOrderLineService
{
    List<OrderLineDTO> GetAll();
    void Add(CreateOrderLineDTO orderline);
    List<OrderLineDTO> GetByHeaderId(int headerId);
    //void Update(OrderLine orderLine);
    void Delete(int id);

    /// <summary>
    /// Obtenemos la una cabecera de pedido por su id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public OrderLineDTO GetById(int id);
}
