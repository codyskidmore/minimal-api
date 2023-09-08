using FluentValidation.Results;

namespace Library.Api.Validators;

public record ValidationFailed(IEnumerable<ValidationFailure> Errors)
{
    public ValidationFailed(ValidationFailure error) : this(new[] { error })
    {
        
    }
}