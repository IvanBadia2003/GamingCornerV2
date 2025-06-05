using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;


public class VideogameGenderCreateDTO
{    
    public int GenderId { get; set; }
    public int VideogameId { get; set; }
}