using HouseUtils.Domain.Values;

namespace HouseUtils.Domain.Models;

public class Storage : IEntity<int>
{
   public int Id { get; set; }
   public required int ResourceId { get; set; }
   public Resource? Resource { get; set; }
   public required Measure Measure { get; set; }

   int IEntity<int>.Pk => Id;
   object IEntity.Pk => Id;
}
