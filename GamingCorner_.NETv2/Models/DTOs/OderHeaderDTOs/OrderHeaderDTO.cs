using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingCorner.Models.Enums.RolEnums;

namespace GamingCorner.Models
{
    public class OrderHeaderDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? BillingAddress { get; set; }
        public DateTime CreatedAt { get; set; }
        public string OrderNumber { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public List<OrderLineDTO> OrderLines { get; set; } = new();

        public static OrderHeader ToOrderHeaderEntite(OrderHeaderDTO dto)
        {
            return new OrderHeader
            {
                Id = dto.Id,
                UserId = dto.UserId,
                BillingAddress = dto.BillingAddress,
                CreatedAt = dto.CreatedAt,
                OrderNumber = dto.OrderNumber,
                PaymentMethod = dto.PaymentMethod,
            };
        }
    }
}
