using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingCorner.Data;
using GamingCorner.Models;

namespace GamingCorner.Business
{
    public class ProductService : IProductService
    {
        private readonly IProductEFRepository _productEFRepository;


        public ProductService(IProductEFRepository productEFRepository)
        {
            _productEFRepository = productEFRepository;

        }

        /// <summary>
        /// Obtener todos los productos
        /// </summary>
        /// <returns></returns>
        public List<ProductDTOBase> GetAll()
        {
            var products = _productEFRepository.GetAll();
            return products;
        }

        /// <summary>
        /// Obtener un producto por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public ProductDTOBase Get(int id)
        {
            // Se obtiene el producto
            var product = _productEFRepository.Get(id);

            // Si no existe lanzar excepción
            if (product == null)
                throw new KeyNotFoundException($"Producto con el id {id} no encontrado");

            // Devolver producto
            return product;
        }

        /// <summary>
        /// Añadir producto
        /// </summary>
        /// <param name="videogameCreateDTO"></param>
        public void Add(ProductDTOBase videogameCreateDTO)
        {

            var product = new Product();
            // var mappedVideogame = product.mapFromCreateDto(videogameCreateDTO);
            _productEFRepository.Add(product);
        }

        /// <summary>
        /// Actualizar producto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productDTO"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public void Update(int id, ProductDTOBase productDTO)
        {
            var productDto = _productEFRepository.Get(id);
            if (productDTO == null)
            {
                throw new KeyNotFoundException($"Videogame con Id {id} no encontrada.");
            }

            //var product = productDto.ToVideogame();
            //product.Stock = productDTO.Stock;
            //videogame.Available = videogameUpdateDTO.Available;
            //product.Price = productDTO.Price;
            //_productEFRepository.Update(product);
        }

        /// <summary>
        /// Eliminar producto
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            _productEFRepository.Delete(id);
        }
    }
}
