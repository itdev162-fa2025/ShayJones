using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        // POST: api/WeatherForecast/Create
        [HttpPost("Create", Name = "CreateWeatherForecast")]
        public ActionResult<WeatherForecast> Create()
        {
            _logger.LogInformation("Inserting a new WeatherForecast");

            var forecast = new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = 75,
                Summary = "Warm"
            };

            _context.WeatherForecasts.Add(forecast);
            var success = _context.SaveChanges() > 0;

            if (success)
            {
                return CreatedAtAction(nameof(GetById), new { id = forecast.Id }, forecast);
            }

            _logger.LogError("Error creating WeatherForecast");
            return StatusCode(StatusCodes.Status500InternalServerError, "Error creating WeatherForecast");
        }

        // GET: api/WeatherForecast
        [HttpGet(Name = "GetWeatherForecasts")]
        public IEnumerable<WeatherForecast> Get() =>
            Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();

        // GET: api/WeatherForecast/{id}
        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<WeatherForecast> GetById(Guid id)
        {
            var forecast = _context.WeatherForecasts.Find(id);
            if (forecast == null)
            {
                return NotFound();
            }

            return Ok(forecast);
        }
    }
}

