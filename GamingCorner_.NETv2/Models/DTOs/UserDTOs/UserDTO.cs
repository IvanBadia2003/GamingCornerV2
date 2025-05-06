using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

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

    public List<VideogameDTO> Videogames { get; set; }
    public List<TransactionDTO> Transactions { get; set; }

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

        };
    }
}