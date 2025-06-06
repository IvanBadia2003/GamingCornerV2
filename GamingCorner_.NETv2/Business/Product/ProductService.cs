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
                    PlatformId = product.PlatformId,
                    Price = product.Videogame.Price,
                    ProductImages = new ProductsImagesDto
                    {
                        Background = product.BackgroundImage,
                        Content1 = product.ContentImages1,
                        Content2 = product.ContentImages2,
                        Content3 = product.ContentImages3,
                        Content4 = product.ContentImages4,
                        Main = product.MainImage,
                    },
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
                    PlatformId = product.PlatformId,
                    Price = product.Console.Price,
                    ProductImages = new ProductsImagesDto
                    {
                        Background = product.BackgroundImage,
                        Content1 = product.ContentImages1,
                        Content2 = product.ContentImages2,
                        Content3 = product.ContentImages3,
                        Content4 = product.ContentImages4,
                        Main = product.MainImage,
                    },
                };

            }

            // Si el producto es un producto de segunda mano
            if (product.SecondHandProduct != null)
            {
                // Mapeamos las propiedades al DTO y lo devolvemos
                return new SecondHandProductDTO
                {
                    Id = product.Id,
                    Description = product.SecondHandProduct.Description,
                    ImageURL = product.SecondHandProduct.ImageURL,
                    Name = product.SecondHandProduct.Name,
                    Price = product.SecondHandProduct.Price,
                    User = product.SecondHandProduct.User.ToUserDTO(),
                    ProductId = product.SecondHandProduct.ProductId
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
            var similarProducts = _productEFRepository.GetSimilarProducts(id);

            List<ProductDTOBase> products = new List<ProductDTOBase>();
            if (similarProducts == null || !similarProducts.Any())
                throw new KeyNotFoundException($"Producto con el id {id} no encontrado o sin similares.");

            var isVideogame = similarProducts.First().Videogame != null;
            var isConsole = similarProducts.First().Console != null;

            if (isVideogame)
            {
                products = similarProducts.Select(product => new ProductDTOBase
                {
                    Id = product.Id,
                    Name = product.Videogame.Name,
                    Discount = product.Videogame.Discount,
                    Price = product.Videogame.Price,
                    Main = product.MainImage
                }).ToList<ProductDTOBase>();

                return products;
            }

            if (isConsole)
            {
                products = similarProducts.Select(product => new ProductDTOBase
                {
                    Id = product.Id,
                    Name = product.Console.Name,
                    Discount = product.Console.Discount,
                    Price = product.Console.Price,
                    Main = product.MainImage
                }).ToList<ProductDTOBase>();

                return products;
            }

            return new List<ProductDTOBase>(); // Nunca devuelvas null en listas, mejor una vacía
        }


        /// <summary>
        /// Obtener productos compatibles por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public List<ProductDTOBase> GetCompatibleProducts(int id)
        {
            var compatibleProducts = _productEFRepository.GetcompatibleProducts(id);

            List<ProductDTOBase> products = new List<ProductDTOBase>();
            if (compatibleProducts == null || !compatibleProducts.Any())
                throw new KeyNotFoundException($"Producto con el id {id} no encontrado o sin compatibles.");

            var isVideogame = compatibleProducts.First().Videogame != null;
            var isConsole = compatibleProducts.First().Console != null;

            if (isVideogame)
            {
                products = compatibleProducts.Select(product => new ProductDTOBase
                {
                    Id = product.Id,
                    Name = product.Videogame.Name,
                    Discount = product.Videogame.Discount,
                    Price = product.Videogame.Price,
                    Main = product.MainImage
                }).ToList<ProductDTOBase>();

                return products;
            }

            if (isConsole)
            {
                products = compatibleProducts.Select(product => new ProductDTOBase
                {
                    Id = product.Id,
                    Name = product.Console.Name,
                    Discount = product.Console.Discount,
                    Price = product.Console.Price,
                    Main = product.MainImage
                }).ToList<ProductDTOBase>();

                return products;
            }

            return new List<ProductDTOBase>(); // Nunca devuelvas null en listas, mejor una vacía
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
