using Library.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Api.Data;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("books", Schemas.Library.ToString());
        builder.Property(e => e.Id).UseIdentityColumn();
        builder.Property(e => e.Guid).IsRequired();
        builder.Property(e => e.Author).IsRequired();
        
        builder.Property(e => e.Isbn)
            .HasColumnType("varchar(13)")
            .IsRequired();
        builder.HasIndex(e => e.Isbn).IsUnique();
        
        builder.Property(e => e.Title)
            .HasColumnType("varchar(50)")
            .IsRequired();
        builder.Property(e => e.PageCount).IsRequired();
        builder.Property(e => e.ReleaseDate).IsRequired();
        builder.Property(e => e.ShortDescription)
            .HasColumnType("varchar(265)")
            .IsRequired();
    }
}