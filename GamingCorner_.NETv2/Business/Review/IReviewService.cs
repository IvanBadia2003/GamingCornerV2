using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingCorner.Models;
using GamingCorner.Models.DTOs.ReviewDTOs;

namespace GamingCorner.Business
{
        public interface IReviewService
        {
            /// <summary>
            /// Obtener todas las reviews.
            /// </summary>
            /// <returns>Lista de reviews completas.</returns>
            List<ReviewDTO> GetAll();

            /// <summary>
            /// Obtener las reviews por Id de usuario.
            /// </summary>
            /// <param name="userId">Id del usuario.</param>
            /// <returns>Lista de reviews de ese usuario.</returns>
            List<ReviewDTO> GetByUserId(int userId);

            /// <summary>
            /// Obtener las reviews por Id de producto.
            /// </summary>
            /// <param name="productId">Id del producto.</param>
            /// <returns>Lista de reviews de ese producto.</returns>
            List<ReviewDTO> GetByProductId(int productId);

            /// <summary>
            /// Crear una review.
            /// </summary>
            /// <param name="review">Objeto Review con datos actualizados (debe incluir Id).</param>
            void Create(ReviewCreateDTO review);

            /// <summary>
            /// Eliminar una review por su Id.
            /// </summary>
            /// <param name="id">Id de la review a eliminar.</param>
            void Delete(int id);


        /// <summary>
        /// Obtenemos la puntuación media del producto
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        double AverageRating(int productId);

        /// <summary>
        /// Obtenemos los 3 juegos mejor valorados
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        List<VideogameDTO> GetTopRatedVideogames();


    }
    
}
