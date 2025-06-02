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
    Videogame Add(Videogame videogame);

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

    /// <summary>
    /// Obtenemos lista con todos los videojuegos
    /// </summary>
    /// <returns></returns>
    List<VideogameDTO> GetFiltered(VideogameFilterDto filters);

    /// <summary>
    /// Obtenemos lista con los videojuegos más vendidos
    /// </summary>
    /// <returns></returns>
    List<VideogameDTO> TopSellingVideogames();
}