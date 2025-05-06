namespace GamingCorner.Data;

using GamingCorner.Models;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using GamingCorner.Data;
using Microsoft.EntityFrameworkCore;

public class UserEFRepository : IUserRepository
{


    private readonly GamingCornerContext _context;

    public UserEFRepository(GamingCornerContext context)
    {

        _context = context;
    }

    public List<UserDTO> GetAll()
    {
        var users = _context.Users
            .Include(v => v.Videogames)
            .ToList();

        if (users != null)
        {
            var userDto = users.Select(u => new UserDTO
            {
                UserId = u.UserId,
                Name = u.Name,
                Address = u.Address,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Password = u.Password,
                Admin = u.Admin,
            }).ToList();
            return userDto;
        }
        else
        {
            return null;
        }
    }

    public void Add(User user)
    {
        _context.Users.Add(user);
        SaveChanges();
    }

    public UserDTO Get(int id)
    {
        var user = _context.Users
            .Include(v => v.Videogames)
            .Where(user => user.UserId == id)
            .FirstOrDefault();

        if (user != null)
        {
            var userDto = new UserDTO
            {
                UserId = user.UserId,
                Name = user.Name,
                Address = user.Address,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Admin = user.Admin,
                // Videogames = user.Videogames.Select(v => new VideogameDTO
                // {
                //     VideogameId = v.VideogameId,
                //     Price = v.Price,
                //     Name = v.Name,
                // }).ToList()
            };
            return userDto;
        }
        else
        {
            return null;
        }
    }

    public List<Transaction> GetTransactionsByUser (int id)
        {
            return _context.Transactions
                           .Where(u => u.UserId == id)
                           .ToList();    
        }

    public void Update(User user)
    {
        var existingUser = _context.Users.Find(user.UserId);

        if (existingUser != null)
        {
            _context.Entry(existingUser).CurrentValues.SetValues(user);
            _context.SaveChanges();
        }
    }

    public void Delete(int id)
    {
        var userDto = Get(id);
        if (userDto == null)
        {
            throw new KeyNotFoundException("User not found.");
        }
        var user = _context.Users.FirstOrDefault(u => u.UserId == id);
        if (user != null)
        {
            _context.Users.Remove(user);
            SaveChanges();
        }

    }

    public UserDTO Login(string email, string password)
    {

        var user = _context.Users
            .Where(user => user.Email == email && user.Password == password)
            .FirstOrDefault();

        if (user != null)
        {
            var userDto = new UserDTO
            {
                UserId = user.UserId,
                Name = user.Name,
                Address = user.Address,
                Email = user.Email,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber,
                Admin = user.Admin,
            };
            return userDto;
        }
        else
        {
            return null;
        }
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void ToBase64(){
        
    }
    public void ToString(){

    }

}
