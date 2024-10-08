using System;
using System.Collections.Generic; // Make sure this is included
using System.Linq;
using Domain; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API.Controllers
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
        private readonly DataContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("GetWeatherForecast", Name = "GetWeatherForecast")]
        public ActionResult<WeatherForecast> Create()
        {
            Console.WriteLine($"Database path: {_context.DbPath}");
            Console.WriteLine("Insert a new WeatherForecast");

            var forecast = new WeatherForecast()
            {
                Date = DateTime.Now, // or DateOnly.FromDateTime(DateTime.Now) if you prefer DateOnly
                TemperatureC = 75, 
                Summary = "Warm"
            };

            _context.WeatherForecasts.Add(forecast);
            var success = _context.SaveChanges() > 0; 

            if (success)
            {
                return forecast; // Return created forecast
            }

            throw new Exception("Error creating WeatherForecast");
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get() => 
            Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();
    }
}

