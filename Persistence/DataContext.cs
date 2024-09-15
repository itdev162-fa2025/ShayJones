using Microsoft.EntityFrameworkCore;


namespace Persistence
{
    public class DataContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; } // Fixed typo

        public string DbPath { get; private set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            // Constructor with DbContextOptions parameter
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //var folder = Environment.SpecialFolder.LocalApplicationData;
                //var path = Environment.GetFolderPath(folder);
                //DbPath = System.IO.Path.Join(path, "Blogbox.db"); 

                optionsBuilder.UseSqlite($"Data Source={DbPath}"); 
            }
        }
    }
}
