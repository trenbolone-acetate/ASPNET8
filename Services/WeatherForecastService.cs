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

    public async Task<WeatherForecast> GetForecastAsync()
    {
        //Kyiv forecast, long/lat coords
        var response = await _httpClient.GetAsync($"https://api.openweathermap.org/data/2.5/weather?lat=50.45&lon=30.52&appid={_apiToken}");
        
        response.EnsureSuccessStatusCode();

        var forecast = JsonConvert.DeserializeObject<WeatherForecast>(await response.Content.ReadAsStringAsync());
        
        return forecast;
    }
}
//WeatherForecast:ApiToken