namespace Library.Api.Validators;

public class ValidationResponse
{
    public required string PropertyName { get; init; }

    public required string Message { get; init; }
}