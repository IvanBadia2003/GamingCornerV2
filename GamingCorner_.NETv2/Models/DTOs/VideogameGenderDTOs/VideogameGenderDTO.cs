using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;


public class VideogameGenderDTO
{
    public int GenderId { get; set; }
    public int VideogameId { get; set; }
    
    public VideogameGender ToVideogameGender()
    {
        return new VideogameGender
        {
            GenderId = this.GenderId,
            VideogameId = this.VideogameId
        };
    }
}