using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingCorner.Models.Enums.RolEnums;

namespace GamingCorner.Models
{
    public class CreateOrderLineDTO
    {
        public int OrderHeaderId { get; set; }
        public int ProductId { get; set; }

        public decimal Price { get; set; }
        public string? ProductType { get; set; }
        public string? DigitalCode { get; set; }

        public static OrderLine ToOrderLineEntite(CreateOrderLineDTO dto)
        {
            return new OrderLine
            {

                DigitalCode = dto.DigitalCode,
                OrderHeaderId = dto.OrderHeaderId,
                Price = dto.Price,
                ProductId = dto.ProductId, 
                ProductType = dto.ProductType,
                

            };
        }
    }
}
