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
        public void Add(Product product)
        {
            // Añadimos el producto
            _context.Products.Add(product);

            // Guardamos
            SaveChanges();
        }


        /// <summary>
        /// Obtener un producto por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductDTOBase Get(int id)
        {
            // Obtenemos el producto por ID incluyendo el videojuego y la consola
            var product = _context.Products
                .Include(p => p.Console)
                .Include(p => p.Videogame)
                    .ThenInclude(v => v.VideogameGenders)
                        .ThenInclude(vg => vg.Gender)
                .FirstOrDefault(p => p.Id == id);

            // Si el producto no existe
            if (product == null)
                return null;

            // si el producto es un juego 
            if (product.Videogame != null)
            {
                // Mapeamos las propiedades al DTO y lo devolvemos
                return new ProductVideogameDTO
                {
                    Id = product.Id,
                    Sales = product.Sales,
                    Name = product.Videogame.Name,
                    Pegi = product.Videogame.Pegi,
                    Description = product.Videogame.Description,
                    Requisitos1 = product.Videogame.Requisitos1,
                    Requisitos2 = product.Videogame.Requisitos2,
                    Stock = product.Videogame.Stock,
                    Distributor = product.Videogame.Distributor,
                    ReleaseDate = product.Videogame.ReleaseDate,
                    Developer = product.Videogame.Developer,
                    Discount = product.Videogame.Discount,
                    VideogameId = product.Videogame.Id,
                    //PlatformId =v.PlatformId,
                    Price = product.Videogame.Price,
                    PrincipalImageURL = product.Videogame.PrincipalImageURL,
                    Genders = product.Videogame.VideogameGenders.Select(vg => new GenderDTO
                    {
                        GenderId = vg.Gender.GenderId,
                        Name = vg.Gender.Name
                    }).ToList()
                };

            }

            // Si el producto es una consola
            if (product.Console != null)
            {
                // Mapeamos las propiedades al DTO y lo devolvemos
                return new ProductConsoleDTO
                {
                    Id = product.Id,
                    Sales = product.Sales,
                    Name = product.Console.Name,
                    Description = product.Console.Description,
                    Stock = product.Console.Stock,
                    ReleaseDate = product.Console.ReleaseDate,
                    Discount = product.Console.Discount,
                    Brand = product.Console.Brand,
                    ConsoleId = product.Console.Id,
                    Specifications = product.Console.Specifications,
                    //PlatformId =v.PlatformId,
                    //GenderId =v.GenderId,
                    Price = product.Console.Price,
                    PrincipalImageURL = product.Console.PrincipalImageURL
                };

            }

            // Si no es ni Videojuego ni consola ni producto de segunda mano
            return null;
            
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
