using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using GamingCorner.Models.Enums.RolEnums;
using GamingCorner.Models.Enums.UserStateEnum;
using Microsoft.AspNetCore.Http;


namespace GamingCorner.Models;

public class UserUpdateDTO
{
    [Required]
    public string? Name { get; set; }
    
    public string? Address { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    public string? PhoneNumber { get; set; }

    public int? Rol { get; set; }
    public int? State { get; set; }

    public string Avatar { get; set; }

    public User ToUser()
    {
        return new User
        {
            Name = this.Name,
            Address = this.Address,
            Email = this.Email,
            Password = this.Password,
            PhoneNumber = this.PhoneNumber,
            Rol = (RolEnum)this.Rol,
            State = (UserStateEnum)this.State,
            Avatar = this.Avatar

        };
    }
}