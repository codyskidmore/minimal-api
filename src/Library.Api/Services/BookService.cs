using FluentValidation;
using Library.Api.Data;
using Library.Api.Mapping;
using Library.Api.Models;
using Library.Api.Validators;
using OneOf;
using OneOf.Types;

namespace Library.Api.Services;

public class BookService : IBookService
{
    private readonly LibraryDbContext _dbContext;
    private readonly IValidator<Book> _newBookRequestValidator;

    public BookService(LibraryDbContext dbContext,
        IValidator<Book> newBookRequestValidator)
    {
        _dbContext = dbContext;
        _newBookRequestValidator = newBookRequestValidator;
    }
    
    public async Task<OneOf<Success, Error, ValidationFailed>> CreateAsync(Book newBook, CancellationToken token = default)
    {
        var validationResult = await _newBookRequestValidator.ValidateAsync(newBook, token);
        if (!validationResult.IsValid)
        {
            return new ValidationFailed(validationResult.Errors);
        }
        
        await _dbContext.Books.AddAsync(newBook, token);
        var resultCount = await _dbContext.SaveChangesAsync(token);

        if (resultCount == 1)
        {
            return new Error();
        }
        
        return new Success();
    }

    public Task<Book?> GetByIsbnAsync(string isbn)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Book>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Book>> SearchByTitleAsync(string searchTerm)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Book book)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(string isbn)
    {
        throw new NotImplementedException();
    }
}