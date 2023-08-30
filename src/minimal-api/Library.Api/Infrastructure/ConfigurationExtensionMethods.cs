using Url.Api.Models;

namespace Library.Api.Data;

public static class ConfigurationExtensionMethods
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<DatabaseOptions>(
            config.GetSection(DatabaseOptions.SectionName));
        services.AddDbContext<LibraryDbContext>();

        return services;
    }

}