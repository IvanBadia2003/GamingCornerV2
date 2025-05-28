using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class PlatformDTO
{
    [Required]
    public int PlatformId { get; set; }

    [Required]
    public string? Name { get; set; }
    [Required]
    public string? PrincipalImageURL { get; set; }

    public Platform ToPlatform()
    {
        return new Platform
        {
            PlatformId = this.PlatformId,
            Name = this.Name,
            PrincipalImageURL = this.PrincipalImageURL
        };
    }

}