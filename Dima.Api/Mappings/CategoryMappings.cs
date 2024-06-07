using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Mappings;

public class CategoryMappings:IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnType("nvarchar")
            .HasMaxLength(80);
        builder.Property(x => x.Description)
            .IsRequired(false)
            .HasColumnType("nvarchar")
            .HasMaxLength(255);
        builder.Property(x => x.UserId)
            .IsRequired(true)
            .HasColumnType("varchar")
            .HasMaxLength(160);
    }
}