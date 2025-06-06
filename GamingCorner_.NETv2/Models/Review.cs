using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingCorner.Models.DTOs.ReviewDTOs;

namespace GamingCorner.Models
{
    public class Review
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public int ProductId { get; set; }

        /// <summary>
        /// Producto de la review
        /// </summary>
        public Product Product { get; set; } = null!;

        /// <summary>
        /// Id del usuario que hace la review
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Usuario que hace la review
        /// </summary>
        public User User { get; set; } = null!;

        /// <summary>
        /// Fecha de la review
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public Review() { }

        public Review(int id, string comment, int rating, int productId, Product product, int userId, User user, DateTime createdDate)
        {
            Id = id;
            Comment = comment;
            Rating = rating;
            ProductId = productId;
            Product = product;
            UserId = userId;
            User = user;
            CreatedDate = createdDate;
        }

        public ReviewDTO ToReviewDTO()
        {
            return new ReviewDTO
            {
                Comment = this.Comment,
                Rating = this.Rating,
                ProductName = this.Product.Videogame != null ? this.Product.Videogame.Name : this.Product.Console.Name,
                UserName = this.User.Name,
                CreatedDate = this.CreatedDate,
                Id = this.Id,
            };
        }
    }

}
