using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCorner.Models.DTOs.ProductDTOs
{
    public class OrderHeaderCreateDTO
    {
       public int Id { get; set; }

        /// <summary>
        /// Ventas del producto
        /// </summary>
        public int Total { get; set; }
        public int? UserId { get; set; }
        public DateTime Fecha { get; set; }
    }
}
