using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCorner.Models
{
    public class ProductDTOBase
    {
        /// <summary>
        /// ID del producto
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ventas del producto
        /// </summary>
        public int? Sales { get; set; }
        
        /// <summary>
        /// Plataforma del producto
        /// </summary>
        public int? PlatformId { get; set; }
        
        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string? Name{ get; set; }
        
        /// <summary>
        /// Precio del producto
        /// </summary>
        public decimal? Price{ get; set; }
        
        /// <summary>
        /// Descuento del producto
        /// </summary>
        public int? Discount{ get; set; }
        
        public Platform? Platform { get; set; }

        public Product ToProduct()
        {
            return new Product
            {
                Platform = this.Platform,
                Sales = this.Sales,
                Id = this.Id
               
            };
        }
    }
}
