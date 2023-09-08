namespace Library.Api.Infrastructure;

public class CacheSettings
{
    public required string PolicyName { get; init; }
    public required int Expiration { get; init; }
    public required string TagName { get; init; }
    public required string[] QueryKeys { get; init; }
}