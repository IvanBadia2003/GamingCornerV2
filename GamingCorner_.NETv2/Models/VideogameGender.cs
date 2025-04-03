// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
// using System.Diagnostics.Contracts;
// using System.Reflection.Metadata;

// namespace GamingCorner.Models;

// public class VideogameGender
// {
//     [ForeignKey("Gender")]
//     public int GenderId { get; set; }


//     [ForeignKey("Videogame")]
//     public int VideogameId { get; set; }

//     public Gender Gender { get; set; }
//     public Videogame Videogame { get; set; }


//     public VideogameGender() { }

//     public VideogameGender(int genderId, int videogameId)
//     {
//         GenderId = genderId;
//         VideogameId = videogameId;
//     }

//     public VideogameGender mapFromCreateDto(VideogameGenderCreateDTO videogameGenderCreateDTO)
//     {
//         if (videogameGenderCreateDTO == null)
//         {
//             // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
//             throw new ArgumentNullException(nameof(videogameGenderCreateDTO));
//         }

//         var videogameGender = new VideogameGender
//         {
//             GenderId = videogameGenderCreateDTO.GenderId,
//             VideogameId = videogameGenderCreateDTO.VideogameId,
//         };

//         return videogameGender;
//     }
// }