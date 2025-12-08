namespace HouseUtils.Domain.Models;

public class UnitOfMeasure : IEntity<int>
{
   public int Id { get; set; }
   public decimal ConversionFactor { get; set; }
   public required string Name { get; set; } = null!;
   public required string Singular { get; set; } = null!;
   public required string Abbreviation { get; set; } = null!;
   public required int TypeId { get; set; }
   public UnitOfMeasureType? Type { get; set; } = null!;

   int IEntity<int>.Pk => Id;
   object IEntity.Pk => Id;
}
