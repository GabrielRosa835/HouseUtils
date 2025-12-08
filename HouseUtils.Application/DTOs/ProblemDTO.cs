using HouseUtils.Shared.Extensions;

namespace HouseUtils.Application.DTOs;

public record ProblemDTO
{
   public string Message { get; set; } = null!;
   public string Category { get; set; } = null!;
   public string? Details { get; set; } = null!;

   public static ProblemDTO Of (string message, string category, string? details = null) => new()
   {
      Message = message,
      Category = category,
      Details = details,
   };
   public static ProblemDTO Of<E> (E exception) where E : notnull, Exception => new()
   {
      Message = exception.Message,
      Category = exception.GetType().Name,
      Details = exception.InnerException?.GetFullMessage(),
   };
}
