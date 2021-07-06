using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICreation.Controllers
{
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("Forecast")]
        public WeatherForecast GetForecast()
        {
            WeatherForecast wf = new WeatherForecast();
            wf.Date = DateTime.Now;
            wf.Summary = "Hello World";
            wf.TemperatureC = 20;
            return wf;
        }

        [HttpGet]
        [Route("GetSummary/{id}")]
        public string GetSummary(int id)
        {
            try
            {
                string summary = Summaries[id];
                return summary;
            }
            catch(IndexOutOfRangeException e)
            {
                return e.Message;
            }
        }
    }
}
