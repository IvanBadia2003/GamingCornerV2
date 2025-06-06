using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using GamingCorner.Models.Enums.SystemEnum;

namespace GamingCorner.Models
{
    public class ProductDTOBase
    {
        /// <summary>
        /// ID del producto
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ventas del producto
        /// </summary>
        public int Sales { get; set; }

        /// <summary>
        /// Plataforma del producto
        /// </summary>
        public int? PlatformId { get; set; }

        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Precio del producto
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Descuento del producto
        /// </summary>
        public int Discount { get; set; }
        
        /// <summary>
        /// Descuento del producto
        /// </summary>
        public SystemEnum? System { get; set; }


        public string? Main { get; set; }
        public string? Background { get; set; }
        public string? Content1 { get; set; }
        public string? Content2 { get; set; }
        public string? Content3 { get; set; }
        public string? Content4 { get; set; }

        // public Platform? Platform { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public VideogameDTO Videogame { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ConsoleDTO Console { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Platform Platform { get; set; }

        public Product ToProduct()
        {
            return new Product
            {
                Platform = this.Platform,
                Sales = this.Sales,
                Id = this.Id

            };
        }


    }

}


