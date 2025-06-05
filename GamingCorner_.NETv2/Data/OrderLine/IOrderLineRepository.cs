using GamingCorner.Models;
using GamingCorner.Models.DTOs.ProductDTOs;

namespace GamingCorner.Data;

public interface IOrderLineEFRepository
{
    List<OrderLineDTO> GetAll();
    void Add(OrderLine orderHeader);
    List<OrderLineDTO> GetByHeaderId(int headerId);
    void Update(OrderLine orderLine);
    void Delete(int id);

    /// <summary>
    /// Obtenemos la una cabecera de pedido por su id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public OrderLineDTO GetById(int Id);

}