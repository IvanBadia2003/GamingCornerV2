using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Reflection.Metadata;
using GamingCorner.Models.DTOs.ProductDTOs;
using GamingCorner.Models.Enums.RolEnums;

namespace GamingCorner.Models;

public class OrderHeader
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
    public int Id { get; set; }
    public User? User { get; set; }

    [ForeignKey("User")]
    public int? UserId { get; set; }
    public string? BillingAddress { get; set; }
    public DateTime CreatedAt { get; set; }

    public string OrderNumber { get; set; }

    public PaymentMethodEnum PaymentMethod { get; set; }
    public List<OrderLine> OrderLines { get; set; } = new();

    public OrderHeader(){}
    public OrderHeader(int userId, string billingAddress, DateTime createdAt, string orderNumber, PaymentMethodEnum paymentMethod)
    {
        UserId = userId;
        BillingAddress = billingAddress;
        CreatedAt = createdAt;
        OrderNumber = orderNumber;
        PaymentMethod = paymentMethod;
    }
    //public OrderHeader mapFromCreateDto(OrderHeaderCreateDTO orderHeaderCreateDTO)
    //{
    //    if (orderHeaderCreateDTO == null)
    //    {
    //        // Puedes lanzar una excepción aquí o manejar el caso de DTO nulo según tu lógica
    //        throw new ArgumentNullException(nameof(orderHeaderCreateDTO));
    //    }

    //    var orderHeader = new OrderHeader
    //    {
    //       UserId = orderHeaderCreateDTO.UserId,
    //       Total = orderHeaderCreateDTO.Total,
    //       CreatedAt = orderHeaderCreateDTO.CreatedAt,
    //    };

    //    return orderHeader;
    //}

    public OrderHeaderDTO ToOrderHeaderDTO()
    {
        return new OrderHeaderDTO
        {
            Id = this.Id,
            UserId = this.UserId,
            BillingAddress = this.BillingAddress,
            CreatedAt = this.CreatedAt,
            OrderNumber = this.OrderNumber,
            PaymentMethod = this.PaymentMethod,
            OrderLines = this.OrderLines.Select(ol => ol.ToOrderLineDTO()).ToList(),
            TotalPrice = this.OrderLines.Sum(ol => ol.Price)
        };
    }

}