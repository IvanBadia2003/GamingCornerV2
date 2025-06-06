
using GamingCorner.Models;

namespace GamingCorner.Data
{
    public interface IProductEFRepository
    {
        /// <summary>
        /// Obtener todos los productos 
        /// </summary>
        List<ProductDTOBase> GetAll();

        /// <summary>
        /// Añadir un producto
        /// </summary>
        /// <param name="product"></param>
        Product Add(Product product);

        /// <summary>
        /// Obtener un producto por ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Product Get(int id);

        /// <summary>
        /// Obtener un productos similares 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Product> GetSimilarProducts(int id);
        

        /// <summary>
        /// Obtener una lista de productos compatibles
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Product> GetcompatibleProducts(int id);

        /// <summary>
        /// Actualizar un producto
        /// </summary>
        /// <param name="product"></param>
        void Update(Product product);

        /// <summary>
        /// Eliminar un producto 
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Aumentar las ventas
        /// </summary>
        /// <param name="productId"></param>
        void IncreaseSales(int productId);

        /// <summary>
        /// Resta el stock
        /// </summary>
        /// <param name="productId"></param>
        void DecreaseStock(int productId);

    }
}
