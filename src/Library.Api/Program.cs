using Library.Api.Data;
using Library.Api.Endpoints;
using Library.Api.Infrastructure;
using Library.Api.Models;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

var cacheConfig = config.GetSection(CacheConstants.BookCachePolicySection).Get<CacheSettings>();
builder.Services.AddMovieApiCache(cacheConfig!);

builder.Services.AddLibraryApiVersioning();
builder.Services.AddApiSwaggerOptions();
builder.Services.AddIdentity();
builder.Services.AddDatabase(config);
builder.Services.AddValidation();
builder.Services.AddApplicationServices();

var app = builder.Build();

app.MapIdentityApi<BaseUser>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseApiSwaggerUI();
}

app.MapApiEndpoints();

app.Run();