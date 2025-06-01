using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using GamingCorner.Models.Enums.RolEnums;
using Microsoft.AspNetCore.Http;

namespace GamingCorner.Models;

public class UserCreateDTO
{


    public string? Name { get; set; }
    
    public string? Address { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    public bool Admin { get; set; }
    
    public string? PhoneNumber { get; set; }

    public User mapFromCreateDto()
    {
        //if (userCreateDTO == null)
        //{
        //    // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
        //    throw new ArgumentNullException(nameof(userCreateDTO));
        //}

        var user = new User
        {
            Name = this.Name,
            Address = this.Address,
            Email = this.Email,
            Password = this.Password,
            PhoneNumber = this.PhoneNumber,
            Admin = this.Admin
        };

        return user;
    }
}