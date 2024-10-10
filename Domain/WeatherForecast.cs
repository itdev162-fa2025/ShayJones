using System;
using System.Diagnostics;

namespace Domain
{
  public class WeatherForecast
{
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; } = string.Empty;
}
}
