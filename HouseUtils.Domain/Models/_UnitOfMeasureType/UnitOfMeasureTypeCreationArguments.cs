namespace HouseUtils.Domain.Models;

public record UnitOfMeasureTypeCreationArguments
{
   public required  UnitOfMeasureTypeId Id { get; init; }
   public required  string Name { get; init; }
   public required  string? Description { get; init; }
}