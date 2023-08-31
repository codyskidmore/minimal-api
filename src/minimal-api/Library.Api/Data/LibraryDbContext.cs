using System.Reflection;
using Library.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Url.Api.Models;

namespace Library.Api.Data;

public class LibraryDbContext : DbContext
{
    public DbSet<Book> Books { get; set; } = default!;
    private readonly IOptions<DatabaseOptions> _dbOptions;

    public LibraryDbContext(DbContextOptions<LibraryDbContext> options, IOptions<DatabaseOptions> dbOptions) : base(options)
    {
        _dbOptions = dbOptions;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) optionsBuilder.UseNpgsql(_dbOptions.Value.ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}