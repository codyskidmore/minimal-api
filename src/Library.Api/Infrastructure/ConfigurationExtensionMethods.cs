﻿using Asp.Versioning;
using Library.Api.Models;
using Library.Api.Swagger;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
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
    public static IServiceCollection AddLibraryApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(x =>
        {
            x.DefaultApiVersion = new ApiVersion(1.0);
            x.AssumeDefaultVersionWhenUnspecified = true;
            x.ReportApiVersions = true;
            x.ApiVersionReader = new MediaTypeApiVersionReader("api-version");
        }).AddApiExplorer();

        services.AddEndpointsApiExplorer();
        
        return services;
    }
    public static IServiceCollection AddApiSwaggerOptions(this IServiceCollection services)
    {
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.AddSwaggerGen(x => x.OperationFilter<SwaggerDefaultValues>());
        return services;
    }
    public static WebApplication UseApiSwaggerUI(this WebApplication app)
    {
        app.UseSwaggerUI(x =>
        {
            foreach (var description in app.DescribeApiVersions())
            {
                x.SwaggerEndpoint( $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName);
            }
        });
        return app;
    }
}