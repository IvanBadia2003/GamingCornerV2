using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace GamingCorner.Models;

public class VideogameUpdateDTO
{
    /// <summary>
    /// Nombre del juego.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Pegi del juego.
    /// </summary>
    public int Pegi { get; set; }

    /// <summary>
    /// Descripción del juego.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Requisitos mínimos del juego.
    /// </summary>
    public string? Requisitos1 { get; set; }

    /// <summary>
    /// Requisitos recomendados del juego.
    /// </summary>
    public string? Requisitos2 { get; set; }

    /// <summary>
    /// Cantidad de stock del juego.
    /// </summary>
    public int Stock { get; set; }

    /// <summary>
    /// Porcentaje de descuento sobre el precio del juego.
    /// </summary>
    public int Discount { get; set; }

    /// <summary>
    /// Precio del juego.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Géneros que tiene el juego.
    /// </summary>
    public List<int> GenderId { get; set; }

    /// <summary>
    /// Plataforma que tiene el juego.
    /// </summary>
    public int PlatformId { get; set; }


    /// <summary>
    /// Fecha de lanzamiento del juego.
    /// </summary>
    public DateTime ReleaseDate { get; set; }

    /// <summary>
    /// Distribuidor del juego.
    /// </summary>
    public string Distributor { get; set; }

    /// <summary>
    /// Desarrollador del juego.
    /// </summary>
    public string Developer { get; set; }

    public Videogame ToVideogame()
    {
        return new Videogame
        {
            Discount = this.Discount,
            Name = this.Name,
            Price = this.Price,
            Description = this.Description,
            Requisitos1 = this.Requisitos1,
            Requisitos2 = this.Requisitos2,
            Stock = this.Stock,
            Pegi = this.Pegi,
            Developer = this.Developer,
            Distributor = this.Distributor,
            ReleaseDate = this.ReleaseDate,
            //PlatformId = this.PlatformId,
            //GenderId = this.GenderId,
        };
    }
}