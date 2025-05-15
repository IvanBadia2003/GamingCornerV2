using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;

namespace GamingCorner.Models;

public class SecondHandProductCreateDTO
{



    /// <summary>
    /// ID del producto de segunda mano
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Nombre del producto de segunda mano
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Descripción del producto de segunda mano
    /// </summary>
    public string Description { get; set; }


    /// <summary>
    /// Cantidad de stock del producto de segunda mano
    /// </summary>
    public int Stock { get; set; }

    /// <summary>
    /// Porcentaje de descuento sobre el precio del producto de segunda mano
    /// </summary>
    public int Discount { get; set; }

    /// <summary>
    /// Precio del producto de segunda mano
    /// </summary>
    public decimal Price { get; set; }

    //public int PlatformId { get; set; }
    //public int GenderId { get; set; }

    /// <summary>
    /// Imagen Principal del producto de segunda mano
    /// </summary>
    public string? PrincipalImageURL { get; set; }

    /// <summary>
    /// Fecha de lanzamiento del producto de segunda mano
    /// </summary>
    public DateTime ReleaseDate { get; set; }

    /// <summary>
    /// Está revisado el producto de segunda mano
    /// </summary>
    public bool isChecked{ get; set; }


}