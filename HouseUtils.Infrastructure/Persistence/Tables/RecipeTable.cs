using HouseUtils.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseUtils.Infrastructure.Persistence.Tables;

public class RecipeTable : IEntityTypeConfiguration<Recipe>
{
   public void Configure (EntityTypeBuilder<Recipe> builder)
   {
      builder.HasKey(r => r.Id);
      builder.HasAlternateKey(r => r.Name);

      builder.HasMany(r => r.Steps)
         .WithOne(s => s.Recipe)
         .HasForeignKey(s => s.RecipeId)
         .OnDelete(DeleteBehavior.Cascade);

      builder.HasMany(r => r.Ingredients)
         .WithOne(i => i.Recipe)
         .HasForeignKey(i => i.RecipeId)
         .OnDelete(DeleteBehavior.Cascade);

      builder.ToTable("Recipes");
   }
}
