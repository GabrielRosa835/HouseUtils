using FluentValidation.Results;

using HouseUtils.Application.DTOs;

namespace HouseUtils.Application;

public static class Problems
{
   public static ProblemDTO Of (Exception e) => ProblemDTO.Of(e);
   public static ProblemDTO Of (string message, string category, string? details = null) =>
      ProblemDTO.Of(message, category, details);
   public static EntityNotFoundProblemDTO NotFound<T>(object id) => EntityNotFoundProblemDTO.Of<T>(id);
   public static ValidationProblemDTO Validation<T>(ValidationResult result) => ValidationProblemDTO.Of<T>(result);

   public static class Categories
   {
      public const string VALIDATION = "Validation";
      public const string VALIDATION_FIELD = "Field Validation";
      public const string DATA = "Data";
   }
   public static class Messages
   {
      public const string VALIDATION = "Invalid arguments";
   }
}
