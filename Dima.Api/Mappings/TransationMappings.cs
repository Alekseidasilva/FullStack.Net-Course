using Dima.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dima.Api.Mappings;

public class TransationMappings:IEntityTypeConfiguration<Transation>
{
    public void Configure(EntityTypeBuilder<Transation> builder)
    {
        builder.ToTable("Transation");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnType("nvarchar")
            .HasMaxLength(80);
        builder.Property(x => x.Type)
            .IsRequired()
            .HasColumnType("smallint");
        builder.Property(x => x.Amount)
           // .IsRequired(false)
            .HasColumnType("money")
            .HasMaxLength(255);
        builder.Property(x => x.CreatedAt)
            .IsRequired(true);
        builder.Property(x => x.PaidOrReceivedAt)
            .IsRequired(false);
        builder.Property(x => x.UserId)
            .IsRequired(true)
            .HasColumnType("varchar")
            .HasMaxLength(160);
        
    }
}