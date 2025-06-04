using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingCorner.Models.Enums.RolEnums;

namespace GamingCorner.Models
{
    public class OrderLineDTO
    {
        public int Id { get; set; }
        public int OrderHeaderId { get; set; }
        public int ProductId { get; set; }

        public decimal Price { get; set; }
        public string? ProductType { get; set; }
        public string? DigitalCode { get; set; }
        public DateTime CreatedAt { get; set; }

        public OrderLine ToOrderLine()
        {
            return new OrderLine(
                this.OrderHeaderId,
                this.ProductId,
                this.Price,
                this.ProductType,
                this.DigitalCode
            );
        }
    }
}
