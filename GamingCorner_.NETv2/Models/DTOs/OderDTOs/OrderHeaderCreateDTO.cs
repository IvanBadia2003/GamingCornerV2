using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingCorner.Models.Enums.RolEnums;

namespace GamingCorner.Models.DTOs.ProductDTOs
{
    public class OrderHeaderCreateDTO
    {
        public int UserId { get; set; }
        public string? BillingAddress { get; set; }
        public DateTime CreatedAt { get; set; }
        public int PaymentMethod { get; set; }
        public OrderHeader ToOrderHeaderEntite()
        {
            return new OrderHeader
            {
                UserId = this.UserId,
                BillingAddress = this.BillingAddress,
                CreatedAt = this.CreatedAt,
                PaymentMethod = (PaymentMethodEnum)this.PaymentMethod
            };
        }
    }
}
