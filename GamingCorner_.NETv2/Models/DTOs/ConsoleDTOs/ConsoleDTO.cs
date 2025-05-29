using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class ConsoleDTO
{

    /// <summary>
    /// ID del producto
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// ID de la consola
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nombre de la consola
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Descripción de la consola 
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Cantidad de stock de la consola
    /// </summary>
    public int Stock { get; set; }

    /// <summary>
    /// Porcentaje de descuento sobre el precio de la consola
    /// </summary>
    public int Discount { get; set; }

    /// <summary>
    /// Precio de la consola
    /// </summary>
    public decimal Price { get; set; }

    //public int PlatformId { get; set; }
    //public int GenderId { get; set; }

    /// <summary>
    /// Imagen Principal de la consola
    /// </summary>
    public string? PrincipalImageURL { get; set; }


    /// <summary>
    /// Especificaciones de la consola
    /// </summary>
    public string? Specifications { get; set; }

    
    //public int PlatformId { get; set; }        


    /// <summary>
    /// Fecha de lanzamiento de la consola
    /// </summary>
    public DateTime ReleaseDate { get; set; }

    /// <summary>
    /// Marca de la consola (Sony, Microsoft, Nintendo...)
    /// </summary>
    public string Brand { get; set; }
    public int? Sales { get; set; }

    /// <summary>
    /// Generacion de la consola
    /// </summary>
    public string Generation { get; set; }

    /// <summary>
    /// Colores que tiene la consola
    /// </summary>
    public string Colors { get; set; }

    /// <summary>
    /// Servicios que ofrece la consola
    /// </summary>
    public string Services { get; set; }

    /// <summary>
    /// Ventas de la consola
    /// </summary>

    // public List<ConsoleDTO> Consoles { get; set; }Ç


    public Console ToConsole()
    {
        return new Console
        {
            Id = this.Id,
            ProductId = this.ProductId,
            Name = this.Name,
            Description = this.Description,
            Stock = this.Stock,
            Discount = this.Discount,
            Price = this.Price,
            PrincipalImageURL = this.PrincipalImageURL,
            Specifications = this.Specifications,
            ReleaseDate = this.ReleaseDate,
            Brand = this.Brand,
            Colors = this.Colors,
            Services = this.Services,   
            Generation = this.Generation,

        };
    }
}