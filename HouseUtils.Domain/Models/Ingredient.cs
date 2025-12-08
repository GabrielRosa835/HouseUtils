using HouseUtils.Domain.Values;

namespace HouseUtils.Domain.Models;

public class Ingredient : IEntity<(int ResourceId, int RecipeId)>
{
   public Measure? Measure { get; set; }
   public required int ResourceId { get; set; }
   public Resource? Resource { get; set; }
   public required int RecipeId { get; set; }
   public Recipe? Recipe { get; set; }

   (int, int) IEntity<(int ResourceId, int RecipeId)>.Pk => (ResourceId, RecipeId);
   object IEntity.Pk => (ResourceId, RecipeId);
}
