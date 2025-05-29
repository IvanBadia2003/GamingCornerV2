using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingCorner.Models;
using GamingCorner.Models.DTOs.ProductDTOs;
using Microsoft.EntityFrameworkCore;

namespace GamingCorner.Data
{
    public class ProductEFRepository : IProductEFRepository
    {
        private readonly GamingCornerContext _context;

        public ProductEFRepository(GamingCornerContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Obtener todos los productos
        /// </summary>
        /// <returns></returns>
        public List<ProductDTOBase> GetAll()
        {

            // Obtenemos todos los productos
            var products = _context.Products.ToList();

            // Si no está vacío
            if (products != null)
            {
                // Mapeamos las propiedades al DTO
                var productDto = products.Select(v => new ProductDTOBase
                {
                    Id = v.Id
                }).ToList();

                // Devolvemos la lista mapeada
                return productDto;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Añadir un producto
        /// </summary>
        /// <param name="product"></param>
        public Product Add(Product product)
        {
            // Añadimos el producto
            _context.Products.Add(product);

            // Guardamos
            SaveChanges();

            return product;
        }


        /// <summary>
        /// Obtener un producto por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product Get(int id)
        {
            // Obtenemos el producto por ID incluyendo el videojuego y la consola
            var product = _context.Products
                .Include(p => p.Console)
                .Include(p => p.Videogame)
                    .ThenInclude(v => v.VideogameGenders)
                        .ThenInclude(vg => vg.Gender)
                .Include(p => p.Platform)
                .FirstOrDefault(p => p.Id == id);

            return product;
        }

        /// <summary>
        /// Obtener un productos similares 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Product> IProductEFRepository.GetSimilarProducts(int id)
        {
            List<Product> similarProducts = new List<Product>();

            // Obtenemos el producto por ID incluyendo el videojuego y la consola
            var product = _context.Products
                .Include(p => p.Console)
                .Include(p => p.Videogame)
                    .ThenInclude(v => v.VideogameGenders)
                .FirstOrDefault(p => p.Id == id);


            if (product.Videogame != null)
            {
                var gendersIds = product.Videogame.VideogameGenders.Select(vg => vg.GenderId).ToList();

                similarProducts = _context.Products.Include(p => p.Videogame).ThenInclude(v => v.VideogameGenders).ThenInclude(vg => vg.Gender).Where(p => p.Id != id && p.Videogame.VideogameGenders.Any(vg => gendersIds.Contains(vg.GenderId))).Take(4).ToList();
                return similarProducts;
            }
            
            if (product.Console != null)
            {
                // AQUI ESTARIA BIEN FILTRAR POR LA GENERACION
                similarProducts = _context.Products.Include(p => p.Console).Where(p => p.Console.Brand == "Nintendo").ToList();
                return similarProducts;
            }

            throw new KeyNotFoundException("Producto no encontrado");

        }


        /// <summary>
        /// Actualizar un producto
        /// </summary>
        /// <param name="product"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public void Update(Product product)
        {
            // Buscamos el producto por ID
            var existingProduct = _context.Products.Find(product.Id);

            // Si existe
            if (existingProduct != null)
            {
                // Verifica si el nuevo PlatformId existe en la tabla Platforms
                //if (!_context.Platforms.Any(p => p.PlatformId == videogame.PlatformId))
                //{
                //    throw new Exception("El PlatformId proporcionado no existe.");
                //}

                // Asegúrate de que el PlatformId no sea NULL
                //if (videogame.PlatformId == null)
                //{
                //    throw new Exception("El PlatformId no puede ser nulo.");
                //}

                // Actualizamos las propiedades
                _context.Entry(existingProduct).CurrentValues.SetValues(product);

                // Guardamos
                _context.SaveChanges();
            }
            // Si no existe 
            else
            {
                throw new KeyNotFoundException("Producto no encontrado");
            }
        }

        /// <summary>
        /// Eliminar un prodcuto
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public void Delete(int id)
        {
            // Obtenemos el producto por ID
            var product = _context.Products.FirstOrDefault(v => v.Id == id);

            // Si no existe lanzamos excepción
            if (product == null)
                throw new KeyNotFoundException("Producto no encontrado.");

            // Eliminamos el producto
            _context.Products.Remove(product);

            //Guardamos
            SaveChanges();


        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
