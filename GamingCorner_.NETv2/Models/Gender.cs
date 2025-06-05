using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Gender
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GenderId { get; set; }
    

    public string? Name { get; set; }


    // public List<Videogame> Videogames { get; set; }

    public Gender() { }

    public Gender(string backgroundImg, string name, string characterImg)
    {
        Name = name;
    }


    public Gender mapFromCreateDto(GenderCreateDTO genderCreateDTO)
    {
        if (genderCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(genderCreateDTO));
        }

        var gender = new Gender
        {
           Name = genderCreateDTO.Name,
        };

        return gender;
    }
}