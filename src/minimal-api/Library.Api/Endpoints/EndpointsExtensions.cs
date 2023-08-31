namespace Library.Api.Endpoints;

public static class EndpointsExtensions
{
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app)
    {
        //app.MapGetWeatherForecast();
        app.MapGet("/", () => "Hello World!").WithTags("Books");
        return app;
    }
    
}