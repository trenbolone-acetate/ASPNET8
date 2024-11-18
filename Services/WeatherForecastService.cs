using ASPNET8.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ASPNET8.Services;

public class WeatherForecastService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiToken;

    public WeatherForecastService(HttpClient httpClient, IOptions<WeatherForecastOptions> options)
    {
        _httpClient = httpClient;
        _apiToken = options.Value.ApiToken;
    }

    public async Task<WeatherForecast> GetForecastAsync(string cityName)
    {
        Coordinates coordinates = GetCoordinatesFromCityName(cityName).Result ?? new Coordinates();
        Console.WriteLine($"{cityName} lat:{coordinates.lat}, lon:{coordinates.lon}");

        var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?lat={coordinates.lat}&lon={coordinates.lon}&appid={_apiToken}");
        response.EnsureSuccessStatusCode();
        var forecast = JsonConvert.DeserializeObject<WeatherForecast>(await response.Content.ReadAsStringAsync());
        Console.WriteLine(cityName + " temp-" + forecast.main.temp);
        return forecast;
    }

    private async Task<Coordinates?> GetCoordinatesFromCityName(string cityName)
    {
        var response = await _httpClient.GetAsync($"https://api.openweathermap.org/geo/1.0/direct?q={cityName}&limit=1&appid={_apiToken}");
        
        response.EnsureSuccessStatusCode();

        var roots = JsonConvert.DeserializeObject<List<Root>>(await response.Content.ReadAsStringAsync());
        var coordinates = roots.Select(x => new Coordinates { lat = x.lat, lon = x.lon }).FirstOrDefault();
        return coordinates;
    }
}
//WeatherForecast:ApiToken