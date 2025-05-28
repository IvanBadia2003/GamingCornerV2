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
