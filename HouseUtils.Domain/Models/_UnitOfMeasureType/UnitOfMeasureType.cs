namespace HouseUtils.Domain.Models;

public class UnitOfMeasureType : IEntity<UnitOfMeasureTypeId>
{
   UnitOfMeasureTypeId IEntity<UnitOfMeasureTypeId>.Pk => Id;
   public UnitOfMeasureTypeId Id { get; private set; }
   public string Name { get; private set; }
   public string? Description { get; private set; }

   private UnitOfMeasureType(UnitOfMeasureTypeId id, string name, string? description)
   {
      Id = id;
      Name = name;
      Description = description;
   }

   public static UnitOfMeasureType Create(UnitOfMeasureTypeCreationArguments args)
   {
      return new UnitOfMeasureType(args.Id, args.Name, args.Description);
   }
}
