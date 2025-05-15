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

    /// <summary>
    /// Ventas de la consola
    /// </summary>
    public int? Sales { get; set; }
    // public List<ConsoleDTO> Consoles { get; set; }Ç


    public Console ToConsole()
    {
        return new Console
        {
            Id = this.Id,
            Name = this.Name,
            Specifications = this.Specifications,
            //PlatformId = this.PlatformId,
            Stock = this.Stock,
            //Available = this.Available,
            Price = this.Price,
            //ImageURL = this.ImageURL
        };
    }
}