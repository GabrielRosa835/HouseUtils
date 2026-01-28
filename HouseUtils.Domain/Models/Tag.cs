namespace HouseUtils.Domain.Models;

public record TagId (int Value);
public record TagCreationArguments(TagId Id, string Name, string? Description);

public class Tag : IEntity<TagId>
{
   TagId IEntity<TagId>.Pk => Id;
   public TagId Id { get; private set; }
   public string Name { get; private set; }
   public string? Description { get; private set; }

   private Tag(TagId id, string name, string? description)
   {
      Id = id;
      Name = name;
      Description = description;
   }
   public static Tag Create (TagCreationArguments args)
   {
      return new Tag(args.Id, args.Name, args.Description);
   }
}
