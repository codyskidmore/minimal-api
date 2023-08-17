using Minimal.Api.Data;

namespace Minimal.Api.Endpoints;

public static class GetWeatherForecastEndpoint
{
    public static IEndpointRouteBuilder MapGetWeatherForecast(this IEndpointRouteBuilder app)
    {
        app.MapGet("/weatherforecast", (ILogger<Program> logger) =>
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = WeatherData.Summaries[Random.Shared.Next(WeatherData.Summaries.Length)]
                })
                .ToArray();
        });        
        return app;
    }
}