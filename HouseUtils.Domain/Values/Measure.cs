using HouseUtils.Domain.Models;

namespace HouseUtils.Domain.Values;

public record Measure (decimal Amount, UnitOfMeasure Unit)
{
   public required decimal Amount { get; init; } = Amount;
   public UnitOfMeasure Unit { get; init; } = Unit;
}
