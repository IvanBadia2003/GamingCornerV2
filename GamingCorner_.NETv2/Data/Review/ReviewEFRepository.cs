using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingCorner.Models;
using Microsoft.EntityFrameworkCore;

namespace GamingCorner.Data
{
    public class ReviewEFRepository : IReviewEFRepository
    {
        private readonly GamingCornerContext _context;

        public ReviewEFRepository(GamingCornerContext context)
        {
            _context = context;
        }

        public List<Review> GetAll()
        {
            var entities = _context.Reviews
                .Include(r => r.Product)
                    .ThenInclude(p => p.Videogame)
                .Include(r => r.Product)
                    .ThenInclude(p => p.Console)
                .Include(r => r.User)
                .AsSplitQuery()
                .ToList();

            if (entities.Count == 0)
                throw new KeyNotFoundException("Reseñas no encontradas");

            return entities;

        }

        public List<Review> GetByUserId(int userId)
        {
            return _context.Reviews
                .Where(r => r.UserId == userId)
                .Include(r => r.Product)
                    .ThenInclude(p => p.Videogame)
                .Include(r => r.Product)
                    .ThenInclude(p => p.Console)
                .Include(r => r.Product)
                    .ThenInclude(p => p.SecondHandProduct)
                .Include(r => r.User)
                .AsSplitQuery()
                .ToList();
        }

        public List<Review> GetByProductId(int productId)
        {
            return _context.Reviews
                .Where(r => r.ProductId == productId)
                .Include(r => r.Product)
                    .ThenInclude(p => p.Videogame)
                .Include(r => r.Product)
                    .ThenInclude(p => p.Console)
                .Include(r => r.Product)
                    .ThenInclude(p => p.SecondHandProduct)
                .Include(r => r.User)
                .AsSplitQuery()
                .ToList();
        }

        public void Create(Review review)
        {
            review.CreatedDate = DateTime.Now;
            // Añadimos el producto
            _context.Reviews.Add(review);

            // Guardamos
            SaveChanges();
        }

        public void Delete(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review == null) return;

            _context.Reviews.Remove(review);
            SaveChanges();
        }

        public double AverageRating(int productId)
        {
            return Math.Round(
               _context.Reviews
                   .Where(r => r.ProductId == productId)
                   .Average(r => r.Rating),
               2
           );
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
