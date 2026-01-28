using HouseUtils.Domain.Values;

namespace HouseUtils.Domain.Models;

public class Ingredient : IEntity<IngredientId>
{
   IngredientId IEntity<IngredientId>.Pk => Id;
   public IngredientId Id { get; private set; }
   public Measure Measure { get; private set; }
   public ResourceId ResourceId { get; private set; }
   public Resource? Resource { get; private set; }
   public RecipeId RecipeId { get; private set; }
   public Recipe? Recipe { get; private set; }

   private Ingredient(IngredientId id, Measure measure, Resource resource, Recipe recipe)
   {
      Id = id;
      Measure = measure;
      ResourceId = resource.Id;
      Resource = resource;
      RecipeId = recipe.Id;
      Recipe = recipe;
   }

   public static Ingredient Create (IngredientCreationArguments args)
   {
      return new Ingredient(args.Id, args.Measure, args.Resource, args.Recipe);
   }
}
