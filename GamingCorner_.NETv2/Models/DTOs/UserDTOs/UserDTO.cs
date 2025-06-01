using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using GamingCorner.Models.Enums.RolEnums;
using GamingCorner.Models.Enums.UserStateEnum;

namespace GamingCorner.Models;

public class UserDTO
{
    [Key]
    public int UserId { get; set; }

    [Required]
    public string? Name { get; set; }

    public string? Address { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    public string PhoneNumber { get; set; }

    public bool Admin { get; set; }

    //public List<VideogameDTO> Videogames { get; set; }
    public RolEnum Rol { get; set; }
    public UserStateEnum State { get; set; }
    public DateTime DateCreated { get; set; }

    public string Avatar { get; set; }


    public User ToUser()
    {
        return new User
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