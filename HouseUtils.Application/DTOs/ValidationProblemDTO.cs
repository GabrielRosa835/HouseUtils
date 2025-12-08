using FluentValidation.Results;

namespace HouseUtils.Application.DTOs;

public record ValidationProblemDTO : ProblemDTO
{
   public string Type { get; set; } = null!;
   public ICollection<FieldValidationProblemDTO> Errors { get; set; } = [];

   public static ValidationProblemDTO Of (ValidationResult result, string type) => new()
   {
      Message = Problems.Messages.VALIDATION,
      Category = Problems.Categories.VALIDATION,
      Type = type,
      Errors = result.Errors.Select(FieldValidationProblemDTO.Of).ToArray(),
   };
   public static ValidationProblemDTO Of<T> (ValidationResult result) => Of(result, typeof(T).Name);
}

public record FieldValidationProblemDTO : ProblemDTO
{
   public string Field { get; set; } = null!;
   public object Value { get; set; } = null!;

   public static FieldValidationProblemDTO Of (ValidationFailure e) => new FieldValidationProblemDTO
   {
      Field = e.PropertyName,
      Value = e.AttemptedValue,
      Message = e.ErrorMessage,
      Category = Problems.Categories.VALIDATION_FIELD,
   };
}
