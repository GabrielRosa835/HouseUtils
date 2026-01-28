namespace HouseUtils.Domain.Models;

public class UnitOfMeasure : IEntity<UnitOfMeasureId>
{
   UnitOfMeasureId IEntity<UnitOfMeasureId>.Pk => Id;

   public UnitOfMeasureId Id { get; private set; }
   public decimal ConversionFactor { get; private set; }
   public string Name { get; private set; }
   public string Singular { get; private set; }
   public string Abbreviation { get; private set; }
   public UnitOfMeasureTypeId TypeId { get; private set; }
   public UnitOfMeasureType? Type { get; private set; }

   private UnitOfMeasure (
      UnitOfMeasureId id,
      decimal conversionFactor,
      string name,
      string singular,
      string abbreviation,
      UnitOfMeasureType type)
   {
      Id = id;
      ConversionFactor = conversionFactor;
      Name = name;
      Singular = singular;
      Abbreviation = abbreviation;
      TypeId = type.Id;
      Type = type;
   }

   public static UnitOfMeasure Create (UnitOfMeasureCreationArguments args)
   {
      return new UnitOfMeasure(args.Id, args.ConversionFactor, args.Name, args.Singular, args.Abbreviation, args.Type);
   }
}