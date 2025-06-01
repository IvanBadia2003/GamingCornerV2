using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using GamingCorner.Models.Enums.OrderDirectionEnum;
using GamingCorner.Models.Enums.RolEnums;
using GamingCorner.Models.Enums.SystemEnum;

namespace GamingCorner.Models;

public class VideogameFilterDto
{
    public int? Platform { get; set; }
    public int? Genre { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public string? Search { get; set; }
    public SystemEnum? System { get; set; }
    public string? OrderBy { get; set; }
    public OrderDirectionEnum? OrderDirection { get; set; } 
}