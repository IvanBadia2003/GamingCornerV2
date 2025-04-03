using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;

namespace GamingCorner.Models;

public class UserCreateDTO
{


    [Required]
    public string? Name { get; set; }
    
    [Required]
    public string? Address { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    [Required]
    public bool Admin { get; set; }
    
    [Required]
    public string? phoneNumber { get; set; }
 

}