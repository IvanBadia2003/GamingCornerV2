using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;


public class VideogameCreateDTO
{    
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

    //public int PlatformId { get; set; }
    
    /// <summary>
    /// Géneros que tiene el juego
    /// </summary>
    public List<int> GenderId { get; set; }
    
    /// <summary>
    /// Producto al que pertenece el juego
    /// </summary>
    public int ProductId{ get; set; }
    
    /// <summary>
    /// Plataforma que tiene el juego
    /// </summary>
    public int PlatformId { get; set; }


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

    public string? Main { get; set; }
    public string? Background { get; set; }
    public string? Content1 { get; set; }
    public string? Content2 { get; set; }
    public string? Content3 { get; set; }
    public string? Content4 { get; set; }


}