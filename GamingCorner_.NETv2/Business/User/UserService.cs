namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;
using GamingCorner.Models.Enums.RolEnums;
using GamingCorner.Models.Enums.UserStateEnum;
using System.Data;

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
        User user = _userRepository.Get(id);
        if (user == null)
        {
            throw new KeyNotFoundException($"User con Id {id} no encontrada.");
        }

        return user.ToUserDTO();
    }

    public UserDTO GetByEmail(string email)
    {
        var user = _userRepository.GetByEmail(email);
        return user;
    }


    public void Add(UserCreateDTO userCreateDTO)
    {

        var existingUser = _userRepository.GetByEmail(userCreateDTO.Email);
        
        if (existingUser != null)
        {
            throw new InvalidOperationException("El correo electrónico ya está registrado.");
        }
        
        var user = new User();
        user = userCreateDTO.mapFromCreateDto();
        user.Rol = RolEnum.User;
        user.State = UserStateEnum.Active;
        user.DateCreated = DateTime.Now;
        user.Avatar = "https://cdn-icons-png.flaticon.com/512/149/149071.png";
        _userRepository.Add(user);
    }

    public void Update(int id, UserUpdateDTO userUpdateDTO)
    {
        User user = _userRepository.Get(id);
        if (user == null)
        {
            throw new KeyNotFoundException($"User con Id {id} no encontrada.");
        }

        user.Name = userUpdateDTO.Name;
        user.Address = userUpdateDTO.Address;
        user.Email = userUpdateDTO.Email;
        user.Password = userUpdateDTO.Password;
        user.PhoneNumber = userUpdateDTO.PhoneNumber;
        user.Avatar = userUpdateDTO.Avatar;
        user.Address = userUpdateDTO.Address;
        user.Rol = (RolEnum)userUpdateDTO.Rol;
        user.State = (UserStateEnum)userUpdateDTO.State;
        
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





