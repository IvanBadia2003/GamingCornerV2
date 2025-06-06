namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface IConsoleService
{
    List<ConsoleDTO> GetAll();
    // GetAll(int id);
    ConsoleDTO Add(ConsoleCreateDTO consoleCreateDTO);
    ConsoleDTO Get(int id);
    void Update(int id, ConsoleUpdateDTO consoleUpdateDTO);
    void Delete(int id);

    /// <summary>
    /// Obtener lista de todas las consolas
    /// </summary>
    /// <returns></returns>
    List<ConsoleDTO> GetFiltered(ConsoleFilterDTO filters);

    /// <summary>
    /// Obtenemos lista con los videojuegos más vendidos
    /// </summary>
    /// <returns></returns>
    List<ConsoleDTO> TopSellingConsoles();
}
