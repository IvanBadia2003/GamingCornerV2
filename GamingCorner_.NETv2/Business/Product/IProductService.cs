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
    }
}
