using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IVideogameRepository
{
    List<VideogameDTO> GetAll();
    // GetAll(int id);
    void Add(Videogame videogame);
    VideogameDTO Get(int id);
    void Update(Videogame videogame);
    void Delete(int id);

    // Task AddUserAsync (User user);
    // Task<User>GetUserAsync(int id);

}