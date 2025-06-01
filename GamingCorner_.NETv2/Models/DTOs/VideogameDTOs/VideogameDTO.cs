using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class VideogameDTO
{
    /// <summary>
    /// ID del producto
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// ID del juego
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nombre del juego
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Pegi del juego
    /// </summary>
    public int Pegi { get; set; }

    /// <summary>
    /// Descripción del juego
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Requisitos Minimos del juego
    /// </summary>
    public string? Requisitos1 { get; set; }

    /// <summary>
    /// Requisitos Recomendados del juego
    /// </summary>
    public string? Requisitos2 { get; set; }

    /// <summary>
    /// Cantidad de stock del juego
    /// </summary>
    public int Stock { get; set; }

    /// <summary>
    /// Porcentaje de descuento sobre el precio del juego
    /// </summary>
    public int Discount { get; set; }

    /// <summary>
    /// Precio del juego
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Plataforma del videojuego
    /// </summary>
    public int PlatformId { get; set; }
    
    /// <summary>
    /// Generos del videojuegos
    /// </summary>
    public List<int> GenderId { get; set; }

    /// <summary>
    /// Imagen Principal del juego
    /// </summary>
    public string? PrincipalImageURL { get; set; }

    /// <summary>
    /// Fecha de lanzamiento del juego
    /// </summary>
    public DateTime ReleaseDate { get; set; }

    /// <summary>
    /// Distribuidor del juego
    /// </summary>
    public string Distributor { get; set; }

    /// <summary>
    /// Desarrollador del juego
    /// </summary>
    public string Developer { get; set; }

    /// <summary>
    /// Ventas del juego
    /// </summary>
    public int? Sales { get; set; }

    public Videogame ToVideogame()
    {
        return new Videogame
        {
            Id = this.Id,
            ProductId = this.ProductId,
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
            PrincipalImageURL = this.PrincipalImageURL
        };
    }
}