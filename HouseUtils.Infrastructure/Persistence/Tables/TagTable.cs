using HouseUtils.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseUtils.Infrastructure.Persistence.Tables;

public class TagTable : IEntityTypeConfiguration<Tag>
{
   public void Configure (EntityTypeBuilder<Tag> builder)
   {
      builder.HasKey(e => e.Id);
      builder.HasAlternateKey(e => e.Name);

      builder.ToTable("Tags");
   }
}
