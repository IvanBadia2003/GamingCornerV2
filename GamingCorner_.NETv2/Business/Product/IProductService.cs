using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingCorner.Models;

namespace GamingCorner.Business
{
    public interface IProductService
    {
        /// <summary>
        /// Obtener todos los productos
        /// </summary>
        /// <returns></returns>
        List<ProductDTOBase> GetAll();

        /// <summary>
        /// Añadir un producto
        /// </summary>
        /// <param name="productCreateDTO"></param>
        void Add(ProductDTOBase productCreateDTO);

        /// <summary>
        /// Obtener un producto por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductDTOBase Get(int id);

        /// <summary>
        /// Obtener productos similares
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<ProductDTOBase> GetSimilarProducts(int id);



        /// <summary>
        /// Actualizar un producto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productUpdateDTO"></param>
        void Update(int id, ProductDTOBase productUpdateDTO);

        /// <summary>
        /// Eliminar un producto
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Obtener productos compatibles por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        List<ProductDTOBase> GetCompatibleProducts(int id);



    }
}
