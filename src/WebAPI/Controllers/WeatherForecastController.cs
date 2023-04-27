using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    // add a new action method that returns a list of WeatherForecast objects and accepts a paraameter of DateRange type with the FromQuery attribute
    // Path: src/WebAPI/Controllers/WeatherForecastController.cs
    // http://localhostL5000/WeatherForecast?Length=5
    [HttpGet("Length", Name = "GetWeatherForecastByLength")]
    public IEnumerable<WeatherForecast> GetRange([FromQuery] DateRange range)
    {
        return Enumerable.Range(1, range.Length).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

// add a new class of DateRange that containts a Lenght property of integer type
// Path: src/WebAPI/Models/DateRange.cs
// http://localhostL5000/WeatherForecast?Length=5
public class DateRange
{
    public int Length { get; set; }
}

