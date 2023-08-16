using Minimal.Api;

var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// /swagger/index.html

//app.MapSwagger();

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

app.Run();