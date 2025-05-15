using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IConsoleRepository
{
    List<ConsoleDTO> GetAll();
    // GetAll(int id);
    void Add(Models.Console console);
    ConsoleDTO Get(int id);
    void Update(Models.Console console);
    void Delete(int id);



}