using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;

using GamingCorner.Models.DTOs.ReviewDTOs;

namespace GamingCorner.Business
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewEFRepository _reviewRepository;

        public ReviewService(IReviewEFRepository repository)
        {
            _reviewRepository = repository;
        }

        /// <summary>
        /// Obtiene todas las reviews, incluyendo datos de producto, usuario y subentidades.
        /// </summary>
        public List<ReviewDTO> GetAll()
        {
            try
            {
                 List<Review> entities = _reviewRepository.GetAll();



                return entities.Select(r => r.ToReviewDTO()).ToList();
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException( ex.Message);

            }
            catch (Exception ex)
            {
                // Aquí podrían ir logs antes de lanzar la excepción
                throw new Exception("Error al obtener todas las reviews.", ex);
            }
        }
        
        public List<VideogameDTO> GetTopRatedVideogames()
        {
            try
            {
                 List<Videogame> entities = _reviewRepository.GetTopRatedVideogames();



                return entities.Select(r => r.mapToReadDto()).ToList();
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException( ex.Message);

            }
            catch (Exception ex)
            {
                // Aquí podrían ir logs antes de lanzar la excepción
                throw new Exception("Error al obtener todas las reviews.", ex);
            }
        }

        /// <summary>
        /// Obtiene las reviews filtradas por Id de usuario.
        /// </summary>
        public List<ReviewDTO> GetByUserId(int userId)
        {
            if (userId <= 0)
                throw new Exception("El userId debe ser un número positivo.");

            try
            {
                var lista = _reviewRepository.GetByUserId(userId);
                if (lista == null || lista.Count == 0)
                    throw new Exception($"No se encontraron reviews para el usuario {userId}.");
                return lista.Select(r => r.ToReviewDTO()).ToList();
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error al obtener las reviews del usuario con Id {userId}.", ex);
            }
        }

        /// <summary>
        /// Obtiene las reviews filtradas por Id de producto.
        /// </summary>
        public List<ReviewDTO> GetByProductId(int productId)
        {
            if (productId <= 0)
                throw new Exception("El productId debe ser un número positivo.");

            try
            {
                var lista = _reviewRepository.GetByProductId(productId);
                 if (lista == null || lista.Count == 0)
                     throw new Exception($"No se encontraron reviews para el producto {productId}.");
                return lista.Select(r => r.ToReviewDTO()).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las reviews del producto con Id {productId}.", ex);
            }
        }

        /// <summary>
        /// Actualiza una review existente. Lanza excepción si el modelo no es válido.
        /// </summary>
        public void Create(ReviewCreateDTO review)
        {
            //Mapeo la reseña
            var mappedReview = review.ToReview();

            //Creo la reseña
            _reviewRepository.Create(mappedReview);
        }

        /// <summary>
        /// Elimina una review por Id. Si no existe, no lanza error, pero si falla la capa de acceso a datos, se captura.
        /// </summary>
        public void Delete(int id)
        {
            if (id <= 0)
                throw new Exception("El Id de la review a eliminar no es válido.");

            try
            {
                _reviewRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al eliminar la review con Id {id}.", ex);
            }
        }

        public double AverageRating(int productId)
        {
            return _reviewRepository.AverageRating(productId);
        }
    }
}
