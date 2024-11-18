namespace ASPNET8.Models;

public class WeatherForecast
{
    public IList<Weather> weather { get; set; }
    public Main main { get; set; }
    //meters
    public int visibility { get; set; }
    public Wind wind { get; set; }
    public Clouds clouds { get; set; }
}

public class Weather
{
    public int id { get; set; }
    public string main { get; set; }
    public string description { get; set; }
    public string icon { get; set; }
}

public class Main
{
    public float temp { get; set; }
    public float feels_like { get; set; }
    public int humidity { get; set; }
}

public class Wind
{
    public float speed { get; set; }
    public int deg { get; set; }
    public float gust { get; set; }
}

public class Clouds
{
    public int all { get; set; }
}
