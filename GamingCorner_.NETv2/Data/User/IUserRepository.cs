using GamingCorner.Models;

namespace GamingCorner.Data;

public interface IUserRepository
{
    List<UserDTO> GetAll();
    // GetAll(int id);
    void Add(User user);
    UserDTO Get(int id);
    List<Transaction> GetTransactionsByUser(int id);
    void Update(User user);
    void Delete(int id);
    UserDTO Login(string email, string password);

    // Task AddUserAsync (User user);
    // Task<User>GetUserAsync(int id);

}