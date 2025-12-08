namespace HouseUtils.Application.DTOs;

public record EntityNotFoundProblemDTO : ProblemDTO
{
   public required object Id { get; init; }
   public required string Type { get; init; }

   public static EntityNotFoundProblemDTO Of (object id, string type) => new ()
   {
      Id = id,
      Type = type,
      Message = "Entity Not Found",
      Details = $"The entity of type '{type}' with identifier '{id}' was not found.",
      Category = Problems.Categories.DATA,
   };
   public static EntityNotFoundProblemDTO Of <T> (object id) => Of(id, typeof(T).Name);
}
