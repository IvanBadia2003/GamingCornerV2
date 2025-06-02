using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using GamingCorner.Models.Enums.RolEnums;
using GamingCorner.Models.Enums.UserStateEnum;

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

    public RolEnum Rol { get; set; }
    
    public UserStateEnum State { get; set; }

    public DateTime DateCreated { get; set; }

    public string Avatar { get; set; }


    public List<Basket> Baskets { get; set; } = new List<Basket>();
    public List<Favourite> Favourites { get; set; } = new List<Favourite>();
    // public List<Console_> Consoles { get; set; } = new List<Console_>();

    //public List<Videogame> Videogames { get; set; } = new List<Videogame>();
    // public List<Transaction> Transactions { get; set; }


    public User() { }

    public User(string name,string address, string email,string password,string phoneNumber,bool admin, RolEnum rol, UserStateEnum state, DateTime dateCreated, string avatar)
    {
        Name = name;
        Address = address;
        Email = email;
        Password = password;
        PhoneNumber = phoneNumber;
        Admin = admin;
        Rol = rol;
        State = state;
        DateCreated = dateCreated;
        Avatar = avatar;
    }

    public UserDTO ToUserDTO()
    {
        return new UserDTO
        {
            UserId = this.UserId,
            Name = this.Name,
            Address = this.Address,
            Email = this.Email,
            Password = this.Password,
            PhoneNumber = this.PhoneNumber,
            Admin = this.Admin,
            Rol = this.Rol,
            DateCreated = this.DateCreated,
            State = this.State,
            Avatar = this.Avatar

        };
    }
}
