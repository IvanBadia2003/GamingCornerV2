using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace GamingCorner.Models.DTOs.ReviewDTOs
{
    public class ReviewCreateDTO
    {

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
        public int ProductId { get; set; }

        /// <summary>
        /// Id del usuario que hace la review
        /// </summary>
        public int UserId { get; set; }



        public Review ToReview()
        {
            return new Review
            {
              Comment = this.Comment,
              Rating = this.Rating,
              ProductId = this.ProductId,
              UserId = this.UserId   

            };
        }
    }
}
