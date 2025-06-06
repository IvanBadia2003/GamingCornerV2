using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCorner.Models
{
    public class UserPurchaseStatsDTO
    {
        /// <summary>
        /// Total de videojuegos comprados
        /// </summary>
        public int TotalVideogames { get; set; }

        /// <summary>
        /// Total de consolas compradas
        /// </summary>
        public int TotalConsoles { get; set; }

        /// <summary>
        /// Total de productos de segunda mano comprados
        /// </summary>
        public int TotalSecondHandProducts { get; set; }

        /// <summary>
        /// Total ahorrado en videojuegos
        /// </summary>
        public decimal TotalSavedOnVideogames { get; set; }

        /// <summary>
        /// Total ahorrado en consolas
        /// </summary>
        public decimal TotalSavedOnConsoles { get; set; }

        /// <summary>
        /// Total de producto que tiene el usuario a la venta
        /// </summary>
        public int TotalProductsOnSale { get; set; }

        /// <summary>
        /// Total de productos que tiene el usuario a la venta y que están checkeados
        /// </summary>
        public int CheckedProductsOnSale { get; set; }

        /// <summary>
        /// Total de productos que tiene el usuario a la venta y que no están checkeados
        /// </summary>
        public int UncheckedProductsOnSale { get; set; }
    }
}
