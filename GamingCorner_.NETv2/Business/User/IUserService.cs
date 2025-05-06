namespace GamingCorner.Business;

using GamingCorner.Business;
using GamingCorner.Models;

public interface IUserService
{
    List<UserDTO> GetAll();
    // GetAll(int id);
    void Add(UserCreateDTO userCreateDTO);
    UserDTO Get(int id);
    List<TransactionDTO> GetTransactionsByUser(int id);
    void Update(int id, UserUpdateDTO userUpdateDTO);
    void Delete(int id);
    UserDTO Login(string email, string password);

    (UserDTO currentUser, UserDTO sellerUser) PrepareChatUsers(int currentUserId, int productId);

}
