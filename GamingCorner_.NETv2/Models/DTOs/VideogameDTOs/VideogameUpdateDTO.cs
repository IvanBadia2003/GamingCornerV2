using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace GamingCorner.Models;

public class VideogameUpdateDTO
{
    /// <summary>
    /// Nuevo Precio
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Nuevo Stock
    /// </summary>
    public int Stock { get; set; }

}