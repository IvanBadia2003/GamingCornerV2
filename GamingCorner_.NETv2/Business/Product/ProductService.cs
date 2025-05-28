using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingCorner.Data;
using GamingCorner.Models;
using GamingCorner.Models.DTOs.ProductDTOs;

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

            return null;
        }
        /// <summary>
        /// Obtener productos similares por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public List<ProductDTOBase> GetSimilarProducts(int id)
        {
            // Se obtiene los productos
            var similarProducts = _productEFRepository.GetSimilarProducts(id);

            // Si no existe lanzar excepción
            if (similarProducts == null)
                throw new KeyNotFoundException($"Producto con el id {id} no encontrado");

            var isVideogame = similarProducts.First().Videogame != null;
            var isConsole = similarProducts.First().Console!= null;

            // Mapeamos cada producto a su DTO correspondiente
            if (isVideogame)
            {
                List<ProductDTOBase> videogameList = similarProducts.Select(product => new ProductVideogameDTO
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
                    Price = product.Videogame.Price,
                    PrincipalImageURL = product.Videogame.PrincipalImageURL,
                    Genders = (product.Videogame.VideogameGenders ?? new List<VideogameGender>())
                       .Where(vg => vg?.Gender != null)
                       .Select(vg => new GenderDTO
                       {
                           GenderId = vg.Gender.GenderId,
                           Name = vg.Gender.Name
                       }).ToList()
                }).Cast<ProductDTOBase>().ToList();

                return videogameList;
            }  
            
            if (isConsole)
            {
                List<ProductDTOBase> consoleList = similarProducts.Select(product => new ProductConsoleDTO
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
                    Price = product.Console.Price,
                    PrincipalImageURL = product.Console.PrincipalImageURL
                }).Cast<ProductDTOBase>().ToList();

                return consoleList;
            }

            return null;

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
