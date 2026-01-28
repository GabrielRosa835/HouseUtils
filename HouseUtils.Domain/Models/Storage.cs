using HouseUtils.Domain.Values;

namespace HouseUtils.Domain.Models;

public record StorageId (int Value);
public record StorageCreationArguments(StorageId Id, Resource Resource, Measure Measure);

public class Storage : IEntity<StorageId>
{
   StorageId IEntity<StorageId>.Pk => Id;
   public StorageId Id { get; private set; }
   public Resource? Resource { get; private set; }
   public ResourceId ResourceId { get; private set; }
   public Measure Measure { get; private set; }

   private Storage(StorageId id, Resource resource, Measure measure)
   {
      Id = id;
      Resource = resource;
      ResourceId = resource.Id;
      Measure = measure;
   }

   public static Storage Create (StorageCreationArguments args)
   {
      return new Storage(args.Id, args.Resource, args.Measure);
   }
}
