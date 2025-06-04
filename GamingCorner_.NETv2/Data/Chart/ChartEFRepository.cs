using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamingCorner.Models.DTOs.ChartDTOs;
using Microsoft.EntityFrameworkCore;

namespace GamingCorner.Data
{
    public class ChartEFRepository : IChartEFRepository
    {

        private readonly GamingCornerContext _context;

        public ChartEFRepository(GamingCornerContext context)
        {

            _context = context;
        }

        public BarChartDTO GetWeeklyRevenue()
        {
            // Agrupar ingresos por día de la semana (ejemplo simple)
            var result = _context.OrderHeaders
                .Include(o => o.OrderLines)
                .Where(o => o.CreatedAt >= DateTime.Now.AddDays(-7))
                .AsEnumerable() // Cambia a evaluación en memoria
                .GroupBy(o => o.CreatedAt.DayOfWeek)
                .Select(g => new
                {
                    Day = g.Key.ToString(),
                    Revenue = g.Sum(x => x.OrderLines.Sum(l => l.Price))
                })
                .ToList();

            return new BarChartDTO
            {
                Labels = result.Select(r => r.Day).ToList(),
                Data = result.Select(r => r.Revenue).ToList()
            };
        }

        public PieChartDTO GetPlatformSales()
        {
            var result = _context.Products
                .Include(p => p.Platform)
                .GroupBy(p => p.Platform.Name)
                .Select(g => new { Platform = g.Key, Total = g.Sum(p => p.Sales) })
                .ToList();

            return new PieChartDTO
            {
                Labels = result.Select(r => r.Platform).ToList(),
                Data = result.Select(r => r.Total).ToList()
            };
        }

        public RadarChartDTO GetRadarStats()
        {
            // Simulado. Deberías sustituir esto con estadísticas reales
            return new RadarChartDTO
            {
                Labels = new List<string> { "Ventas", "Envíos", "Reseñas", "Reembolsos", "Soporte" },
                CurrentMonthData = new List<int> { 90, 70, 85, 40, 60 },
                PreviousMonthData = new List<int> { 80, 65, 78, 55, 50 }
            };
        }

        public LineChartDTO GetWeeklyOrders()
        {
            var result = _context.OrderHeaders
             .Where(o => o.CreatedAt >= DateTime.Now.AddDays(-30))
             .AsEnumerable() // Cambia a evaluación en memoria
             .OrderBy(o => o.CreatedAt)
             .GroupBy(o => CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                 o.CreatedAt, CalendarWeekRule.FirstDay, DayOfWeek.Monday))
             .Select(g => new
             {
                 Week = $"Semana {g.Key}",
                 Count = g.Count()
             })
             .ToList();


            return new LineChartDTO
            {
                Labels = result.Select(r => r.Week).ToList(),
                Data = result.Select(r => r.Count).ToList()
            };
        }

        public decimal TotalRevenueToday()
        {
            return _context.OrderLines
                      .Where(ol => ol.OrderHeader.CreatedAt.Date == DateTime.Today)
                      .Sum(ol => (decimal?)ol.Price) ?? 0;
        }

        public decimal AverageOrderValue()
        {
            return _context.OrderHeaders
                .Include(o => o.OrderLines)
                             .AsEnumerable() // Cambia a evaluación en memoria

                .Select(o => o.OrderLines.Sum(ol => (decimal?)ol.Price) ?? 0)
                .DefaultIfEmpty(0)
                .Average();
        }

        public int TotalOrders()
        {
            return _context.OrderHeaders.Where(o => o.CreatedAt.Date == DateTime.Today).Count();

        }
    }
}
