using HouseUtils.Domain.Values;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseUtils.Infrastructure.Persistence.Tables;

public class MeasureOwnership<TOwner> where TOwner : class
{
   public void Configure (OwnedNavigationBuilder<TOwner, Measure> builder) 
   {
      builder.Property<int>("UnitId")
         .HasColumnName("Measure_UnitId");

      builder.Property(m => m.Amount)
         .HasColumnName("Measure_Amount");

      builder.HasOne(m => m.Unit)
         .WithMany()
         .HasForeignKey("UnitId")
         .OnDelete(DeleteBehavior.Restrict);

      builder.Navigation(m => m.Unit).AutoInclude();
   }
}
