using GamingCorner.Models;
using GamingCorner.Models.DTOs.ProductDTOs;

namespace GamingCorner.Data;

public interface IOrderHeaderRepository
{
    List<OrderHeaderDTO> GetAll();
    OrderHeader Add(OrderHeader orderHeader);
    List<OrderHeaderDTO> GetByUserId(int userId);
    void Update(OrderHeader orderHeader);
    void Delete(int id);

    /// <summary>
    /// Obtenemos la una cabecera de pedido por su id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public OrderHeaderDTO GetById(int Id);

    /// <summary>
    /// Obtener todos los videojuegos que ha comprado un usuario
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public List<Videogame> GetPurchasedVideogamesByUser(int userId);


    /// <summary>
    /// Obtener estadísticas de compra del usuario
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public UserPurchaseStatsDTO GetUserPurchaseStats(int userId);


}