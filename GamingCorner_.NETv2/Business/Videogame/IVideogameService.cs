namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface IVideogameService
{

    /// <summary>
    /// Obtener una lista con todos los videojuegos
    /// </summary>
    /// <returns></returns>
    List<VideogameDTO> GetAll();

    /// <summary>
    /// Crear un nuevo juego
    /// </summary>
    /// <param name="videogameCreateDTO"></param>
    void Add(VideogameCreateDTO videogameCreateDTO);

    /// <summary>
    /// Obtener un juego por su ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    VideogameDTO Get(int id);

    /// <summary>
    /// Actualizar un juego
    /// </summary>
    /// <param name="id"></param>
    /// <param name="videogameUpdateDTO"></param>
    void Update(int id, VideogameUpdateDTO videogameUpdateDTO);

    /// <summary>
    /// Borrar un juego
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);
}
