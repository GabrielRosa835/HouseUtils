namespace HouseUtils.Domain.Models;

public class RecipeStep : IEntity<int>
{
   public int Id { get; set; }
   public required int Order { get; set; }
   public required string Instruction { get; set; }
   public required int RecipeId { get; set; }
   public Recipe? Recipe { get; set; }

   int IEntity<int>.Pk => Id;
   object IEntity.Pk => Id;
}
