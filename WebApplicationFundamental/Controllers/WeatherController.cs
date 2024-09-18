using Microsoft.AspNetCore.Mvc;
using WebApplicationFundamental.Abstracts;
using WebApplicationFundamental.Records;

namespace WebApplicationFundamental.Controllers
{
    [Route("api/weather")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        // GET http://localhost:5164/api/weather
        [HttpGet]
        [ProducesResponseType(typeof(BaseResponse.Response<WeatherForeCastRecord[]>), StatusCodes.Status200OK)]
        public IResult GetWeatherForeCasts()
        {
            try
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

                return BaseResponse.Ok(true, "Custom message", forecast);
            }
            catch (Exception ex)
            {
                return BaseResponse.BadRequest(ex.Message);
            }
        }
    }
}