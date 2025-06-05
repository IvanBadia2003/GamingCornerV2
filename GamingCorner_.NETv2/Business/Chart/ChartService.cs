namespace GamingCorner.Business;

using GamingCorner.Data;
using GamingCorner.Business;
using GamingCorner.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using GamingCorner.Models.DTOs.ProductDTOs;
using GamingCorner.Models.DTOs.ChartDTOs;

public class ChartService : IChartService
{

    private readonly IChartEFRepository _chartRepository;


    public ChartService(IChartEFRepository chartRepository)
    {
        _chartRepository = chartRepository;

    }

    public decimal AverageOrderValue()
    {
        return _chartRepository.AverageOrderValue();

    }

    public PieChartDTO GetPlatformSales()
    {
        return _chartRepository.GetPlatformSales();
    }

    public RadarChartDTO GetRadarStats()
    {
        return _chartRepository.GetRadarStats();
    }

    public LineChartDTO GetWeeklyOrders()
    {
        return _chartRepository.GetWeeklyOrders();
    }

    public BarChartDTO GetWeeklyRevenue()
    {
        return _chartRepository.GetWeeklyRevenue();
    }

    public int TotalOrders()
    {
        return _chartRepository.TotalOrders();

    }

    public decimal TotalRevenueToday()
    {
        return _chartRepository.TotalRevenueToday();

    }
}


    
    

