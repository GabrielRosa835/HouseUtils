namespace HouseUtils.Domain.Models;


public record ResourceId (int Value);
public record ResourceCreationArguments(ResourceId Id, string  Name, string Description, Storage Storage);

public class Resource : IEntity<ResourceId>
{
   ResourceId IEntity<ResourceId>.Pk => Id;
   public ResourceId Id { get; private set; }
   public string Name { get; private set; }
   public string? Description { get; private set; }
   public StorageId StorageId { get; private set; }
   public Storage? Storage { get; private set; }

   private Resource(ResourceId id, string name, string? description, Storage storage)
   {
      Id = id;
      Name = name;
      Description = description;
      StorageId = storage.Id;
      Storage = storage;
   }
   

   public static Resource Create (ResourceCreationArguments args)
   {
      return new Resource(args.Id, args.Name, args.Description, args.Storage);
   }
}
