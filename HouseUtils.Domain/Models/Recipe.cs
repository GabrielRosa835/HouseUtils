namespace HouseUtils.Domain.Models;

public record RecipeId (int Value);

public record RecipeCreationArguments (RecipeId Id, string Name, string? Description);

public class Recipe : IEntity<RecipeId>
{
   private readonly List<Ingredient> _ingredients = [];
   private readonly List<RecipeStep> _steps = [];

   RecipeId IEntity<RecipeId>.Pk => Id;
   public RecipeId Id { get; private set; }
   public string Name { get; private set; }
   public string? Description { get; private set; }
   public IReadOnlyList<Ingredient> Ingredients => _ingredients.ToList();
   public IReadOnlyList<RecipeStep> Steps => _steps.ToList();

   private Recipe (RecipeId id, string name, string? description)
   {
      Id = id;
      Name = name;
      Description = description;
   }

   public static Recipe Create (RecipeCreationArguments args)
   {
      return new Recipe(args.Id, args.Name, args.Description);
   }
}