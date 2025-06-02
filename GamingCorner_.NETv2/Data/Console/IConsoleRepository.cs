using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IConsoleRepository
{
    List<ConsoleDTO> GetAll();
    // GetAll(int id);
    Models.Console Add(Models.Console console);
    ConsoleDTO Get(int id);
    void Update(Models.Console console);
    void Delete(int id);

    /// <summary>
    /// Obtenemos lista con todas las consolas
    /// </summary>
    /// <returns></returns>
    List<ConsoleDTO> GetFiltered(ConsoleFilterDTO filters);



    /// <summary>
    /// Obtenemos lista con las 3 consolas más vendidas
    /// </summary>
    /// <returns></returns>
    public List<ConsoleDTO> TopSellingConsoles();

}