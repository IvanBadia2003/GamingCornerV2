namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;


public class UserService : IUserService
{

    private readonly IUserRepository _userRepository;


    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;

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





