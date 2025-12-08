using HouseUtils.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseUtils.Infrastructure.Persistence.Tables;

public class StorageTable : IEntityTypeConfiguration<Storage>
{
   public void Configure (EntityTypeBuilder<Storage> builder)
   {
      builder.HasKey(e => e.Id);
      builder.OwnsOne(e => e.Measure, new MeasureOwnership<Storage>().Configure);

      builder.ToTable("Storage");
   }
}
