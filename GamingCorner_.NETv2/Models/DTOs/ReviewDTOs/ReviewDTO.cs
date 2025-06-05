using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCorner.Models.DTOs.ReviewDTOs
{
    public class ReviewDTO
    {
        /// <summary>
        /// Id de la review
        /// </summary>
        /// 
        public int Id { get; set; }

        /// <summary>
        /// Comentario de la review
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Nota de la review
        /// </summary>
        public double Rating { get; set; }

        /// <summary>
        /// Id del producto de la review
        /// </summary>
        public string ProductName{ get; set; }


        /// <summary>
        /// Id del usuario que hace la review
        /// </summary>
        public string UserName { get; set; }


        /// <summary>
        /// Fecha de la review
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}
