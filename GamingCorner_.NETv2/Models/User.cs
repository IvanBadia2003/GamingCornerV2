using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int UserId { get; set; }

    [Required]
    public string? Name { get; set; }
    
    public string? Address { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    public string? PhoneNumber { get; set; }

    public bool Admin { get; set; }


    // public List<Console_> Consoles { get; set; } = new List<Console_>();

    public List<Videogame> Videogames { get; set; } = new List<Videogame>();
   // public List<Transaction> Transactions { get; set; }


    public User() { }

    public User(string name,string address, string email,string password,string phoneNumber,bool admin)
    {
        Name = name;
        Address = address;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        Admin = admin;
    }

    public User mapFromCreateDto(UserCreateDTO userCreateDTO)
    {
        if (userCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(userCreateDTO));
        }

        var user = new User
        {
            Name = userCreateDTO.Name,
            Address = userCreateDTO.Address,
            Email = userCreateDTO.Email,
            Password = userCreateDTO.Password,
            PhoneNumber = userCreateDTO.phoneNumber,
            Admin = userCreateDTO.Admin,
        };

        return user;
    }
}
