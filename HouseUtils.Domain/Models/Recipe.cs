namespace HouseUtils.Domain.Models;

public class Recipe : IEntity<int>
{
   public int Id { get; set; }
   public required string Name { get; set; }
   public string? Description { get; set; }
   public ICollection<Ingredient> Ingredients { get; set; } = [];
   public ICollection<RecipeStep> Steps { get; set; } = [];

   int IEntity<int>.Pk => Id;
   object IEntity.Pk => Id;
}
