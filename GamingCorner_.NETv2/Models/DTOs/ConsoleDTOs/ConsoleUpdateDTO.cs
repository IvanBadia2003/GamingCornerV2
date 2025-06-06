using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace GamingCorner.Models;

public class ConsoleUpdateDTO
{
    /// <summary>
    /// Nombre de la consola.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Descripción detallada de la consola.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Cantidad disponible en inventario.
    /// </summary>
    public int Stock { get; set; }

    /// <summary>
    /// Porcentaje de descuento aplicado al precio.
    /// </summary>
    public int Discount { get; set; }

    /// <summary>
    /// Precio base de la consola.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Fecha de lanzamiento de la consola.
    /// </summary>
    public DateTime ReleaseDate { get; set; }

    /// <summary>
    /// Especificaciones técnicas de la consola (RAM, CPU, GPU, almacenamiento...).
    /// </summary>
    public string Specifications { get; set; }

    /// <summary>
    /// Marca o fabricante de la consola.
    /// </summary>
    public string Brand { get; set; }

    /// <summary>
    /// Identificador de la plataforma a la que pertenece la consola.
    /// </summary>
    public int PlatformId { get; set; }

    /// <summary>
    /// Generación de la consola (por ejemplo: Octava, Novena...).
    /// </summary>
    public string Generation { get; set; }

    /// <summary>
    /// Colores disponibles para esta consola.
    /// </summary>
    public string Colors { get; set; }

    /// <summary>
    /// Servicios incluidos o compatibles con la consola (ej. Game Pass, PS Plus...).
    /// </summary>
    public string Services { get; set; }


    public Console ToConsole()
    {
        return new Console
        {
            Name = this.Name,
            Description = this.Description,
            Stock = this.Stock,
            Discount = this.Discount,
            Price = this.Price,
            Specifications = this.Specifications,
            ReleaseDate = this.ReleaseDate,
            Brand = this.Brand,
            Colors = this.Colors,
            Services = this.Services,
            Generation = this.Generation,

        };
    }
}