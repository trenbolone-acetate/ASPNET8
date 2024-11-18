using ASPNET8.Models;
using ASPNET8.Services;
using Microsoft.AspNetCore.Mvc;
using Index = ASPNET8.Models.Index;

// ReSharper disable All

namespace ASPNET8.Controllers;

public class WeatherForecastController : Controller
{
    private readonly WeatherForecastService _weatherForecastService;
    public WeatherForecastController(WeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    public ViewResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> GetForecast(CityViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Index");
        }

        try
        {
            Console.WriteLine(model.CityName);
            var forecast = await _weatherForecastService.GetForecastAsync(model.CityName);
            ViewBag.City = model.CityName;
            return View("GetForecast", forecast);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, $"Error getting forecast: {ex.Message}");
            return View("Index");
        }
    }
}