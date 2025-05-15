
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
        void Add(Product product);

        /// <summary>
        /// Obtener un producto por ID 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductDTOBase Get(int id);

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
    }
}
