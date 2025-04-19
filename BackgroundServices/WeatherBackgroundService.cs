
using WeatherScheduler.Services;

namespace WeatherScheduler.BackgroundServices;

public class WeatherBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public WeatherBackgroundService(IServiceProvider serviceProvider)
    {
        this._serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            var weatherService = scope.ServiceProvider.GetRequiredService<WeatherService>();

            await weatherService.FetchAndSaveWeatherAsync();
            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
        }
    }
}
