using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http;


namespace GamingCorner.Models;

public class UserUpdateDTO
{
    [Required]
    public string? Name { get; set; }
    
    [Required]
    public string? Address { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    public string? PhoneNumber { get; set; }

}