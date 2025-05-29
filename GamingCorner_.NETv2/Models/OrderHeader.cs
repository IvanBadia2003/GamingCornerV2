using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using GamingCorner.Models.DTOs.ProductDTOs;

namespace GamingCorner.Models;

public class OrderHeader
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
    public int Id { get; set; }
    public User? User { get; set; }

    [ForeignKey("User")]
    public int? UserId { get; set; }
    public int Total { get; set; }
    public DateTime Fecha { get; set; }

    public OrderHeader(){}
    public OrderHeader(User? user, int total, DateTime fecha)
    {
        User = user;
        Total = total;
        Fecha = fecha;
    }
    public OrderHeader mapFromCreateDto(OrderHeaderCreateDTO orderHeaderCreateDTO)
    {
        if (orderHeaderCreateDTO == null)
        {
            // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
            throw new ArgumentNullException(nameof(orderHeaderCreateDTO));
        }

        var orderHeader = new OrderHeader
        {
           UserId = orderHeaderCreateDTO.UserId,
           Total = orderHeaderCreateDTO.Total,
           Fecha = orderHeaderCreateDTO.Fecha,
        };

        return orderHeader;
    }

}