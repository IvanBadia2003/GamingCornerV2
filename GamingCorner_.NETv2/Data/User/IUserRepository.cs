using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IUserRepository
{
    List<UserDTO> GetAll();
    // GetAll(int id);
    void Add(User user);
    User Get(int id);
    UserDTO GetByEmail(string email);
    void Update(User user);
    void Delete(int id);
    UserDTO Login(string email, string password);

    // Task AddUserAsync (User user);
    // Task<User>GetUserAsync(int id);

}