using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingCorner.Models.DTOs.ChartDTOs
{
    public class RadarChartDTO
    {
        public List<string> Labels { get; set; } = new();
        public List<int> CurrentMonthData { get; set; } = new();
        public List<int> PreviousMonthData { get; set; } = new();
    }

}
