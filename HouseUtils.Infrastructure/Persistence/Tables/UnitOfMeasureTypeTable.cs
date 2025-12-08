using HouseUtils.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseUtils.Infrastructure.Persistence.Tables;

public class UnitOfMeasureTypeTable : IEntityTypeConfiguration<UnitOfMeasureType>
{
   public void Configure (EntityTypeBuilder<UnitOfMeasureType> builder)
   {
      builder.HasKey(e => e.Id);
      builder.HasAlternateKey(e => e.Name);

      builder.ToTable("UnitOfMeasureTypes");
   }
}
