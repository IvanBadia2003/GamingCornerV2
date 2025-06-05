using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingCorner.Models.Enums.SystemEnum;

namespace GamingCorner.Models
{
    public class OrderLine
    {
        public int Id { get; set; }

        // Claves foráneas
        public int OrderHeaderId { get; set; }
        public OrderHeader OrderHeader { get; set; } = null!;

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public decimal Price { get; set; }

        public string? ProductType { get; set; }

        public string? DigitalCode { get; set; }

        // Auditoría (opcional)
        public DateTime CreatedAt { get; set; }

        public OrderLine() { }

        public OrderLine(int orderHeaderId, int productId, decimal price, string? productType = null, string? digitalCode = null)
        {
            OrderHeaderId = orderHeaderId;
            ProductId = productId;
            Price = price;
            ProductType = productType;
            DigitalCode = digitalCode;
            CreatedAt = DateTime.UtcNow;
        }

        public OrderLineDTO ToOrderLineDTO()
        {
            return new OrderLineDTO
            {
                Id = this.Id,
                OrderHeaderId = this.OrderHeaderId,
                ProductId = this.ProductId,
                Price = this.Price,
                ProductType = this.ProductType,
                DigitalCode = this.DigitalCode,
                CreatedAt = this.CreatedAt,
                ProductName = this.Product.Videogame != null ? this.Product.Videogame.Name : this.Product.Console != null ? this.Product.Console.Name : this.Product.SecondHandProduct.Name,
                ProductPlatform = this.Product.Platform.Name,
                ProductSystem = this.Product.Platform.System.ToString()

            };
        }

        public static string GenerateAlphanumericCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }


}
