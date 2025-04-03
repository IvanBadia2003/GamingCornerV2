using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class VideogameCreateDTO
{
    public string? Name { get; set; }
    public int Pegi { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public string? Requisitos1 { get; set; }
    public string? Requisitos2 { get; set; }
    public int Stock { get; set; }
    public bool Available { get; set; }
    public decimal Price { get; set; }
    public int PlatformId { get; set; }
    public int GenderId { get; set; }
    public string? ImageURL { get; set; }

}