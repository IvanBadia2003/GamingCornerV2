namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface IFavouriteService
{
    List<FavouriteDTO> GetAll();
    // GetAll(int id);
    void Add(FavouriteCreateDTO basketCreateDTO);
    // BasketDTO Get(int idUser);
    List<FavouriteDTO> Get(int idUser, int? idProduct = null);
    void Delete(int idUser, int idProduct);

    /// <summary>
    /// Obtener los generos de un videojuego
    /// </summary>
    /// <param name="idVideogame"></param>
    /// <returns></returns>
    // List<VideogameGenderDTO> GetGendersByVideogameId(int idVideogame);

}