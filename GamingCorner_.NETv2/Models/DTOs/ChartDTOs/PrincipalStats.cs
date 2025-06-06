using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCorner.Models.DTOs.ChartDTOs
{
    public class PrincipalStatsDTO
    {
        public decimal TotalRevenueToday { get; set; }
        public int TotalOrdersToday { get; set; }
        public decimal AverageOrderValue { get; set; }
    }
}
