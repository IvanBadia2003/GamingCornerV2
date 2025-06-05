using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class SecondHandProductCreateDTO
{
    
    /// <summary>
    /// Nombre del producto de segunda mano
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Descripci�n del producto de segunda mano
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Precio del producto de segunda mano
    /// </summary>
    public decimal Price { get; set; }

    //public int PlatformId { get; set; }
    //public int GenderId { get; set; }

    /// <summary>
    /// Imagen Principal del producto de segunda mano
    /// </summary>
    public string? ImageURL { get; set; }

    /// <summary>
    /// Fecha de lanzamiento del producto de segunda mano
    /// </summary>
    public DateTime ReleaseDate { get; set; }

    /// <summary>
    /// Id del usario
    /// </summary>
    public int UserId { get; set; }

    public string? MainImage { get; set; }
    public string? BackgroundImage { get; set; }
    public string? ContentImages1 { get; set; }
    public string? ContentImages2 { get; set; }
    public string? ContentImages3 { get; set; }
    public string? ContentImages4 { get; set; }



}