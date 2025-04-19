namespace WeatherScheduler.Models;

public class WeatherRecord
{
    public int Id { get; set; }
    public string City { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Temperature { get; set; }
    public DateTime RecordedAt { get; set; } = DateTime.UtcNow;
}
