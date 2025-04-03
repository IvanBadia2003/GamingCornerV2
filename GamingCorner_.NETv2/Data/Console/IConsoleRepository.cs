using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IConsoleRepository
{
    List<ConsoleDTO> GetAll();
    // GetAll(int id);
    void Add(Console_ console);
    ConsoleDTO Get(int id);
    void Update(Console_ console);
    void Delete(int id);

    // Task AddUserAsync (User user);
    // Task<User>GetUserAsync(int id);

}