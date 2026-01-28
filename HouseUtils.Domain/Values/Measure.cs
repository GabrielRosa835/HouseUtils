using HouseUtils.Domain.Data;
using HouseUtils.Domain.Models;

namespace HouseUtils.Domain.Values;

public record Measure (decimal Amount, UnitOfMeasure Unit)
{
   public Measure Add (Measure measure)
   {
      if (Unit.Id == UnitOfMeasureConstants.None.Id)
      {
         return new(measure);
      }

      if (Unit.Id == measure.Unit.Id)
      {
         return measure with { Amount = Amount + measure.Amount };
      }

      throw new Exception("It's not possible to add measures of different units");
   }
}