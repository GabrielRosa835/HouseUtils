using HouseUtils.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseUtils.Infrastructure.Persistence.Tables;

public class ResourceTable : IEntityTypeConfiguration<Resource>
{
   public void Configure (EntityTypeBuilder<Resource> builder)
   {
      builder.HasKey(r => r.Id);
      builder.HasAlternateKey(r => r.Name);

      builder.HasOne(r => r.Storage)
         .WithOne(s => s.Resource)
         .HasForeignKey<Resource>(r => r.StorageId)
         .OnDelete(DeleteBehavior.Cascade);

      builder.ToTable("Resources");
   }
}
