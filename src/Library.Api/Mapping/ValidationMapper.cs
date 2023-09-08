using FluentValidation.Results;
using Library.Api.Validators;

namespace Library.Api.Mapping;

public static class ValidationMapper
{
    public static ValidationFailureResponse MapToResponse(this IEnumerable<ValidationFailure> failures)
    {
        return new ValidationFailureResponse
        {
            Errors = failures.Select(x => new ValidationResponse
            {
                PropertyName = x.PropertyName,
                Message = x.ErrorMessage
            })
        };
    }
}