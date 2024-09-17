using Microsoft.AspNetCore.Mvc;
using WebApplicationFundamental.Records;
namespace WebApplicationFundamental.Controllers;


[Route("api/weather")]
[ApiController]
public class WeatherController : ControllerBase
{
  // GEThttp://localhost:5164/api/weather
  [HttpGet]
  public IEnumerable<WeatherForeCastRecord> GetWeatherForeCasts()
  {
    var summaries = new[]
    {
      "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForeCastRecord
        (
          DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
          Random.Shared.Next(-20, 55),
          summaries[Random.Shared.Next(summaries.Length)]
        ))
      .ToArray();
    return forecast;
  }

  public IActionResult GetWeather()
  {
    var summaries = new[]
    {
      "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForeCastRecord
        (
          DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
          Random.Shared.Next(-20, 55),
          summaries[Random.Shared.Next(summaries.Length)]
        ))
      .ToArray();
    return Ok(forecast);
  }
}
