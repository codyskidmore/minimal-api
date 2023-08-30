using Library.Api.Data;
using Library.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
// builder.Services.AddAuthorizationBuilder();
//builder.Services.AddDbContext<LibraryDbContext>(x => x.UseNpgsql(config["Database:ConnectionString"]!));
builder.Services.AddDatabase(config);
// builder.Services.AddIdentityCore<BaseUser>()
//     .AddEntityFrameworkStores<AppDbContext>()
//    .AddApiEndpoints();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapApiEndpoints();

app.Run();