using GamingCorner.Business;
using GamingCorner.Models;
using GamingCorner.Models.DTOs.ChartDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamingCorner.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChartController : ControllerBase
    {

        private readonly IChartService _chartService;

        public ChartController(IChartService chartService) { 
        _chartService = chartService;
        }

        [HttpGet]
        [Route("PlatformFormSales")]

        public ActionResult<PieChartDTO> GetPlatformSales() => _chartService.GetPlatformSales();

        [HttpGet]
        [Route("WeeklyOrders")]
        public ActionResult<LineChartDTO> GetWeeklyOrders() => _chartService.GetWeeklyOrders();
               
        [HttpGet]
        [Route("WeeklyRevenue")]
        public ActionResult<BarChartDTO> GetWeeklyRevenue() => _chartService.GetWeeklyRevenue();
        

        [HttpGet]
        [Route("RadarStats")]
        public ActionResult<RadarChartDTO> GetRadarStats() => _chartService.GetRadarStats();

        [HttpGet]
        [Route("PrincipalStats")]
        public ActionResult GetPrincipalStats() 
        {

            var principalStatsDTO = new PrincipalStatsDTO
            {
                TotalRevenueToday = _chartService.TotalRevenueToday(),
                TotalOrdersToday = _chartService.TotalOrders(),
                AverageOrderValue = _chartService.AverageOrderValue()
            };

            return Ok(principalStatsDTO);
        }


    }
}
