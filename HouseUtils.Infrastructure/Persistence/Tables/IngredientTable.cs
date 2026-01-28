using HouseUtils.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseUtils.Infrastructure.Persistence.Tables;

public class IngredientTable : IEntityTypeConfiguration<Ingredient>
{
   public void Configure (EntityTypeBuilder<Ingredient> builder)
   {
      builder.HasKey(i => i.Id);
      
      builder.Property(i => i.Id)
         .HasConversion(id => id.Value, value => new IngredientId(value));

      builder.OwnsOne(i => i.Measure, new MeasureOwnership<Ingredient>().Configure);

      builder.HasOne(i => i.Resource)
         .WithMany()
         .HasForeignKey(i => i.ResourceId)
         .OnDelete(DeleteBehavior.Restrict);

      builder.ToTable("Ingredients");
   }
}
