using Library.Api.Models;
using Library.Api.Validators;
using OneOf;
using OneOf.Types;

namespace Library.Api.Services;

public interface IBookService
{
    public Task<OneOf<Success, Error, ValidationFailed>> CreateAsync(Book newBook, CancellationToken token = default);
    public Task<Book?> GetByIsbnAsync(string isbn);
    public Task<IEnumerable<Book>> GetAllAsync();
    public Task<IEnumerable<Book>> SearchByTitleAsync(string searchTerm);
    public Task<bool> UpdateAsync(Book book);
    public Task<bool> DeleteAsync(string isbn);
}