using System.Reflection;
using Library.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Url.Api.Models;

namespace Library.Api.Data;

public class IdentityDbContext : IdentityDbContext<BaseUser>
{
    private readonly IOptions<DatabaseOptions> _dbOptions;

    public IdentityDbContext(DbContextOptions<IdentityDbContext> options, IOptions<DatabaseOptions> dbOptions) : base(options)
    {
        _dbOptions = dbOptions;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) optionsBuilder.UseNpgsql(_dbOptions.Value.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schemas.Identity.ToString());
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }}