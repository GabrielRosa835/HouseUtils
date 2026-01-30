using HouseUtils.Domain.Models;

namespace HouseUtils.Domain.Data;

public class UnitOfMeasureConstants
{
   public static readonly UnitOfMeasure None = UnitOfMeasure.Create(new()
   {
      Abbreviation =  "",
      Name = "None",
      ConversionFactor = 0,
      Id = new UnitOfMeasureId(1),
      Singular = "",
      Type = UnitOfMeasureTypeConstants.None
   });
}