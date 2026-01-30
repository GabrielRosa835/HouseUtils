namespace HouseUtils.Domain.Models;

public class UnitOfMeasureTypeConstants
{
   public static readonly UnitOfMeasureType None = UnitOfMeasureType.Create(new()
   {
      Id = new(1),
      Name = "None",
      Description = string.Empty,
   });
}