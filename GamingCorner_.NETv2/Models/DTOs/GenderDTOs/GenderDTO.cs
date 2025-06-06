using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class GenderDTO
{
    [Required]
    public int GenderId { get; set; }

    [Required]
    public string? Name { get; set; }

}