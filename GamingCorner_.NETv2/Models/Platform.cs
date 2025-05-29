using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Platform
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
    public int PlatformId { get; set; }

    public string? Name { get; set; }
    
    public string? PrincipalImageURL { get; set; }

    public List<Product> products { get; set; } = new List<Product>();

    public Platform() { }
    public Platform mapFromCreateDto(PlatformCreateDTO platformCreateDTO)
    {
        if (platformCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(platformCreateDTO));
        }

        var platform = new Platform
        {
           Name = platformCreateDTO.Name,
           //PrincipalImageURL = platformCreateDTO.PrincipalImageURL,
        };

        return platform;
    }

}