using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class Videogame
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int VideogameId { get; set; }

    public string Name { get; set; }

    public int Pegi { get; set; }
    
    public string? Code { get; set; }

    public string Description { get; set; }

    public int Stock { get; set; }

    public bool Available { get; set; }

    public string? Requisitos1 { get; set; }
    public string? Requisitos2 { get; set; }

    public int PlatformId { get; set; }

    public Platform Platform { get; set; }
    
    public int GenderId { get; set; }

    public Gender Gender { get; set; }
    
    public int? UserId { get; set; }

    public User? User { get; set; }

    public decimal Price { get; set; }

    public string ImageURL { get; set; }
    //public List<Transaction> Transactions { get; set; }

    public Videogame() { }

    public Videogame(string name, int pegi, string description, int stock, bool available, int platformId, int genderId, decimal price, string imageURL, string code, string requisitos1, string requisitos2)
    {
        Name = name;
        Pegi = pegi;
        Code = code;
        Description = description;
        Requisitos1 = requisitos1;
        Requisitos2 = requisitos2;
        Stock = stock;
        Available = available;
        PlatformId = platformId;
        GenderId = genderId;
        Price = price;
        ImageURL = imageURL;
    }

    public Videogame mapFromCreateDto(VideogameCreateDTO videogameCreateDTO)
    {
        if (videogameCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(videogameCreateDTO));
        }

        var videogame = new Videogame
        {
            Name = videogameCreateDTO.Name,
            Pegi = videogameCreateDTO.Pegi,
            Code = videogameCreateDTO.Code,
            Description = videogameCreateDTO.Description,
            Requisitos1 = videogameCreateDTO.Requisitos1,
            Requisitos2 = videogameCreateDTO.Requisitos2,
            Stock = videogameCreateDTO.Stock,
            Available = videogameCreateDTO.Available,
            PlatformId = videogameCreateDTO.PlatformId,
            GenderId = videogameCreateDTO.GenderId,
            Price = videogameCreateDTO.Price,
            ImageURL = videogameCreateDTO.ImageURL
        };

        return videogame;
    }

    // public VideogameDTO MapToDTO()
    // {
    //     var videogameDto = new VideogameDTO
    //     {
    //         VideogameId = this.VideogameId,
    //         Name = this.Name,
    //         Pegi = this.Pegi,
    //         Description = this.Description,
    //         Stock = this.Stock,
    //         Available = this.Available,
    //         Platform = this.Platform,
    //         Price = this.Price,
    //         ImageURL = this.ImageURL,
    //         ListVideogameGender = this.ListVideogameGender.Select(g => new VideogameGenderDTO
    //         {
    //             GenderId = g.GenderId,
    //             VideogameId = g.VideogameId
    //         }).ToList()
    //     };
    //     return videogameDto;
    // }
}