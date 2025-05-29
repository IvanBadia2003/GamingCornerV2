namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;
using GamingCorner.Models.DTOs.ProductDTOs;

public interface IOrderHeaderService
{
    List<OrderHeaderDTO> GetAll();
    void Add(OrderHeaderCreateDTO orderHeaderCreateDTO);
    OrderHeaderDTO Get(int id);
    void Update(int id, OrderHeaderUpdateDTO videogameUpdateDTO);
    void Delete(int id);
}
