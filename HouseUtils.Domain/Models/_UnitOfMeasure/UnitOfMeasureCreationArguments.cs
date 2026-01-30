namespace HouseUtils.Domain.Models;

public record UnitOfMeasureCreationArguments
{
   public required UnitOfMeasureId Id { get; init; }
   public required  decimal ConversionFactor { get; init; }
   public required  string Name { get; init; }
   public required  string Singular { get; init; }
   public required  string Abbreviation { get; init; }
   public required  UnitOfMeasureType Type { get; init; }
}