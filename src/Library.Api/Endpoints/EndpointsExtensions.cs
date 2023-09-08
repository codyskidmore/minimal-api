using Library.Api.Models;
using Library.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Endpoints;

public static class EndpointsExtensions
{
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app)
    {
        //app.MapGetWeatherForecast();
        app.MapGet("/", () => "Hello World!").WithTags("Books");
        app.MapCreateBook();
        // app.MapPost("books", async (NewBookRequest newBookRequest, IBookService bookService, CancellationToken token) =>
        // {
        //     var createResult = await bookService.CreateAsync(newBookRequest, token);
        //     
        //     return createResult.Match<IActionResult>(m => Ok(CreatedAtAction(nameof(Get), new { id = movie.Id }, GetMovieResponse(movie, token).Result)),
        //         _ => BadRequest("Failed to Create movie."),
        //         failed => BadRequest(failed.Errors.MapToResponse()));
        // });
        return app;
    }
    
}