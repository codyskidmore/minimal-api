using Library.Api.Infrastructure;
using Library.Api.Mapping;
using Library.Api.Models;
using Library.Api.Services;
using Library.Api.Validators;
using Microsoft.AspNetCore.OutputCaching;

namespace Library.Api.Endpoints;

public static class CreateBookEndpoint
{
    public const string Name = "CreateBook";

    public static IEndpointRouteBuilder MapCreateBook(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiEndpoints.Books.Create, async (NewBookRequest newBookRequest, IBookService bookService, IOutputCacheStore outputCacheStore, CancellationToken token) =>
        {
            var newBook = newBookRequest.ToNewBook();
                
            var createResult = await bookService.CreateAsync(newBook, token);
            
            await outputCacheStore.EvictByTagAsync(CacheConstants.BookCacheTagName, token);

            // TODO: Figure out how to return the actual resonse value (i.e. => BookResponse)
            // return createResult.Match<IResult>(m => TypedResults.Ok(TypedResults.CreatedAtRoute(GetBookEndpoint.Name, new { guid = newBook.Guid })),
            //     _ => TypedResults.BadRequest("Failed to Create movie."),
            //     failed => TypedResults.BadRequest(failed.Errors.MapToResponse()));
            
            // TODO: Replace this once we know ho wto use TypeResult.CreateAtRoute()
            return createResult.Match<IResult>(m => TypedResults.Created($"/books/{newBook.Guid}", newBook.ToBookResponse()),
                _ => TypedResults.BadRequest("Failed to Create movie."),
                failed => TypedResults.BadRequest(failed.Errors.MapToResponse()));
        }).WithName(Name)
        .Produces<BookResponse>(StatusCodes.Status201Created)
        .Produces<ValidationFailureResponse>(StatusCodes.Status400BadRequest)
        // TODO: Reenable authorization.
        //.RequireAuthorization(AuthConstants.TrustedMemberPolicyName)
        .WithApiVersionSet(ApiVersioning.VersionSet)
        .HasApiVersion(1.0);
        ;

        
        return app;
    }
}