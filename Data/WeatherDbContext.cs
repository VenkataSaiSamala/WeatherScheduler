using Microsoft.EntityFrameworkCore;
using WeatherScheduler.Models;

namespace WeatherScheduler.Data;

public class WeatherDbContext : DbContext
{
    public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options) { }
    
    
    public DbSet<WeatherRecord> WeatherRecords => Set<WeatherRecord>();

    
}

