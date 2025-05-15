namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface IConsoleService
{
    List<ConsoleDTO> GetAll();
    // GetAll(int id);
    void Add(int product, ConsoleCreateDTO consoleCreateDTO);
    ConsoleDTO Get(int id);
    void Update(int id, ConsoleUpdateDTO consoleUpdateDTO);
    void Delete(int id);
}
