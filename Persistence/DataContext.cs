using System;
using Domain; 
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
       public class DataContext : DbContext
    {
        public DbSet<Domain.WeatherForecast> WeatherForecasts { get; set; }
        public DbSet<Post> Posts { get; set; }

        public string? DbPath { get; }

        public DataContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Blogbox.db");   
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={DbPath}"); 
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherForecast>().HasNoKey();
        }

    }
}