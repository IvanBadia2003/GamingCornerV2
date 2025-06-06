
using GamingCorner.Models;

namespace GamingCorner.Data
{
    public interface IReviewEFRepository
    {
        /// <summary>
        /// Obtener todas las reviews
        /// </summary>
        /// <returns></returns>
        List<Review> GetAll();

        /// <summary>
        /// Obtener las review por id de usuario
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<Review> GetByUserId(int userId);

        /// <summary>
        /// Obtener las review por id de producto
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        List<Review> GetByProductId(int productId);

        /// <summary>
        /// Crear una review
        /// </summary>
        /// <param name="review"></param>
        void Create(Review review);

        /// <summary>
        /// Eliminar una review
        /// </summary>
        /// <param name="id"></param>
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
       List<Videogame> GetTopRatedVideogames();
    }
}
