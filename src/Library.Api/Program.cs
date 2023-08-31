using Library.Api.Data;
using Library.Api.Endpoints;
using Library.Api.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services.AddLibraryApiVersioning();
builder.Services.AddApiSwaggerOptions();
builder.Services.AddIdentity();
builder.Services.AddDatabase(config);

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