namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface IBasketService
{
    List<BasketDTO> GetAll();
    // GetAll(int id);
    void Add(BasketCreateDTO basketCreateDTO);
    // BasketDTO Get(int idUser);
    List<BasketDTO> Get(int idUser, int? idProduct = null);
    void Delete(int idUser, int idProduct);

    /// <summary>
    /// Obtener los generos de un videojuego
    /// </summary>
    /// <param name="idVideogame"></param>
    /// <returns></returns>
    // List<VideogameGenderDTO> GetGendersByVideogameId(int idVideogame);

}