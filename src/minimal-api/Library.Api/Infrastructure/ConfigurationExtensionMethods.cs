using Library.Api.Models;
using Microsoft.AspNetCore.Identity;
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

    public static IServiceCollection AddIdentity(this IServiceCollection services)
    {
        services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
        services.AddAuthorizationBuilder();
        services.AddDbContext<IdentityDbContext>();
        services.AddIdentityCore<BaseUser>()
            .AddEntityFrameworkStores<IdentityDbContext>()
           .AddApiEndpoints();

        return services;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        return services;
    }
}