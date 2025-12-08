using HouseUtils.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseUtils.Infrastructure.Persistence.Tables;

public class UnitOfMeasureTable : IEntityTypeConfiguration<UnitOfMeasure>
{
   public void Configure (EntityTypeBuilder<UnitOfMeasure> builder)
   {
      builder.HasKey(e => e.Id);
      builder.HasAlternateKey(e => e.Name);

      builder.HasOne(e => e.Type)
         .WithMany()
         .HasForeignKey(e => e.TypeId)
         .OnDelete(DeleteBehavior.Restrict);

      builder.ToTable("UnitsOfMeasure");
   }
}
