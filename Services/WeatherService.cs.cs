using WeatherScheduler.Data;
using WeatherScheduler.Models;

namespace WeatherScheduler.Services;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly WeatherDbContext _context;

    public WeatherService(WeatherDbContext context, HttpClient httpClient)
    {
        _httpClient = httpClient;
        _context = context;
    }

    public async Task FetchAndSaveWeatherAsync()
    {
        string city = "London";
        string apiKey = "3fb31f5b495c491d0b169acb9ff819cb"; // Replace this with your actual OpenWeatherMap API key
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={apiKey}";

        var response = await _httpClient.GetFromJsonAsync<OpenWeatherResponse>(url);

        if (response != null)
        {
            var record = new WeatherRecord
            {
                City = city,
                Temperature = response.Main.Temp,
                Description = response.Weather.FirstOrDefault()?.Description ?? "N/A"
            };

            _context.WeatherRecords.Add(record);
            await _context.SaveChangesAsync();
        }
    }
}

public class OpenWeatherResponse
{
    public List<WeatherInfo> Weather { get; set; } = new();
    public MainInfo Main { get; set; } = new();
}

public class WeatherInfo
{
    public string Description { get; set; } = string.Empty;
}

public class MainInfo
{
    public double Temp { get; set; }
}
