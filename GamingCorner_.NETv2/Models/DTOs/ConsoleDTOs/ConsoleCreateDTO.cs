using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class ConsoleCreateDTO
{


    
    /// <summary>
    /// Nombre de la consola
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Descripci�n de la consola
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
    /// Fecha de lanzamiento de la consola
    /// </summary>
    public DateTime ReleaseDate { get; set; }

    /// <summary>
    /// Especificaciones de la consola
    /// </summary>
    public string Specifications { get; set; }

    /// <summary>
    /// Marca de la consola (Sony, Microsoft, Nintendo...)
    /// </summary>
    public string Brand { get; set; }

    /// <summary>
    /// Plataforma que tiene la consola
    /// </summary>
    public int PlatformId { get; set; }
    
    /// <summary>
    /// Generacion de la consola
    /// </summary>
    public string Generation{ get; set; }
    
    /// <summary>
    /// Colores que tiene la consola
    /// </summary>
    public string Colors{ get; set; }
    
    /// <summary>
    /// Servicios que ofrece la consola
    /// </summary>
    public string Services{ get; set; }

}






 


