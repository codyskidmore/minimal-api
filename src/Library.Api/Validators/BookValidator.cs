using FluentValidation;
using Library.Api.Models;

namespace Library.Api.Validators;

public class BookValidator : AbstractValidator<Book>
{
    public BookValidator()
    {
        RuleFor(x => x.Isbn)
            .NotEmpty();

        RuleFor(x => x.Title)
            .NotEmpty();

        RuleFor(x => x.Author)
            .NotEmpty();


        RuleFor(x => x.ShortDescription)
            .NotEmpty();

        RuleFor(x => x.PageCount)
            .GreaterThan(0);
    
        RuleFor(x => x.ReleaseDate)
            .LessThanOrEqualTo(DateTime.UtcNow.AddDays(1));
    }
}