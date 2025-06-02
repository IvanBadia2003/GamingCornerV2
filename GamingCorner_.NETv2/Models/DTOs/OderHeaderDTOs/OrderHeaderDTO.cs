using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCorner.Models
{
    public class OrderHeaderDTO
    {
        /// <summary>
        /// ID del producto
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ventas del producto
        /// </summary>
        public int Total { get; set; }
        public int? UserId { get; set; }
        public DateTime Fecha { get; set; }

        public OrderHeader ToOrderHeader()
        {
            return new OrderHeader
            {
                UserId = this.UserId,
                Total = this.Total,
                Fecha = this.Fecha,
                Id = this.Id
               
            };
        }
    }
}
