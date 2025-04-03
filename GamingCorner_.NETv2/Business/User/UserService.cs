namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;
    private readonly ITransactionRepository _transactionRepository;


    public UserService(IUserRepository userRepository, ITransactionRepository transactionRepository)
    {
        _userRepository = userRepository;
        _transactionRepository = transactionRepository;

    }
    public (UserDTO currentUser, UserDTO sellerUser) PrepareChatUsers(int currentUserId, int productId)
    {
        var currentUser = _userRepository.Get(currentUserId);
        if (currentUser == null)
        {
            throw new KeyNotFoundException($"User with ID {currentUserId} not found.");
        }

        var transaction = _transactionRepository.Get(productId);
        if (transaction == null || transaction.UserId == null)
        {
            throw new KeyNotFoundException($"Transaction for Product with ID {productId} not found or the transaction has no associated user.");
        }

        var sellerUser = _userRepository.Get(transaction.UserId.Value); // Usamos .Value para obtener el valor de int? como int
        if (sellerUser == null)
        {
            throw new KeyNotFoundException($"Seller with ID {transaction.UserId} not found.");
        }

        return (currentUser, sellerUser);
    }

    public List<UserDTO> GetAll()
    {
        var users = _userRepository.GetAll();
        return users;
    }

    public UserDTO Get(int id)
    {
        var user = _userRepository.Get(id);
        return user;
    }

    public List<TransactionDTO> GetTransactionsByUser(int id)
    {
        var transactions = _userRepository.GetTransactionsByUser(id);

        if (transactions == null || !transactions.Any())
        {
            return null;
        }

        return transactions.Select(v => new TransactionDTO
        {
            TransactionId = v.TransactionId,
            VideogameId = v.VideogameId,
            ConsoleId = v.ConsoleId,
            ProductId = v.ProductId,
            Type = v.Type,
            Date = v.Date,
        }).ToList();
    }


    public void Add(UserCreateDTO userCreateDTO)
    {
        var user = new User();
        var mappedUser = user.mapFromCreateDto(userCreateDTO);
        _userRepository.Add(mappedUser);
    }

    public void Update(int id, UserUpdateDTO userUpdateDTO)
    {
        var userDto = _userRepository.Get(id);
        if (userDto == null)
        {
            throw new KeyNotFoundException($"User con Id {id} no encontrada.");
        }

        var user = userDto.ToUser();
        user.Name = userUpdateDTO.Name;
        user.Address = userUpdateDTO.Address;
        user.Email = userUpdateDTO.Email;
        user.Password = userUpdateDTO.Password;
        user.PhoneNumber = userUpdateDTO.PhoneNumber;
        _userRepository.Update(user);
    }

    public void Delete(int id)
    {
        _userRepository.Delete(id);
    }

    public UserDTO Login(string email, string password)
    {
        var user = _userRepository.Login(email, password);
        return user;
    }
}





