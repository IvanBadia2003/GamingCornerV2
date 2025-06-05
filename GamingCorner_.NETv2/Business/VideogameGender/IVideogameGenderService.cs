namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface IVideogameGenderService
{
    List<VideogameGenderDTO> GetAll();
    // GetAll(int id);
    void Add(VideogameGenderCreateDTO videogameGenderCreateDTO);
    VideogameGenderDTO Get(int idGender, int idVideogame);
    void Delete(int idGender, int idVideogame);

    /// <summary>
    /// Obtener los generos de un videojuego
    /// </summary>
    /// <param name="idVideogame"></param>
    /// <returns></returns>
    List<VideogameGenderDTO> GetGendersByVideogameId(int idVideogame);

}