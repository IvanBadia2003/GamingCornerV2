using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IVideogameRepository
{
    /// <summary>
    /// Obtener una lista con todos los videojuegos
    /// </summary>
    /// <returns></returns
    List<VideogameDTO> GetAll();
    
    /// <summary>
    /// Añadir un videojuego
    /// </summary>
    /// <param name="videogame"></param>
    void Add(Videogame videogame);

    /// <summary>
    /// Obtener un videojuego por ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    VideogameDTO Get(int id);

    /// <summary>
    /// Actualizar un videojuego
    /// </summary>
    /// <param name="videogame"></param>
    void Update(Videogame videogame);

    /// <summary>
    /// Eliminar un videojuego
    /// </summary>
    /// <param name="id"></param>
    void Delete(int id);

}