using Microsoft.AspNetCore.Mvc;

namespace APIDotnetPlatzi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static List<WeatherForecast> InternalWeatherForecastList = new List<WeatherForecast>();

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if(InternalWeatherForecastList == null || !InternalWeatherForecastList.Any())
        {        
            InternalWeatherForecastList =   Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
       return InternalWeatherForecastList;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        InternalWeatherForecastList.Add(weatherForecast);

        return Ok();
    }
}
