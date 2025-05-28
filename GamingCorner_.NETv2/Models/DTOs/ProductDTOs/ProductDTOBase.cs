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
        public int? PlatformId { get; set; }

        public Product ToProduct()
        {
            return new Product
            {
                Id = this.Id,
                Sales = this.Sales, 
                PlatformId = this.PlatformId 
               
            };
        }
    }
}
