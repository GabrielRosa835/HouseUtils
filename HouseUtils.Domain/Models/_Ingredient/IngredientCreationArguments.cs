using HouseUtils.Domain.Values;

namespace HouseUtils.Domain.Models;

public record IngredientCreationArguments
{
   public required IngredientId Id { get; init; }
   public required Measure Measure { get; init; }
   public required Resource Resource { get; init; }
   public required Recipe Recipe { get; init; }
}