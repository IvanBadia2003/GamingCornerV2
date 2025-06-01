using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using GamingCorner.Models.Enums.SystemEnum;

namespace GamingCorner.Models;

public class PlatformDTO
{
    [Required]
    public int PlatformId { get; set; }

    [Required]
    public string? Name { get; set; }

    public SystemEnum System { get; set; }

    public Platform ToPlatform()
    {
        return new Platform
        {
            PlatformId = this.PlatformId,
            Name = this.Name,
            System = this.System,
        };
    }

}