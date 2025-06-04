using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingCorner.Models.DTOs.ChartDTOs;

namespace GamingCorner.Data
{
    public interface IChartEFRepository
    {
        /// <summary>
        /// Obtener los ingresos en los últimos 7 días
        /// </summary>
        /// <returns></returns>
        public BarChartDTO GetWeeklyRevenue();

        /// <summary>
        /// Obtener pedidos por semana
        /// </summary>
        /// <returns></returns>
        public LineChartDTO GetWeeklyOrders();
        
        /// <summary>
        /// Obtener las ventas por plataforma
        /// </summary>
        /// <returns></returns>
        public PieChartDTO GetPlatformSales();

        /// <summary>
        /// Obtener comparativas en 2 meses
        /// </summary>
        /// <returns></returns>
        public RadarChartDTO GetRadarStats();
        
        /// <summary>
        /// Obtener los ingresos de hoy
        /// </summary>
        /// <returns></returns>
        public decimal TotalRevenueToday();
        
        /// <summary>
        /// Obtener el precio medio de los pedidos
        /// </summary>
        /// <returns></returns>
        public decimal AverageOrderValue();
        
        /// <summary>
        /// Obtener el número de pedidos de hoy
        /// </summary>
        /// <returns></returns>
        public int TotalOrders();
    }

}
