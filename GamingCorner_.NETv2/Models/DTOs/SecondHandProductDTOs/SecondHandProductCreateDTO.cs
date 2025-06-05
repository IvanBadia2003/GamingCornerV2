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

    /// <summary>
    /// Fecha de lanzamiento del producto de segunda mano
    /// </summary>
    public DateTime ReleaseDate { get; set; }

    /// <summary>
    /// Id del usario
    /// </summary>
    public int UserId { get; set; }

    public string? Main { get; set; }
    public string? Content1 { get; set; }
    public string? Content2 { get; set; }
    public string? Content3 { get; set; }
    public string? Content4 { get; set; }

}