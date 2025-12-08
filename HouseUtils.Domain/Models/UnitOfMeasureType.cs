namespace HouseUtils.Domain.Models;

public class UnitOfMeasureType : IEntity<int>
{
   public int Id { get; set; }
   public required string Name { get; set; } = null!;
   public string? Description { get; set; }

   int IEntity<int>.Pk => Id;
   object IEntity.Pk => Id;
}
