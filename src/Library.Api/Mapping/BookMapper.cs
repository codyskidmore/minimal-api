using Library.Api.Models;

namespace Library.Api.Mapping;

public static class BookMapper
{
    public static BookResponse ToBookResponse(this Book book)
    {
        return new BookResponse
        {
            Guid = book.Guid,
            Author = book.Author,
            Isbn = book.Isbn,
            Title = book.Title,
            PageCount = book.PageCount,
            ReleaseDate = book.ReleaseDate,
            ShortDescription = book.ShortDescription
        };
    }
    
    public static Book ToNewBook(this NewBookRequest book)
    {
        return new Book
        {
            Guid = Guid.NewGuid(), // Init'ing here could be a bit questionable. Might move.
            Author = book.Author,
            Isbn = book.Isbn,
            Title = book.Title,
            PageCount = book.PageCount,
            ReleaseDate = book.ReleaseDate,
            ShortDescription = book.ShortDescription
        };
    }
}