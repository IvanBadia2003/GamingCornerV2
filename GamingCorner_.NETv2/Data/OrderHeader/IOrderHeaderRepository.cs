using GamingCorner.Models;
using GamingCorner.Models.DTOs.ProductDTOs;

namespace GamingCorner.Data;

public interface IOrderHeaderRepository
{
    List<OrderHeaderDTO> GetAll();
    void Add(OrderHeader orderHeader);
    OrderHeaderDTO Get(int id);
    void Update(OrderHeader orderHeader);
    void Delete(int id);

}