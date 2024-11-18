using ASPNET8.Models;
using ASPNET8.Services;
using Microsoft.AspNetCore.Mvc;
// ReSharper disable All

namespace ASPNET8.Controllers;

public class WeatherForecastController : Controller
{
    private readonly WeatherForecastService _weatherForecastService;
    public WeatherForecastController(WeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    public async Task<ViewResult> Index()
    {
        var forecast = await _weatherForecastService.GetForecastAsync();
        return View(forecast);
    }
}