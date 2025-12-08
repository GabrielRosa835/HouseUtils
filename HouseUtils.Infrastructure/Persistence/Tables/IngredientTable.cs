using HouseUtils.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseUtils.Infrastructure.Persistence.Tables;

public class IngredientTable : IEntityTypeConfiguration<Ingredient>
{
   public void Configure (EntityTypeBuilder<Ingredient> builder)
   {
      builder.HasKey(i => new { i.RecipeId, i.ResourceId });

      builder.OwnsOne(i => i.Measure, new MeasureOwnership<Ingredient>().Configure);

      builder.HasOne(i => i.Resource)
         .WithMany()
         .HasForeignKey(i => i.ResourceId)
         .OnDelete(DeleteBehavior.Restrict);

      // In RecipeTable
      //builder.HasOne(i => i.Recipe)
      //   .WithMany(r => r.Ingredients)
      //   .HasForeignKey(i => i.RecipeId)
      //   .OnDelete(DeleteBehavior.Cascade);

      builder.ToTable("Ingredients");
   }
}
