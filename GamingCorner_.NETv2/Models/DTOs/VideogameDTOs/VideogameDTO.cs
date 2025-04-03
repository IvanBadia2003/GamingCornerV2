using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class VideogameDTO
{
    [Key]
    public int VideogameId { get; set; }
    public string? Name { get; set; }
    public int Pegi { get; set; }  
    public string? Code { get; set; }
    public string? Description { get; set; }
    public int UserId { get; set; }
    public string? Requisitos1 { get; set; }
    public string? Requisitos2 { get; set; }
    public int Stock { get; set; }
    public bool Available { get; set; }
    public decimal Price { get; set; }
    public int PlatformId { get; set; }
    public int GenderId { get; set; }
    public string? ImageURL { get; set; }
 

     public Videogame ToVideogame()
    {
        return new Videogame
        {
            VideogameId = this.VideogameId,
            Name = this.Name,
            Price = this.Price,
            Code = this.Code,
            Description = this.Description,
            Requisitos1 = this.Requisitos1,
            Requisitos2 = this.Requisitos2,
            Stock = this.Stock,
            Available = this.Available,
            Pegi = this.Pegi,
            PlatformId = this.PlatformId,
            GenderId = this.GenderId,
            ImageURL = this.ImageURL
        };
    }
}