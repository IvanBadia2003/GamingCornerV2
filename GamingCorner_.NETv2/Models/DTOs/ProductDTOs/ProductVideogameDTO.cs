using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCorner.Models
{
    public class ProductVideogameDTO : ProductDTOBase
    {


        /// <summary>
        /// ID del juego
        /// </summary>
        public int VideogameId { get; set; }

        /// <summary>
        /// Nombre del juego
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Pegi del juego
        /// </summary>
        public int Pegi { get; set; }

        /// <summary>
        /// Descripción del juego
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Requisitos Minimos del juego
        /// </summary>
        public string? Requisitos1 { get; set; }

        /// <summary>
        /// Requisitos Recomendados del juego
        /// </summary>
        public string? Requisitos2 { get; set; }

        /// <summary>
        /// Cantidad de stock del juego
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Porcentaje de descuento sobre el precio del juego
        /// </summary>
        public int Discount { get; set; }

        /// <summary>
        /// Precio del juego
        /// </summary>
        public decimal Price { get; set; }

        //public int PlatformId { get; set; }
        //public int GenderId { get; set; }

        /// <summary>
        /// Imagen Principal del juego
        /// </summary>
        public string? PrincipalImageURL { get; set; }

        /// <summary>
        /// Fecha de lanzamiento del juego
        /// </summary>
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// Distribuidor del juego
        /// </summary>
        public string Distributor { get; set; }

        /// <summary>
        /// Desarrollador del juego
        /// </summary>
        public string Developer { get; set; }

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
