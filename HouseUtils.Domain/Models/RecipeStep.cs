namespace HouseUtils.Domain.Models;

public record RecipeStepId (int Value);
public record RecipeStepCreationArguments (RecipeStepId Id, int Order, string Instruction, Recipe Recipe);

public class RecipeStep : IEntity<RecipeStepId>
{
   RecipeStepId IEntity<RecipeStepId>.Pk => Id;
   public RecipeStepId Id { get; private set; }
   public int Order { get; private set; }
   public string Instruction { get; private set; }
   public RecipeId RecipeId { get; private set; }
   public Recipe? Recipe { get; private set; }

   private RecipeStep(RecipeStepId id, int order, string instruction, Recipe recipe)
   {
      Id = id;
      Order = order;
      Instruction = instruction;
      RecipeId = recipe.Id;
      Recipe = recipe;
   }


   public static RecipeStep Create (RecipeStepCreationArguments args)
   {
      return new RecipeStep(args.Id, args.Order, args.Instruction, args.Recipe);
   }
}
