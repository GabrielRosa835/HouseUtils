using FluentValidation;

using HouseUtils.Application.DTOs;

namespace HouseUtils.Application.Extensions;

internal static class ValidationExtensions
{
   public static bool TryValidate<T> (this IValidator<T> validator, T instance, out ValidationProblemDTO problem)
   {
      var result = validator.Validate(instance);
      if (result.IsValid)
      {
         problem = null!;
         return false;
      }
      problem = ValidationProblemDTO.Of<T>(result);
      return true;
   }
}
