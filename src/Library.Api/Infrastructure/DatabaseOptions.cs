namespace Url.Api.Models;

public class DatabaseOptions
{
  public static string SectionName = "Database";
  public required string ConnectionString { get; init; }
}
