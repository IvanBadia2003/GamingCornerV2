namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;
using GamingCorner.Models.DTOs.ProductDTOs;
using GamingCorner.Models.DTOs.VideogameDTOs;

public interface IOrderHeaderService
{
    List<OrderHeaderDTO> GetAll();
    List<VideogamePurchaseDTO>  Add(OrderHeaderCreateDTO orderHeaderCreateDTO);
    OrderHeaderDTO GetBtId(int id);
    void Update(int id, OrderHeaderUpdateDTO videogameUpdateDTO);
    void Delete(int id);

    List<OrderHeaderDTO> GetByUserId(int userId);

    /// <summary>
    /// Obtener todos los videojuegos que ha comprado un usuario
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public List<VideogameDTO> GetPurchasedVideogamesByUser(int userId);



    /// <summary>
    /// Obtener estadísticas de compra del usuario
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public UserPurchaseStatsDTO GetUserPurchaseStats(int userId);
}
