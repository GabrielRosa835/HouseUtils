using HouseUtils.Domain.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseUtils.Infrastructure.Persistence.Tables;

public class RecipeStepTable : IEntityTypeConfiguration<RecipeStep>
{
   public void Configure (EntityTypeBuilder<RecipeStep> builder)
   {
      builder.HasKey(rs => rs.Id);

      // In RecipeTable
      //builder.HasOne(rs => rs.Recipe)
      //   .WithMany(r => r.Steps)
      //   .HasForeignKey(rs => rs.RecipeId)
      //   .OnDelete(DeleteBehavior.Cascade);

      builder.ToTable("RecipeSteps");
   }
}
