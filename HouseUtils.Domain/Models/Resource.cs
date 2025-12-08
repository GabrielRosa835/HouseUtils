namespace HouseUtils.Domain.Models;

public class Resource : IEntity<int>
{
   public int Id { get; set; }
   public required string Name { get; set; }
   public string? Description { get; set; }
   public required int StorageId { get; set; }
   public Storage? Storage { get; set; }

   int IEntity<int>.Pk => Id;
   object IEntity.Pk => Id;
}
