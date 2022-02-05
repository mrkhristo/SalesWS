using Microsoft.AspNetCore.Mvc;
using SalesWS.Models;

namespace SalesWS.Controllers
{
    [Route("{Controller}")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            List<WeatherForecast> lst = new List<WeatherForecast>();

            lst.Add(new WeatherForecast() { Id = 1, Name = "Test1" });
            lst.Add(new WeatherForecast() { Id = 2, Name = "Test2" });

            return lst;
        }
    }
}
