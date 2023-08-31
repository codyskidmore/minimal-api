namespace Url.Api.Models;

public class DatabaseOptions
{
  public static string SectionName = "Database";
  public required string LibraryConnectionString { get; init; }
  public required string IdentityConnectionString { get; init; }
}
