namespace Library.Api.Endpoints;

public static class GetBookEndpoint
{
    public const string Name = "GetBook";

    public static IEndpointRouteBuilder MapGetBook(this IEndpointRouteBuilder app)
    {
        // app.MapPost(ApiEndpoints.Books.Create, async (NewBookRequest newBookRequest, IBookService bookService, IOutputCacheStore outputCacheStore, CancellationToken token) =>
        //     {
        //         var createResult = await bookService.CreateAsync(newBookRequest, token);
        //         await outputCacheStore.EvictByTagAsync(CacheConstants.MovieCacheTagName, token);
        //
        //         return TypedResults.CreatedAtRoute(bookResponse, GetMovieByIdEndpoint.Name, new { id = movie.Id });
        //
        //         return createResult.Match<IActionResult>(m => Ok(CreatedAtAction(nameof(Get), new { id = movie.Id }, GetMovieResponse(movie, token).Result)),
        //             _ => BadRequest("Failed to Create movie."),
        //             failed => BadRequest(failed.Errors.MapToResponse()));
        //     }).WithName(Name)
        //     .Produces<BookResponse>(StatusCodes.Status201Created)
        //     .Produces<ValidationFailureResponse>(StatusCodes.Status400BadRequest)
        //     .RequireAuthorization(AuthConstants.TrustedMemberPolicyName)
        //     .WithApiVersionSet(ApiVersioning.VersionSet)
        //     .HasApiVersion(1.0);
        // ;
        
        return app;
    }
    
}