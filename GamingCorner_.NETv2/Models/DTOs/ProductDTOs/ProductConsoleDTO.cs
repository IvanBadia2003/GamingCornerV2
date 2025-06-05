using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCorner.Models.DTOs.ProductDTOs
{
    public class ProductConsoleDTO : ProductDTOBase
    {
        /// <summary>
        /// ID de la consola
        /// </summary>
        public int ConsoleId { get; set; }

        /// <summary>
        /// Nombre de la consola
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descripción de la consola 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Cantidad de stock de la consola
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Porcentaje de descuento sobre el precio de la consola
        /// </summary>
        public int Discount { get; set; }

        /// <summary>
        /// Precio de la consola
        /// </summary>
        public decimal Price { get; set; }

        //public int PlatformId { get; set; }
        //public int GenderId { get; set; }




        /// <summary>
        /// Especificaciones de la consola
        /// </summary>
        public string? Specifications { get; set; }


        //public int PlatformId { get; set; }        


        /// <summary>
        /// Fecha de lanzamiento de la consola
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Marca de la consola (Sony, Microsoft, Nintendo...)
        /// </summary>
        public string Brand { get; set; }

        public ProductsImagesDto ProductImages { get; set; }

        public Product ToProduct()
        {
            return new Product
            {
                Id = this.Id,
                Sales = this.Sales


            };
        }
    }
}
