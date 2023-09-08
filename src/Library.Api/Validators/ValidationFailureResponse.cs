namespace Library.Api.Validators;

public class ValidationFailureResponse
{
    public required IEnumerable<ValidationResponse> Errors { get; init; }

}